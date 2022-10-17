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

        private async Task<PaginatedResponse<T>> GetResponseAsync<T>(HttpMethod method, string url, IDictionary<string, string> headers, object data, CancellationToken cancellationToken)
        {
            string content = null;
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            string reasonPhrase = null;
            try
            {
                using var request = CreateRequest(method, url, headers, data);
                using var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
                statusCode = response.StatusCode;
                reasonPhrase = response.ReasonPhrase;
                content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                var ret = JsonConvert.DeserializeObject<PaginatedResponse<T>>(content);
                ret.ReasonPhrase = reasonPhrase;
                ret.Success = true;
                ret.RawContent = IncludeRawContentInResponse ? content : null;
                ret.StatusCode = statusCode;
                return ret;
            }
            catch (Exception ex)
            {
                var ret = string.IsNullOrWhiteSpace(reasonPhrase)
                    ? new PaginatedResponse<T> { Error = ex }
                    : new PaginatedResponse<T> { Error = new Exception(reasonPhrase, ex) };

                ret.StatusCode = statusCode;
                ret.ReasonPhrase = reasonPhrase;
                if (IncludeRawContentInResponse)
                    ret.RawContent = content;


                if (AutoThrowIfError)
                    ret.ThrowIfError();

                return ret;
            }
        }

        private async Task<SingleResponse<T>> GetSingleResponseAsync<T>(string subUrl, CancellationToken cancellationToken)
        {
            var response = await GetResponseAsync<T>(HttpMethod.Get, subUrl, _headers, null, cancellationToken).ConfigureAwait(false);
            return new SingleResponse<T>
            {
                Data = response.Data,
                Error = response.Error,
                Success = response.Success,
                RawContent = response.RawContent,
                ReasonPhrase = response.ReasonPhrase,
                Status = response.Status,
                StatusCode = response.StatusCode
            };
        }

        private async Task<PaginatedResponse<T>> GetPaginatedResponseAsync<T>(string subUrl, int page, CancellationToken cancellationToken = default)
        {
            string pagedUrl = subUrl + (subUrl.Contains("?") ? "&" : "?") + $"&page={page}";
            var response = await GetResponseAsync<T>(HttpMethod.Get, pagedUrl, _headers, null, cancellationToken).ConfigureAwait(false);
            return new PaginatedResponse<T>
            {
                Data = response.Data,
                Error = response.Error,
                Links = response.Links,
                RawContent = response.RawContent,
                ReasonPhrase = response.ReasonPhrase,
                Status = response.Status,
                StatusCode = response.StatusCode,
                Success = response.Success
            };
        }

        private async Task<SingleResponse<T>> PostAsync<T>(string subUrl, object data, CancellationToken cancellationToken)
        {
            var response = await GetResponseAsync<T>(HttpMethod.Post, subUrl, _headers, data, cancellationToken).ConfigureAwait(false);
            return new SingleResponse<T>
            {
                Data = response.Data,
                Error = response.Error,
                Success = response.Success,
                RawContent = response.RawContent,
                ReasonPhrase = response.ReasonPhrase,
                Status = response.Status,
                StatusCode = response.StatusCode
            };
        }






        public void SetAuthToken(string token)
        {
            _headers.Clear();
            _headers.Add("Authorization", "Bearer " + token);
        }


        /// <summary>create an auth token. The token has one month valition length. If successfull, this automatically calls <see cref="SetAuthToken(string)"/></summary>
        public async Task<SingleResponse<BearerToken>> LoginAsync(Credentials credentials, CancellationToken cancellationToken = default)
        {
            _headers.Clear();
            var response = await PostAsync<BearerToken>("login", credentials, cancellationToken).ConfigureAwait(false);
            if (response.Success)
                SetAuthToken(response.Data.Token);
            return response;
        }


        public Task<SingleResponse<ArtworkBaseRecord>> GetArtworkBaseAsync(int id, CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<ArtworkBaseRecord>($"artwork/{id}", cancellationToken);


        public Task<SingleResponse<ArtworkExtendedRecord>> GetArtworkExtendedAsync(int id, CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<ArtworkExtendedRecord>($"artwork/{id}/extended", cancellationToken);



        public Task<SingleResponse<List<ArtworkStatus>>> GetAllArtworkStatusesAsync(CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<List<ArtworkStatus>>("artwork/statuses", cancellationToken);


        public Task<SingleResponse<List<ArtworkType>>> GetAllArtworkTypesAsync(CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<List<ArtworkType>>("artwork/types", cancellationToken);

        public Task<SingleResponse<List<AwardBaseRecord>>> GetAllAwardsAsync(CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<List<AwardBaseRecord>>("awards", cancellationToken);


        public Task<SingleResponse<AwardBaseRecord>> GetAwardAsync(int id, CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<AwardBaseRecord>($"awards/{id}", cancellationToken);


        public Task<SingleResponse<AwardExtendedRecord>> GetAwardExtendedAsync(int id, CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<AwardExtendedRecord>($"awards/{id}/extended", cancellationToken);


        public Task<SingleResponse<AwardCategoryBaseRecord>> GetAwardCategoryAsync(int id, CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<AwardCategoryBaseRecord>($"awards/categories/{id}", cancellationToken);


        public Task<SingleResponse<AwardCategoryExtendedRecord>> GetAwardCategoryExtendedAsync(int id, CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<AwardCategoryExtendedRecord>($"awards/categories/{id}/extended", cancellationToken);


        public Task<SingleResponse<Character>> GetCharacterBaseAsync(int id, CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<Character>($"characters/{id}", cancellationToken);


        public Task<SingleResponse<List<CompanyType>>> GetAllCompanyTypesAsync(CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<List<CompanyType>>("companies/types", cancellationToken);


        public Task<SingleResponse<Company>> GetCompanyAsync(int id, CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<Company>($"companies/{id}", cancellationToken);


        public Task<SingleResponse<List<ContentRating>>> GetAllContentRatingsAsync(CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<List<ContentRating>>($"content/ratings", cancellationToken);


        public Task<SingleResponse<List<Country>>> GetAllCountriesAsync(CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<List<Country>>("countries", cancellationToken);


        public Task<SingleResponse<List<EntityType>>> GetEntityTypesAsync(CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<List<EntityType>>("entities", cancellationToken);


        public Task<SingleResponse<EpisodeBaseRecord>> GetEpisodeBaseAsync(int id, CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<EpisodeBaseRecord>($"episodes/{id}", cancellationToken);


        public Task<SingleResponse<EpisodeExtendedRecord>> GetEpisodeExtendedAsync(int id, Meta? meta = null, CancellationToken cancellationToken = default)
        {
            string url = $"episodes/{id}/extended";
            if (meta != null)
                url += $"?meta={meta.ConvertToString()}";
            return GetSingleResponseAsync<EpisodeExtendedRecord>(url, cancellationToken);
        }


        public Task<SingleResponse<Translation>> GetEpisodeTranslationAsync(int id, string language, CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<Translation>($"episodes/{id}/translations/{language}", cancellationToken);


        public Task<SingleResponse<List<Gender>>> GetAllGendersAsync(CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<List<Gender>>("genders", cancellationToken);


        public Task<SingleResponse<List<GenreBaseRecord>>> GetAllGenresAsync(CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<List<GenreBaseRecord>>("genres", cancellationToken);


        public Task<SingleResponse<GenreBaseRecord>> GetGenreBaseAsync(int id, CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<GenreBaseRecord>($"genres/{id}", cancellationToken);


        public Task<SingleResponse<List<InspirationType>>> GetAllInspirationTypesAsync(CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<List<InspirationType>>("inspiration/types", cancellationToken);


        public Task<SingleResponse<List<Language>>> GetAllLanguagesAsync(CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<List<Language>>("languages", cancellationToken);


        public Task<SingleResponse<ListBaseRecord>> GetListAsync(int id, CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<ListBaseRecord>($"lists/{id}", cancellationToken);


        public Task<SingleResponse<ListExtendedRecord>> GetListExtendedAsync(int id, CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<ListExtendedRecord>($"lists/{id}/extended", cancellationToken);


        public Task<SingleResponse<Translation>> GetListTranslationAsync(int id, string language, CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<Translation>($"lists/{id}/translations/{language}", cancellationToken);


        public Task<SingleResponse<MovieBaseRecord>> GetMovieBaseAsync(int id, CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<MovieBaseRecord>($"movies/{id}", cancellationToken);


        public Task<SingleResponse<MovieExtendedRecord>> GetMovieExtendedAsync(int id, Meta? meta = null, CancellationToken cancellationToken = default)
        {
            string url = $"movies/{id}/extended";
            if (meta != null)
                url += $"?meta={meta.ConvertToString()}";
            return GetSingleResponseAsync<MovieExtendedRecord>(url, cancellationToken);
        }


        public Task<SingleResponse<Translation>> GetMovieTranslationAsync(int id, string language, CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<Translation>($"movies/{id}/translations/{language}", cancellationToken);


        public Task<SingleResponse<List<Status>>> GetAllMovieStatusesAsync(CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<List<Status>>("movies/statuses", cancellationToken);


        public Task<SingleResponse<PeopleBaseRecord>> GetPeopleBaseAsync(int id, CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<PeopleBaseRecord>($"people/{id}", cancellationToken);


        public Task<SingleResponse<PeopleExtendedRecord>> GetPeopleExtendedAsync(int id, Meta? meta = null, CancellationToken cancellationToken = default)
        {
            string url = $"people/{id}/extended";
            if (meta != null)
                url += $"?meta={meta.ConvertToString()}";
            return GetSingleResponseAsync<PeopleExtendedRecord>(url, cancellationToken);
        }


        public Task<SingleResponse<Translation>> GetPeopleTranslationAsync(int id, string language, CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<Translation>($"people/{id}/translations/{language}", cancellationToken);


        public Task<SingleResponse<List<PeopleType>>> GetAllPeopleTypesAsync(CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<List<PeopleType>>("people/types", cancellationToken);


        public Task<SingleResponse<List<SearchResult>>> GetSearchResultsAsync(string q, string query = null, SearchTypes? type = null, string remote_id = null, int? year = null, int? offset = null, int? limit = null, CancellationToken cancellationToken = default)
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

            return GetSingleResponseAsync<List<SearchResult>>(url, cancellationToken);
        }


        public Task<SingleResponse<SeasonBaseRecord>> GetSeasonBaseAsync(int id, CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<SeasonBaseRecord>($"seasons/{id}", cancellationToken);


        public Task<SingleResponse<SeasonExtendedRecord>> GetSeasonExtendedAsync(int id, CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<SeasonExtendedRecord>($"seasons/{id}/extended", cancellationToken);


        public Task<SingleResponse<List<SeasonType>>> GetSeasonTypesAsync(CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<List<SeasonType>>("seasons/types", cancellationToken);


        public Task<SingleResponse<Translation>> GetSeasonTranslationAsync(int id, string language, CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<Translation>($"seasons/{id}/translations/{language}", cancellationToken);


        public Task<SingleResponse<SeriesBaseRecord>> GetSeriesBaseAsync(int id, CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<SeriesBaseRecord>($"series/{id}", cancellationToken);


        public Task<SingleResponse<SeriesExtendedRecord>> GetSeriesExtendedAsync(int id, Meta? meta = null, CancellationToken cancellationToken = default)
        {
            string url = $"series/{id}/extended";
            if (meta != null)
                url += $"?meta={meta.ConvertToString()}";
            return GetSingleResponseAsync<SeriesExtendedRecord>(url, cancellationToken);
        }


        public Task<SingleResponse<Translation>> GetSeriesTranslationAsync(int id, string language, CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<Translation>($"series/{id}/translations/{language}", cancellationToken);


        public Task<SingleResponse<List<Status>>> GetAllSeriesStatusesAsync(CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<List<Status>>("series/statuses", cancellationToken);


        public Task<SingleResponse<List<SourceType>>> GetAllSourceTypesAsync(CancellationToken cancellationToken = default) =>
            GetSingleResponseAsync<List<SourceType>>("sources/types", cancellationToken);


        /// <param name="page">Page to retrieve</param>
        public Task<PaginatedResponse<List<Company>>> GetAllCompaniesAsync(int page = 0, CancellationToken cancellationToken = default) =>
            GetPaginatedResponseAsync<List<Company>>("companies", page, cancellationToken);


        /// <param name="page">Page to retrieve</param>
        public Task<PaginatedResponse<List<ListBaseRecord>>> GetAllListsAsync(int page = 0, CancellationToken cancellationToken = default) =>
            GetPaginatedResponseAsync<List<ListBaseRecord>>("lists", page, cancellationToken);


        /// <param name="page">Page to retrieve</param>
        public Task<PaginatedResponse<List<MovieBaseRecord>>> GetAllMovieAsync(int page = 0, CancellationToken cancellationToken = default) =>
            GetPaginatedResponseAsync<List<MovieBaseRecord>>("movies", page, cancellationToken);


        /// <param name="page">Page to retrieve</param>
        public Task<PaginatedResponse<List<SeasonBaseRecord>>> GetAllSeasonsAsync(int page = 0, CancellationToken cancellationToken = default) =>
            GetPaginatedResponseAsync<List<SeasonBaseRecord>>("seasons", page, cancellationToken);


        /// <param name="page">Page to retrieve</param>
        public Task<PaginatedResponse<List<SeriesBaseRecord>>> GetAllSeriesAsync(int page = 0, CancellationToken cancellationToken = default) =>
            GetPaginatedResponseAsync<List<SeriesBaseRecord>>("series", page, cancellationToken);


        public Task<PaginatedResponse<List<EntityUpdate>>> GetUpdatesAsync(DateTime since, UpdateTypes? type = null, Models.Action? action = null, int page = 0, CancellationToken cancellationToken = default)
        {
            string url = $"updates?since={since.ToUnixEpochTime()}";
            if (type != null)
                url += $"&type={type.ConvertToString()}";
            if (action != null)
                url += $"&action={action.ConvertToString()}";

            return GetPaginatedResponseAsync<List<EntityUpdate>>(url, page, cancellationToken);
        }



        public Task<PaginatedResponse<SeriesEpisodeData>> GetSeriesEpisodesAsync(int id, SeasonTypes season_type = SeasonTypes.Default, int page = 0, int? season = null, int? episodeNumber = null, CancellationToken cancellationToken = default)
        {
            string url = $"series/{id}/episodes/{season_type.ConvertToString()}";
            if (season != null)
                url += $"?season={season}";
            if (episodeNumber != null)
            {
                url += url.Contains("?") ? "&" : "?";
                url += $"episodeNumber={episodeNumber}";
            }

            return GetPaginatedResponseAsync<SeriesEpisodeData>(url, page, cancellationToken);
        }


        public Task<PaginatedResponse<SeriesEpisodeData>> GetSeriesSeasonEpisodesTranslatedAsync(int id, SeasonTypes season_type, string lang, int page = 0, CancellationToken cancellationToken = default)
        {
            string url = $"series/{id}/episodes/{season_type.ConvertToString()}/{lang}";
            return GetPaginatedResponseAsync<SeriesEpisodeData>(url, page, cancellationToken);
        }
    }
}