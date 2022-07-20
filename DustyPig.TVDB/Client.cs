using DustyPig.REST;
using DustyPig.TVDB.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB
{
    public class Client
    {
        public const string API_VERSION = "4.4.0";
        public const string API_AS_OF_DATE = "10/15/2021";

        private static readonly REST.Client _client = new REST.Client() { BaseAddress = new Uri("https://api4.thetvdb.com/v4/") };

        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>();


        public static bool IncludeRawContentInResponse
        {
            get => _client.IncludeRawContentInResponse;
            set => _client.IncludeRawContentInResponse = value;
        }

        public static bool AutoThrowIfError
        {
            get => _client.AutoThrowIfError;
            set => _client.AutoThrowIfError = value;
        }


        private async Task<Response<T>> GetAsync<T>(string subUrl, CancellationToken cancellationToken)
        {
            var response = await _client.GetAsync<InternalResponse<T>>(subUrl, null, _headers, cancellationToken).ConfigureAwait(false);
            return new Response<T>
            {
                Data = response.Success ? response.Data.Data : default,
                Error = response.Error,
                Success = response.Success,
                StatusCode = response.StatusCode,
                RawContent = response.RawContent,
                ReasonPhrase = response.ReasonPhrase
            };
        }

        private async Task<Response<List<T>>> GetAsync<T>(string url, int? page, CancellationToken cancellationToken = default)
        {
            string fixUrl = url + (url.Contains("?") ? "&" : "?");

            if (page == null)
            {
                var lst = new List<T>();
                page = 0;
                var statusCode = System.Net.HttpStatusCode.BadRequest;
                string reasonPhrase = null;
                string rawContent = null;

                while (true)
                {
                    var response = await _client.GetAsync<InternalResponse<List<T>>>($"{fixUrl}page={page}", null, _headers, cancellationToken).ConfigureAwait(false);
                    if (!response.Success)
                        return new Response<List<T>>
                        {
                            Error = response.Error,
                            StatusCode = response.StatusCode,
                            RawContent = response.RawContent,
                            ReasonPhrase = response.ReasonPhrase
                        };

                    statusCode = response.StatusCode;
                    reasonPhrase = response.ReasonPhrase;
                    if (_client.IncludeRawContentInResponse)
                        rawContent += response.RawContent + "\r\n\r\n";

                    if (response.Data.Data != null)
                        lst.AddRange(response.Data.Data);

                    if (response.Data.Links != null && response.Data.Links.Next == null)
                        break;
                    if (response.Data.Data == null || response.Data.Data.Count == 0)
                        break;

                    page++;
                }

                return new Response<List<T>>
                {
                    Data = lst,
                    Success = true,
                    StatusCode = statusCode,
                    ReasonPhrase = reasonPhrase,
                    RawContent = _client.IncludeRawContentInResponse ? rawContent.Trim() : null
                };
            }
            else
            {
                return await GetAsync<List<T>>($"{fixUrl}page={page}", cancellationToken).ConfigureAwait(false);
            }
        }

        private async Task<Response<T>> PostAsync<T>(string subUrl, object data, CancellationToken cancellationToken)
        {
            var response = await _client.PostAsync<InternalResponse<T>>(subUrl, data, _headers, cancellationToken).ConfigureAwait(false);
            return new Response<T>
            {
                Data = response.Success ? response.Data.Data : default,
                Error = response.Error,
                Success = response.Success,
                RawContent = response.RawContent,
                ReasonPhrase = response.ReasonPhrase,
                StatusCode = response.StatusCode
            };
        }






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


        /// <param name="page">Page to retrieve, or null to retrieve all pages</param>
        public Task<Response<List<Company>>> GetAllCompaniesAsync(int? page = null, CancellationToken cancellationToken = default) =>
            GetAsync<Company>("companies", page, cancellationToken);


        /// <param name="page">Page to retrieve, or null to retrieve all pages</param>
        public Task<Response<List<ListBaseRecord>>> GetAllListsAsync(int? page = null, CancellationToken cancellationToken = default) =>
            GetAsync<ListBaseRecord>("lists", page, cancellationToken);


        /// <param name="page">Page to retrieve, or null to retrieve all pages</param>
        public Task<Response<List<MovieBaseRecord>>> GetAllMovieAsync(int? page = null, CancellationToken cancellationToken = default) =>
            GetAsync<MovieBaseRecord>("movies", page, cancellationToken);


        /// <param name="page">Page to retrieve, or null to retrieve all pages</param>
        public Task<Response<List<SeasonBaseRecord>>> GetAllSeasonsAsync(int? page = null, CancellationToken cancellationToken = default) =>
            GetAsync<SeasonBaseRecord>("seasons", page, cancellationToken);


        /// <param name="page">Page to retrieve, or null to retrieve all pages</param>
        public Task<Response<List<SeriesBaseRecord>>> GetAllSeriesAsync(int? page = null, CancellationToken cancellationToken = default) =>
            GetAsync<SeriesBaseRecord>("series", page, cancellationToken);


        public Task<Response<List<EntityUpdate>>> GetUpdatesAsync(DateTime since, UpdateTypes? type = null, Models.Action? action = null, int? page = null, CancellationToken cancellationToken = default)
        {
            string url = $"updates?since={since.ToUnixEpochTime()}";
            if (type != null)
                url += $"&type={type.ConvertToString()}";
            if (action != null)
                url += $"&action={action.ConvertToString()}";


            return GetAsync<EntityUpdate>(url, page, cancellationToken);
        }



        /// <param name="page">Page to retrieve, or null to retrieve all pages</param>
        public async Task<Response<SeriesEpisodeData>> GetSeriesEpisodesAsync(int id, SeasonTypes season_type = SeasonTypes.Default, int? page = null, int? season = null, int? episodeNumber = null, CancellationToken cancellationToken = default)
        {
            string url = $"series/{id}/episodes/{season_type.ConvertToString()}";
            if (season != null)
                url += $"?season={season}";
            if (episodeNumber != null)
            {
                url += url.Contains("?") ? "&" : "?";
                url += $"episodeNumber={episodeNumber}";
            }

            if (page == null)
            {
                SeriesEpisodeData ret = null;
                page = 0;
                System.Net.HttpStatusCode statusCode = System.Net.HttpStatusCode.BadRequest;
                string reasonPhrase = null;
                string rawContent = null;

                while (true)
                {
                    string pageUrl = url + (url.Contains("?") ? "&" : "?") + $"page={page}";

                    var response = await _client.GetAsync<InternalResponse<SeriesEpisodeData>>(pageUrl, null, _headers, cancellationToken).ConfigureAwait(false);
                    if (!response.Success)
                        return new Response<SeriesEpisodeData>
                        {
                            Error = response.Error,
                            RawContent = response.RawContent,
                            ReasonPhrase = response.ReasonPhrase,
                            StatusCode = response.StatusCode
                        };

                    statusCode = response.StatusCode;
                    reasonPhrase = response.ReasonPhrase;
                    if (_client.IncludeRawContentInResponse)
                        rawContent += response.RawContent + "\r\n\r\n";

                    if (ret == null)
                        ret = response.Data.Data;
                    else if (response.Data.Data.Episodes != null)
                        ret.Episodes.AddRange(response.Data.Data.Episodes);

                    if (response.Data.Links != null && response.Data.Links.Next == null)
                        break;
                    if (response.Data.Data.Episodes == null || response.Data.Data.Episodes.Count == 0)
                        break;
                    page++;
                }

                if (rawContent != null)
                    rawContent = rawContent.Trim();

                return new Response<SeriesEpisodeData> 
                {
                    Success = true, 
                    Data = ret,
                    StatusCode = statusCode,
                    ReasonPhrase = reasonPhrase,
                    RawContent = rawContent
                };
            }
            else
            {
                string pageUrl = url + (url.Contains("?") ? "&" : "?") + $"page={page}";
                return await GetAsync<SeriesEpisodeData>(pageUrl, cancellationToken).ConfigureAwait(false);
            }
        }


        /// <param name="page">Page to retrieve, or null to retrieve all pages</param>
        public async Task<Response<SeriesEpisodeData>> GetSeriesSeasonEpisodesTranslatedAsync(int id, SeasonTypes season_type, string lang, int? page = null, CancellationToken cancellationToken = default)
        {
            string url = $"series/{id}/episodes/{season_type.ConvertToString()}/{lang}";

            if (page == null)
            {
                SeriesEpisodeData ret = null;
                page = 0;
                System.Net.HttpStatusCode statusCode = System.Net.HttpStatusCode.BadRequest;
                string reasonPhrase = null;
                string rawContent = null;

                while (true)
                {
                    string pageUrl = url + (url.Contains("?") ? "&" : "?") + $"page={page}";

                    var response = await _client.GetAsync<InternalResponse<SeriesEpisodeData>>(pageUrl, null, _headers, cancellationToken).ConfigureAwait(false);
                    if (!response.Success)
                        return new Response<SeriesEpisodeData>
                        {
                            Error = response.Error,
                            StatusCode = response.StatusCode,
                            ReasonPhrase = response.ReasonPhrase,
                            RawContent = response.RawContent
                        };

                    statusCode = response.StatusCode;
                    reasonPhrase = response.ReasonPhrase;
                    if (_client.IncludeRawContentInResponse)
                        rawContent += response.RawContent + "\r\n\r\n";

                    if (ret == null)
                        ret = response.Data.Data;
                    else if (response.Data.Data.Episodes != null)
                        ret.Episodes.AddRange(response.Data.Data.Episodes);

                    if (response.Data.Links != null && response.Data.Links.Next == null)
                        break;
                    if (response.Data.Data.Episodes == null || response.Data.Data.Episodes.Count == 0)
                        break;
                    page++;
                }

                if (rawContent != null)
                    rawContent = rawContent.Trim();

                return new Response<SeriesEpisodeData>
                {
                    Success = true,
                    Data = ret,
                    StatusCode = statusCode,
                    ReasonPhrase = reasonPhrase,
                    RawContent = rawContent
                };
            }
            else
            {
                string pageUrl = url + (url.Contains("?") ? "&" : "?") + $"page={page}";
                return await GetAsync<SeriesEpisodeData>(pageUrl, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}