using DustyPig.TVDB.Clients;
using DustyPig.TVDB.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB
{
    public class Client
    {
        public const string API_VERSION = "4.7.1";
        public const string API_AS_OF_DATE = "10/16/2022";

        private static readonly HttpClient _httpClient = new HttpClient() { BaseAddress = new Uri("https://api4.thetvdb.com/v4/") };

        private readonly Dictionary<string, string> _headers;


        public Client()
        {
            _headers = new Dictionary<string, string>();

            Artwork = new ArtworkClient(this);
            ArtworkStatuses = new ArtworkStatusesClient(this);
            ArtworkTypes = new ArtworkTypesClient(this);
            Authentication = new AuthenticationClient(this, _headers);
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

        public ArtworkClient Artwork { get; }

        public ArtworkStatusesClient ArtworkStatuses { get; }

        public ArtworkTypesClient ArtworkTypes { get; }

        public AuthenticationClient Authentication { get; }

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


        private static JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings 
        {
            NullValueHandling = NullValueHandling.Ignore
        };


        private static HttpRequestMessage CreateRequest(HttpMethod method, string url, IDictionary<string, string> headers, object data)
        {
            var request = new HttpRequestMessage(method, url);
            if (headers != null)
                foreach (var header in headers)
                    request.Headers.Add(header.Key, header.Value);

            if (data != null)
                request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            return request;
        }

        private async Task<Response<T>> GetResponseAsync<T>(HttpMethod method, string subUrl, IDictionary<string, string> headers, object data, CancellationToken cancellationToken)
        {
            string content = null;
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            string reasonPhrase = null;
            try
            {
                using var request = CreateRequest(method, subUrl, headers, data);
                using var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
                statusCode = response.StatusCode;
                reasonPhrase = response.ReasonPhrase;
                content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                var ret = JsonConvert.DeserializeObject<Response<T>>(content, _jsonSerializerSettings);
                ret.ReasonPhrase = reasonPhrase;
                ret.Success = true;
                ret.RawContent = IncludeRawContentInResponse ? content : null;
                ret.StatusCode = statusCode;
                return ret;
            }
            catch (Exception ex)
            {
                var ret = string.IsNullOrWhiteSpace(reasonPhrase)
                    ? new Response<T> { Error = ex }
                    : new Response<T> { Error = new Exception(reasonPhrase, ex) };

                ret.StatusCode = statusCode;
                ret.ReasonPhrase = reasonPhrase;
                if (IncludeRawContentInResponse)
                    ret.RawContent = content;


                if (AutoThrowIfError)
                    ret.ThrowIfError();

                return ret;
            }
        }





        internal Task<Response<T>> GetAsync<T>(string subUrl, CancellationToken cancellationToken) =>
            GetResponseAsync<T>(HttpMethod.Get, subUrl, _headers, null, cancellationToken);

        internal Task<Response<T>> GetAsync<T>(string subUrl, int page, CancellationToken cancellationToken)
        {
            string pagedUrl = AddQuery(subUrl, $"page={page}");
            return GetResponseAsync<T>(HttpMethod.Get, pagedUrl, _headers, null, cancellationToken);
        }

        internal Task<Response<T>> PostAsync<T>(string subUrl, object data, CancellationToken cancellationToken) =>
            GetResponseAsync<T>(HttpMethod.Post, subUrl, _headers, data, cancellationToken);






        internal static string AddQuery(string url, string q)
        {
            return url + (url.Contains("?") ? "&" : "?") + q;
        }
    }
}