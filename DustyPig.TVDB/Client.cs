using DustyPig.TVDB.Clients;
using DustyPig.TVDB.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB
{
    public class Client : IDisposable
    {
        public const string API_VERSION = "4.7.9";
        public const string API_AS_OF_DATE = "02/29/2024";


        private readonly REST.Client _restClient;// = new("https://api4.thetvdb.com/v4/");
        private readonly Dictionary<string, string> _headers = [];



        /// <summary>
        /// Creates a configuration that uses its own internal <see cref="HttpClient"/>. When using this constructor, <see cref="Dispose"/> should be called.
        /// </summary>
        public Client()
        {
            _restClient = new() { BaseAddress = new("https://api4.thetvdb.com/v4/") };
            InitEndpoints();
        }


        /// <summary
        /// Creates a configurtion that uses a shared <see cref="HttpClient"/>
        /// </summary
        /// <param name="httpClient">The shared <see cref="HttpClient"/> this REST configuration should use</param>
        public Client(HttpClient httpClient)
        {
            _restClient = new(httpClient) { BaseAddress = new("https://api4.thetvdb.com/v4/") };
            InitEndpoints();
        }



        public void Dispose()
        {
            _restClient.Dispose();
            GC.SuppressFinalize(this);
        }




        void InitEndpoints()
        {
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



        public ArtworkClient Artwork { get; private set; }

        public ArtworkStatusesClient ArtworkStatuses { get; private set; }

        public ArtworkTypesClient ArtworkTypes { get; private set; }

        public AwardCategoriesClient AwardCategories { get; private set; }

        public AwardsClient Awards { get; private set; }

        public CharactersClient Characters { get; private set; }

        public CompaniesClient Companies { get; private set; }

        public ContentRatingsClient ContentRatings { get; private set; }

        public CountriesClient Countries { get; private set; }

        public EntityTypesClient EntityTypes { get; private set; }

        public EpisodesClient Episodes { get; private set; }

        public FavoritesClient Favorites { get; private set; }

        public GendersClient Genders { get; private set; }

        public GenresClient Genres { get; private set; }

        public InspirationTypesClient InspirationTypes { get; private set; }

        public LanguagesClient Languages { get; private set; }

        public ListsClient Lists { get; private set; }

        public LoginClient Login { get; private set; }

        public MoviesClient Movies { get; private set; }

        public MovieStatusesClient MovieStatuses { get; private set; }

        public PeopleClient People { get; private set; }

        public PeopleTypesClient PeopleTypes { get; private set; }

        public SearchClient Search { get; private set; }

        public SeasonsClient Seasons { get; private set; }

        public SeriesClient Series { get; private set; }

        public SeriesStatusesClient SeriesStatuses { get; private set; }

        public SourceTypesClient SourceTypes { get; private set; }

        public UpdatesClient Updates { get; private set; }

        public UserInfoClient UserInfo { get; private set; }



        public bool IncludeRawContentInResponse
        {
            get => _restClient.IncludeRawContentInResponse;
            set => _restClient.IncludeRawContentInResponse = value;
        }

        public bool AutoThrowIfError
        {
            get => _restClient.AutoThrowIfError;
            set => _restClient.AutoThrowIfError = value;
        }

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
            get => _restClient.RetryCount;
            set => _restClient.RetryCount = value;
        }

        /// <summary>
        /// Number of milliseconds between retries.
        /// <br />
        /// Default = 0
        /// </summary>
        public int RetryDelay
        {
            get => _restClient.RetryDelay;
            set => _restClient.RetryDelay = value;
        }

        /// <summary>
        /// Minimum number of milliseconds between api calls.
        /// <br />
        /// Default = 0
        /// </summary>
        public int Throttle
        {
            get => _restClient.Throttle;
            set => _restClient.Throttle = value;
        }



        internal async Task<Response<T>> GetAsync<T>(string subUrl, CancellationToken cancellationToken)
        {
            var response = await _restClient.GetAsync<Response<T>>(subUrl, _headers, cancellationToken).ConfigureAwait(false);
            return FlattenResponse(response);
        }


        internal async Task<Response<T>> GetAsync<T>(string subUrl, int page, CancellationToken cancellationToken)
        {
            var response = await _restClient.GetAsync<Response<T>>(AddQuery(subUrl, $"page={page}"), _headers, cancellationToken).ConfigureAwait(false);
            return FlattenResponse(response);
        }

        internal async Task<Response<T>> PostAsync<T>(string subUrl, object data, CancellationToken cancellationToken)
        {
            var response = await _restClient.PostAsync<Response<T>>(subUrl, data, _headers, cancellationToken).ConfigureAwait(false);
            return FlattenResponse(response);
        }



        internal static Response<T> FlattenResponse<T>(REST.Response<Response<T>> response)
        {
            var ret = response.Data;
            ret ??= new();
            ret.Error = response.Error;
            ret.Success = response.Success;
            ret.RawContent = response.RawContent;
            ret.ReasonPhrase = response.ReasonPhrase;
            ret.StatusCode = response.StatusCode;
            ret.Success = response.Success;
            return ret;
        }


        internal static string AddQuery(string url, string q)
        {
            return url + (url.Contains('?') ? "&" : "?") + q;
        }
    }
}