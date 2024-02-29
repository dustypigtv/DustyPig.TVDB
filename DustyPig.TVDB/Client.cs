using DustyPig.TVDB.Clients;
using DustyPig.TVDB.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB
{
    public class Client : IDisposable
    {
        public const string API_VERSION = "4.7.9";
        public const string API_AS_OF_DATE = "02/29/2024";


        private readonly REST.Client _restClient = new("https://api4.thetvdb.com/v4/");
        private readonly Dictionary<string, string> _headers = [];



        public Client()
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

        public void Dispose()
        {
            _restClient.Dispose();
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
            return FlattenResponse<T>(response);
        }


        internal Task<Response<T>> GetAsync<T>(string subUrl, int page, CancellationToken cancellationToken) =>
            GetAsync<T>(AddQuery(subUrl, $"page={page}"), cancellationToken);


        internal async Task<Response<T>> PostAsync<T>(string subUrl, object data, CancellationToken cancellationToken)
        {
            var response = await _restClient.PostAsync<Response<T>>(subUrl, data, _headers, cancellationToken).ConfigureAwait(false);
            return FlattenResponse<T>(response);
        }



        internal static Response<T> FlattenResponse<T>(REST.Response<Response<T>> response)
        {
            var ret = response.Data;
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