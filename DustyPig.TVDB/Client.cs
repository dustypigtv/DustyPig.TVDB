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
        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>();

        public static bool IncludeRawContentInResponse { get; set; }

        public static bool AutoThrowIfError { get; set; }


        private HttpRequestMessage CreateRequest(HttpMethod method, string url, IDictionary<string, string> headers, object data)
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
                var ret = JsonConvert.DeserializeObject<Response<T>>(content);
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



        private Task<Response<T>> GetAsync<T>(string subUrl, CancellationToken cancellationToken = default) =>
            GetResponseAsync<T>(HttpMethod.Get, subUrl, _headers, null, cancellationToken);

        private Task<Response<T>> GetAsync<T>(string subUrl, int page, CancellationToken cancellationToken = default)
        {
            string pagedUrl = subUrl + (subUrl.Contains("?") ? "&" : "?") + $"&page={page}";
            return GetResponseAsync<T>(HttpMethod.Get, pagedUrl, _headers, null, cancellationToken);
        }

        private Task<Response<T>> PostAsync<T>(string subUrl, object data, CancellationToken cancellationToken) =>
            GetResponseAsync<T>(HttpMethod.Post, subUrl, _headers, data, cancellationToken);
        





        public void SetAuthToken(string token)
        {
            _headers.Clear();
            _headers.Add("Authorization", "Bearer " + token);
        }


        /// <summary>create an auth token. The token has one month valition length. If successfull, this automatically calls <see cref="SetAuthToken(string)"/></summary>
        public async Task<Response<BearerToken>> LoginAsync(Credentials credentials, CancellationToken cancellationToken = default)
        {
            _headers.Clear();
            var response = await PostAsync<BearerToken>("login", credentials, cancellationToken).ConfigureAwait(false);
            if (response.Success)
                SetAuthToken(response.Data.Token);
            return response;
        }


        public Task<Response<ArtworkBaseRecord>> GetArtworkBaseAsync(int id, CancellationToken cancellationToken = default) =>
            GetAsync<ArtworkBaseRecord>($"artwork/{id}", cancellationToken);


        public Task<Response<ArtworkExtendedRecord>> GetArtworkExtendedAsync(int id, CancellationToken cancellationToken = default) =>
            GetAsync<ArtworkExtendedRecord>($"artwork/{id}/extended", cancellationToken);



        public Task<Response<List<ArtworkStatus>>> GetAllArtworkStatusesAsync(CancellationToken cancellationToken = default) =>
            GetAsync<List<ArtworkStatus>>("artwork/statuses", cancellationToken);


        public Task<Response<List<ArtworkType>>> GetAllArtworkTypesAsync(CancellationToken cancellationToken = default) =>
            GetAsync<List<ArtworkType>>("artwork/types", cancellationToken);

        public Task<Response<List<AwardBaseRecord>>> GetAllAwardsAsync(CancellationToken cancellationToken = default) =>
            GetAsync<List<AwardBaseRecord>>("awards", cancellationToken);


        public Task<Response<AwardBaseRecord>> GetAwardAsync(int id, CancellationToken cancellationToken = default) =>
            GetAsync<AwardBaseRecord>($"awards/{id}", cancellationToken);


        public Task<Response<AwardExtendedRecord>> GetAwardExtendedAsync(int id, CancellationToken cancellationToken = default) =>
            GetAsync<AwardExtendedRecord>($"awards/{id}/extended", cancellationToken);


        public Task<Response<AwardCategoryBaseRecord>> GetAwardCategoryAsync(int id, CancellationToken cancellationToken = default) =>
            GetAsync<AwardCategoryBaseRecord>($"awards/categories/{id}", cancellationToken);


        public Task<Response<AwardCategoryExtendedRecord>> GetAwardCategoryExtendedAsync(int id, CancellationToken cancellationToken = default) =>
            GetAsync<AwardCategoryExtendedRecord>($"awards/categories/{id}/extended", cancellationToken);


        public Task<Response<Character>> GetCharacterBaseAsync(int id, CancellationToken cancellationToken = default) =>
            GetAsync<Character>($"characters/{id}", cancellationToken);


        public Task<Response<List<CompanyType>>> GetAllCompanyTypesAsync(CancellationToken cancellationToken = default) =>
            GetAsync<List<CompanyType>>("companies/types", cancellationToken);


        public Task<Response<Company>> GetCompanyAsync(int id, CancellationToken cancellationToken = default) =>
            GetAsync<Company>($"companies/{id}", cancellationToken);


        public Task<Response<List<ContentRating>>> GetAllContentRatingsAsync(CancellationToken cancellationToken = default) =>
            GetAsync<List<ContentRating>>($"content/ratings", cancellationToken);


        public Task<Response<List<Country>>> GetAllCountriesAsync(CancellationToken cancellationToken = default) =>
            GetAsync<List<Country>>("countries", cancellationToken);


        public Task<Response<List<EntityType>>> GetEntityTypesAsync(CancellationToken cancellationToken = default) =>
            GetAsync<List<EntityType>>("entities", cancellationToken);


        public Task<Response<EpisodeBaseRecord>> GetEpisodeBaseAsync(int id, CancellationToken cancellationToken = default) =>
            GetAsync<EpisodeBaseRecord>($"episodes/{id}", cancellationToken);


        public Task<Response<EpisodeExtendedRecord>> GetEpisodeExtendedAsync(int id, Meta? meta = null, CancellationToken cancellationToken = default)
        {
            string url = $"episodes/{id}/extended";
            if (meta != null)
                url += $"?meta={meta.ConvertToString()}";
            return GetAsync<EpisodeExtendedRecord>(url, cancellationToken);
        }


        public Task<Response<Translation>> GetEpisodeTranslationAsync(int id, string language, CancellationToken cancellationToken = default) =>
            GetAsync<Translation>($"episodes/{id}/translations/{language}", cancellationToken);


        public Task<Response<List<Gender>>> GetAllGendersAsync(CancellationToken cancellationToken = default) =>
            GetAsync<List<Gender>>("genders", cancellationToken);


        public Task<Response<List<GenreBaseRecord>>> GetAllGenresAsync(CancellationToken cancellationToken = default) =>
            GetAsync<List<GenreBaseRecord>>("genres", cancellationToken);


        public Task<Response<GenreBaseRecord>> GetGenreBaseAsync(int id, CancellationToken cancellationToken = default) =>
            GetAsync<GenreBaseRecord>($"genres/{id}", cancellationToken);


        public Task<Response<List<InspirationType>>> GetAllInspirationTypesAsync(CancellationToken cancellationToken = default) =>
            GetAsync<List<InspirationType>>("inspiration/types", cancellationToken);


        public Task<Response<List<Language>>> GetAllLanguagesAsync(CancellationToken cancellationToken = default) =>
            GetAsync<List<Language>>("languages", cancellationToken);


        public Task<Response<ListBaseRecord>> GetListAsync(int id, CancellationToken cancellationToken = default) =>
            GetAsync<ListBaseRecord>($"lists/{id}", cancellationToken);


        public Task<Response<ListExtendedRecord>> GetListExtendedAsync(int id, CancellationToken cancellationToken = default) =>
            GetAsync<ListExtendedRecord>($"lists/{id}/extended", cancellationToken);


        public Task<Response<Translation>> GetListTranslationAsync(int id, string language, CancellationToken cancellationToken = default) =>
            GetAsync<Translation>($"lists/{id}/translations/{language}", cancellationToken);


        public Task<Response<MovieBaseRecord>> GetMovieBaseAsync(int id, CancellationToken cancellationToken = default) =>
            GetAsync<MovieBaseRecord>($"movies/{id}", cancellationToken);


        public Task<Response<MovieExtendedRecord>> GetMovieExtendedAsync(int id, Meta? meta = null, CancellationToken cancellationToken = default)
        {
            string url = $"movies/{id}/extended";
            if (meta != null)
                url += $"?meta={meta.ConvertToString()}";
            return GetAsync<MovieExtendedRecord>(url, cancellationToken);
        }


        public Task<Response<Translation>> GetMovieTranslationAsync(int id, string language, CancellationToken cancellationToken = default) =>
            GetAsync<Translation>($"movies/{id}/translations/{language}", cancellationToken);


        public Task<Response<List<Status>>> GetAllMovieStatusesAsync(CancellationToken cancellationToken = default) =>
            GetAsync<List<Status>>("movies/statuses", cancellationToken);


        public Task<Response<PeopleBaseRecord>> GetPeopleBaseAsync(int id, CancellationToken cancellationToken = default) =>
            GetAsync<PeopleBaseRecord>($"people/{id}", cancellationToken);


        public Task<Response<PeopleExtendedRecord>> GetPeopleExtendedAsync(int id, Meta? meta = null, CancellationToken cancellationToken = default)
        {
            string url = $"people/{id}/extended";
            if (meta != null)
                url += $"?meta={meta.ConvertToString()}";
            return GetAsync<PeopleExtendedRecord>(url, cancellationToken);
        }


        public Task<Response<Translation>> GetPeopleTranslationAsync(int id, string language, CancellationToken cancellationToken = default) =>
            GetAsync<Translation>($"people/{id}/translations/{language}", cancellationToken);


        public Task<Response<List<PeopleType>>> GetAllPeopleTypesAsync(CancellationToken cancellationToken = default) =>
            GetAsync<List<PeopleType>>("people/types", cancellationToken);


        public Task<Response<List<SearchResult>>> GetSearchResultsAsync(string q, string query = null, SearchTypes? type = null, string remote_id = null, int? year = null, int? offset = null, int? limit = null, CancellationToken cancellationToken = default)
        {
            string url = "search?q=" + Uri.EscapeDataString(q);
            if (!string.IsNullOrWhiteSpace(query))
                url += "&query=" + Uri.EscapeDataString(query);
            if (type != null)
                url += "&type=" + type.ConvertToString();
            if (!string.IsNullOrWhiteSpace(remote_id))
                url += "&remote_id=" + Uri.EscapeDataString(remote_id);
            if (year != null)
                url += $"&year{year}";
            if (offset != null)
                url += $"&offset={offset}";
            if (limit != null)
                url += $"&limit={limit}";

            return GetAsync<List<SearchResult>>(url, cancellationToken);
        }


        public Task<Response<SeasonBaseRecord>> GetSeasonBaseAsync(int id, CancellationToken cancellationToken = default) =>
            GetAsync<SeasonBaseRecord>($"seasons/{id}", cancellationToken);


        public Task<Response<SeasonExtendedRecord>> GetSeasonExtendedAsync(int id, CancellationToken cancellationToken = default) =>
            GetAsync<SeasonExtendedRecord>($"seasons/{id}/extended", cancellationToken);


        public Task<Response<List<SeasonType>>> GetSeasonTypesAsync(CancellationToken cancellationToken = default) =>
            GetAsync<List<SeasonType>>("seasons/types", cancellationToken);


        public Task<Response<Translation>> GetSeasonTranslationAsync(int id, string language, CancellationToken cancellationToken = default) =>
            GetAsync<Translation>($"seasons/{id}/translations/{language}", cancellationToken);


        public Task<Response<SeriesBaseRecord>> GetSeriesBaseAsync(int id, CancellationToken cancellationToken = default) =>
            GetAsync<SeriesBaseRecord>($"series/{id}", cancellationToken);


        public Task<Response<SeriesExtendedRecord>> GetSeriesExtendedAsync(int id, Meta? meta = null, CancellationToken cancellationToken = default)
        {
            string url = $"series/{id}/extended";
            if (meta != null)
                url += $"?meta={meta.ConvertToString()}";
            return GetAsync<SeriesExtendedRecord>(url, cancellationToken);
        }


        public Task<Response<Translation>> GetSeriesTranslationAsync(int id, string language, CancellationToken cancellationToken = default) =>
            GetAsync<Translation>($"series/{id}/translations/{language}", cancellationToken);


        public Task<Response<List<Status>>> GetAllSeriesStatusesAsync(CancellationToken cancellationToken = default) =>
            GetAsync<List<Status>>("series/statuses", cancellationToken);


        public Task<Response<List<SourceType>>> GetAllSourceTypesAsync(CancellationToken cancellationToken = default) =>
            GetAsync<List<SourceType>>("sources/types", cancellationToken);


        /// <param name="page">Page to retrieve</param>
        public Task<Response<List<Company>>> GetAllCompaniesAsync(int page = 0, CancellationToken cancellationToken = default) =>
            GetAsync<List<Company>>("companies", page, cancellationToken);


        /// <param name="page">Page to retrieve</param>
        public Task<Response<List<ListBaseRecord>>> GetAllListsAsync(int page = 0, CancellationToken cancellationToken = default) =>
            GetAsync<List<ListBaseRecord>>("lists", page, cancellationToken);


        /// <param name="page">Page to retrieve</param>
        public Task<Response<List<MovieBaseRecord>>> GetAllMovieAsync(int page = 0, CancellationToken cancellationToken = default) =>
            GetAsync<List<MovieBaseRecord>>("movies", page, cancellationToken);


        /// <param name="page">Page to retrieve</param>
        public Task<Response<List<SeasonBaseRecord>>> GetAllSeasonsAsync(int page = 0, CancellationToken cancellationToken = default) =>
            GetAsync<List<SeasonBaseRecord>>("seasons", page, cancellationToken);


        /// <param name="page">Page to retrieve</param>
        public Task<Response<List<SeriesBaseRecord>>> GetAllSeriesAsync(int page = 0, CancellationToken cancellationToken = default) =>
            GetAsync<List<SeriesBaseRecord>>("series", page, cancellationToken);


        public Task<Response<List<EntityUpdate>>> GetUpdatesAsync(DateTime since, UpdateTypes? type = null, Models.Action? action = null, int page = 0, CancellationToken cancellationToken = default)
        {
            string url = $"updates?since={since.ToUnixEpochTime()}";
            if (type != null)
                url += $"&type={type.ConvertToString()}";
            if (action != null)
                url += $"&action={action.ConvertToString()}";

            return GetAsync<List<EntityUpdate>>(url, page, cancellationToken);
        }



        public Task<Response<SeriesEpisodeData>> GetSeriesEpisodesAsync(int id, SeasonTypes season_type = SeasonTypes.Default, int page = 0, int? season = null, int? episodeNumber = null, CancellationToken cancellationToken = default)
        {
            string url = $"series/{id}/episodes/{season_type.ConvertToString()}";
            if (season != null)
                url += $"?season={season}";
            if (episodeNumber != null)
            {
                url += url.Contains("?") ? "&" : "?";
                url += $"episodeNumber={episodeNumber}";
            }

            return GetAsync<SeriesEpisodeData>(url, page, cancellationToken);
        }


        public Task<Response<SeriesEpisodeData>> GetSeriesSeasonEpisodesTranslatedAsync(int id, SeasonTypes season_type, string lang, int page = 0, CancellationToken cancellationToken = default)
        {
            string url = $"series/{id}/episodes/{season_type.ConvertToString()}/{lang}";
            return GetAsync<SeriesEpisodeData>(url, page, cancellationToken);
        }
    }
}