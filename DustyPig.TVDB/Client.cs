using DustyPig.TVDB.Clients;
using DustyPig.TVDB.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB
{
    public class Client : IDisposable
    {
        public const string API_VERSION = "4.7.9";
        public const string API_AS_OF_DATE = "02/12/2024";

        private readonly HttpClient _httpClient = new() { BaseAddress = new Uri("https://api4.thetvdb.com/v4/") };

        private static readonly JsonSerializerOptions _jsonSerializerOptions = new(JsonSerializerDefaults.Web)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };



        private int _retryCount = 0;
        private int _retryDelay = 0;
        private int _throttle = 0;
        private DateTime _nextCall = DateTime.MinValue;

        private readonly Dictionary<string, string> _headers;


        public Client()
        {
            _headers = [];

            Artwork = new ArtworkClient(this);
            ArtworkStatuses = new ArtworkStatusesClient(this);
            ArtworkTypes = new ArtworkTypesClient(this);
            AwardCategories = new AwardCategoriesClient(this);
            Awards = new AwardsClient(this);
            Characters = new CharactersClient(this);
            Companies = new CompaniesClient(this);
            ContentRatings = new ContentRatingsClient(this);
            Countries = new CountriesClient(this);
            EntityTypes = new EntityTypesClient(this);
            Episodes = new EpisodesClient(this);
            Favorites = new FavoritesClient(this);
            Genders = new GendersClient(this);
            Genres = new GenresClient(this);
            InspirationTypes = new InspirationTypesClient(this);
            Languages = new LanguagesClient(this);
            Lists = new ListsClient(this);
            Login = new LoginClient(this, _headers);
            Movies = new MoviesClient(this);
            MovieStatuses = new MovieStatusesClient(this);
            People = new PeopleClient(this);
            PeopleTypes = new PeopleTypesClient(this);
            Search = new SearchClient(this);
            Seasons = new SeasonsClient(this);
            Series = new SeriesClient(this);
            SeriesStatuses = new SeriesStatusesClient(this);
            SourceTypes = new SourceTypesClient(this);
            Updates = new UpdatesClient(this);
            UserInfo = new UserInfoClient(this);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
            GC.SuppressFinalize(this);
        }

        public ArtworkClient Artwork { get; }

        public ArtworkStatusesClient ArtworkStatuses { get; }

        public ArtworkTypesClient ArtworkTypes { get; }

        public AwardCategoriesClient AwardCategories { get; }

        public AwardsClient Awards { get; }

        public CharactersClient Characters { get; }

        public CompaniesClient Companies { get; }

        public ContentRatingsClient ContentRatings { get; }

        public CountriesClient Countries { get; }

        public EntityTypesClient EntityTypes { get; }

        public EpisodesClient Episodes { get; }

        public FavoritesClient Favorites { get; }

        public GendersClient Genders { get; }

        public GenresClient Genres { get; }

        public InspirationTypesClient InspirationTypes { get; }

        public LanguagesClient Languages { get; }

        public ListsClient Lists { get; }

        public LoginClient Login { get; }

        public MoviesClient Movies { get; }

        public MovieStatusesClient MovieStatuses { get; }

        public PeopleClient People { get; }

        public PeopleTypesClient PeopleTypes { get; }

        public SearchClient Search { get; }

        public SeasonsClient Seasons { get; }

        public SeriesClient Series { get; }

        public SeriesStatusesClient SeriesStatuses { get; }

        public SourceTypesClient SourceTypes { get; }

        public UpdatesClient Updates { get; }

        public UserInfoClient UserInfo { get; }




        public bool IncludeRawContentInResponse { get; set; }

        public bool AutoThrowIfError { get; set; }



        /// <summary>
        /// When an error occurs, how many times to retry the api call.
        /// <br />
        /// Default = 0
        /// </summary>
        /// <remarks>
        /// <para>
        /// There are 2 events that can trigger a retry:
        /// </para>
        /// <para>
        /// 1. There is an error connecting to the server (such as a network layer error).
        /// </para>
        /// <para>
        /// 2. The connection succeeded, but the server sent HttpStatusCode.TooManyRequests (429). 
        ///    In this case, the client will attempt to get the RetryAfter header, and if found, 
        ///    the delay will be the maximum of the header and the <see cref="RetryDelay"/>. 
        ///    Otherwise, the retry delay will just be <see cref="RetryDelay"/>.
        /// </para>
        /// </remarks>
        public int RetryCount
        {
            get => _retryCount;
            set
            {
                ThrowIfNegative(value);
                _retryCount = value;
            }
        }


        /// <summary>
        /// Number of milliseconds between retries.
        /// <br />
        /// Default = 0
        /// </summary>
        public int RetryDelay
        {
            get => _retryDelay;
            set
            {

                ThrowIfNegative(value);
                _retryDelay = value;
            }
        }


        /// <summary>
        /// Minimum number of milliseconds between api calls.
        /// <br />
        /// Default = 0
        /// </summary>
        public int Throttle
        {
            get => _throttle;
            set
            {
                ThrowIfNegative(value);
                _throttle = value;
            }
        }



        private static void ThrowIfNegative(int value)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegative(value);
#else
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(value)} ('{value}') must be a non-negative value.");
#endif
        }

        private Task WaitForThrottle(CancellationToken cancellationToken)
        {
            if (_throttle > 0)
            {
                var wait = (_nextCall - DateTime.Now).Milliseconds;
                if (wait > 0)
                    return Task.Delay(wait, cancellationToken);
            }
            return Task.CompletedTask;
        }

        private void SetNextCall()
        {
            if (_throttle > 0)
                _nextCall = DateTime.Now.AddMilliseconds(_throttle);
        }


        private HttpRequestMessage CreateRequest(HttpMethod method, string url, object data)
        {
            var request = new HttpRequestMessage(method, url);

            foreach (var header in _headers)
                request.Headers.TryAddWithoutValidation(header.Key, header.Value);

            if (data != null)
                request.Content = new StringContent(JsonSerializer.Serialize(data, _jsonSerializerOptions), Encoding.UTF8, "application/json");

            return request;
        }


        private async Task<Response<T>> GetResponseAsync<T>(HttpMethod method, string subUrl, object data, CancellationToken cancellationToken)
        {
            string content = null;
            HttpStatusCode? statusCode = null;
            string reasonPhrase = null;
            int previousTries = 0;
            var retryAfter = TimeSpan.Zero;
            while (true)
            {
                try
                {
                    if (_throttle > 0)
                        await WaitForThrottle(cancellationToken).ConfigureAwait(false);
                    using var request = CreateRequest(method, subUrl, data);
                    using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    statusCode = response.StatusCode;
                    reasonPhrase = response.ReasonPhrase;
                    retryAfter = response.Headers.RetryAfter?.Delta ?? TimeSpan.Zero;

                    if (response.IsSuccessStatusCode || IncludeRawContentInResponse)
                        content = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

                    response.EnsureSuccessStatusCode();
                    SetNextCall();

                    var ret = JsonSerializer.Deserialize<Response<T>>(content, _jsonSerializerOptions);
                    ret.ReasonPhrase = reasonPhrase;
                    ret.Success = true;
                    ret.RawContent = IncludeRawContentInResponse ? content : null;
                    ret.StatusCode = statusCode;
                    return ret;
                }
                catch (Exception ex)
                {
                    SetNextCall();

                    //If statusCode == null, there was a network error, retries are permitted
                    //If statusCode == HttpStatusCode.TooManyRequests, retries are also permitted
                    if (previousTries < RetryCount && (statusCode == null || statusCode == HttpStatusCode.TooManyRequests))
                    {
                        try
                        {
                            int delay = Math.Max(0, Math.Max(RetryDelay, retryAfter.Milliseconds));
                            if (delay > 0)
                                await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
                        }
                        catch
                        {
                            return BuildErrorResponse(ex);
                        }
                        previousTries++;
                    }
                    else
                    {
                        return BuildErrorResponse(ex);
                    }
                }
            }

            Response<T> BuildErrorResponse(Exception ex)
            {
                var ret = new Response<T>
                {
                    Error = ex,
                    StatusCode = statusCode,
                    ReasonPhrase = reasonPhrase,
                    RawContent = IncludeRawContentInResponse ? content : null
                };

                if (AutoThrowIfError)
                    ret.ThrowIfError();

                return ret;
            }
        }





        internal Task<Response<T>> GetAsync<T>(string subUrl, CancellationToken cancellationToken) =>
            GetResponseAsync<T>(HttpMethod.Get, subUrl, null, cancellationToken);

        internal Task<Response<T>> GetAsync<T>(string subUrl, int page, CancellationToken cancellationToken)
        {
            string pagedUrl = AddQuery(subUrl, $"page={page}");
            return GetResponseAsync<T>(HttpMethod.Get, pagedUrl, null, cancellationToken);
        }

        internal Task<Response<T>> PostAsync<T>(string subUrl, object data, CancellationToken cancellationToken) =>
            GetResponseAsync<T>(HttpMethod.Post, subUrl, data, cancellationToken);






        internal static string AddQuery(string url, string q)
        {
            return url + (url.Contains('?') ? "&" : "?") + q;
        }
    }
}