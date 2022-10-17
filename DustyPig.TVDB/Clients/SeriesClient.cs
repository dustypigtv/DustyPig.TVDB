using DustyPig.TVDB.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class SeriesClient
    {
        private readonly Client _client;

        internal SeriesClient(Client client) => _client = client;

        public Task<Response<List<SeriesBaseRecord>>> GetAllAsync(int page = 0, CancellationToken cancellationToken = default) =>
           _client.GetAsync<List<SeriesBaseRecord>>("series", page, cancellationToken);


        public Task<Response<SeriesBaseRecord>> GetAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetAsync<SeriesBaseRecord>($"series/{id}", cancellationToken);

        /// <summary>
        /// Returns series artworks base on language and type.
        /// Note: Artwork type is an id that can be found using <see cref="ArtworkTypesClient.GetAllAsync"/>
        /// </summary>
        public Task<Response<SeriesExtendedRecord>> GetArtworksAsync(int id, string lang = null, int? type = null, CancellationToken cancellationToken = default)
        {
            string url = $"series{id}/artworks";

            if (!string.IsNullOrEmpty(lang))
                url += (url.Contains("?") ? "&" : "?") + $"lang={Uri.EscapeDataString(lang)}";

            if (type != null && type.Value > 0 && type.Value < 4)
                url += (url.Contains("?") ? "&" : "?") + $"type={type}";

            return _client.GetAsync<SeriesExtendedRecord>(url, cancellationToken);
        }

        /// <summary>
        /// Returns series base record including the nextAired field.
        /// Note: nextAired was included in the base record endpoint but that field will deprecated in the future so developers should use the nextAired endpoint.
        /// </summary>
        public Task<Response<SeriesBaseRecord>> GetNextAiredAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetAsync<SeriesBaseRecord>($"series/{id}/nextAired", cancellationToken);


        /// <param name="shortened">Reduce the payload and returns the short version of this record without characters and artworks</param>
        public Task<Response<SeriesExtendedRecord>> GetExtendedAsync(int id, Meta? meta = null, bool shortened = false, CancellationToken cancellationToken = default)
        {
            string url = $"series/{id}/extended?short={shortened}";
            if (meta != null)
                url += $"&meta={meta.ConvertToString()}";

            return _client.GetAsync<SeriesExtendedRecord>(url, cancellationToken);
        }

        /// <summary>
        /// Returns series episodes from the specified season type, default returns the episodes in the series default season type
        /// </summary>
        /// <param name="airDate">airDate of the episode, format is yyyy-mm-dd</param>
        public Task<Response<SeriesEpisodeData>> GetEpisodesAsync(int id, SeasonTypes season_type = SeasonTypes.Default, int page = 0, int? season = null, int? episodeNumber = null, string airDate = null, CancellationToken cancellationToken = default)
        {
            string url = $"series/{id}/episodes/{season_type.ConvertToString()}";
            if (season != null)
                url += $"?season={season}";
            if (episodeNumber != null)
                url = Client.AddQuery(url, $"episodeNumber={episodeNumber}");
            if (!string.IsNullOrWhiteSpace(airDate))
                url = Client.AddQuery(url, $"airDate={airDate}");

            return _client.GetAsync<SeriesEpisodeData>(url, page, cancellationToken);
        }

        /// <summary>
        /// Returns series episodes from the specified season type, default returns the episodes in the series default season type
        /// </summary>
        /// <param name="airDate">airDate of the episode, format is yyyy-mm-dd</param>
        public Task<Response<SeriesEpisodeData>> GetEpisodesAsync(int id, SeasonTypes season_type = SeasonTypes.Default, int page = 0, int? season = null, int? episodeNumber = null, DateTime? airDate = null, CancellationToken cancellationToken = default)
        {
            string url = $"series/{id}/episodes/{season_type.ConvertToString()}";
            if (season != null)
                url += $"?season={season}";
            if (episodeNumber != null)
                url = Client.AddQuery(url, $"episodeNumber={episodeNumber}");
            if (airDate != null)
                url = Client.AddQuery(url, $"airDate={airDate.Value:yyyy-MM-dd}");

            return _client.GetAsync<SeriesEpisodeData>(url, page, cancellationToken);
        }

        /// <summary>
        /// Returns series base record with episodes from the specified season type and language. Default returns the episodes in the series default season type.
        /// </summary>
        public Task<Response<SeriesEpisodeData>> GetSeasonEpisodesTranslatedAsync(int id, SeasonTypes season_type, string lang, int page = 0, CancellationToken cancellationToken = default)
        {
            string url = $"series/{id}/episodes/{season_type.ConvertToString()}/{lang}";
            return _client.GetAsync<SeriesEpisodeData>(url, page, cancellationToken);
        }


        /// <summary>
        /// Search series based on filter parameters
        /// </summary>
        /// <param name="country">Required. Country of origin</param>
        /// <param name="lang">Required. Original language</param>
        /// <param name="company">Production company</param>
        /// <param name="contentRating">Content rating id base on a country</param>
        /// <param name="sort">Sort by results</param>
        /// <param name="sortType"></param>
        /// <param name="year">Release year</param>
        public Task<Response<List<SeriesBaseRecord>>> FilterAsync(string country, string lang, int? company = null, int? contentRating = null, int? genre = null, SeriesFilterSort? sort = null, SortType? sortType = null, int? status = null, int? year = null, CancellationToken cancellationToken = default)
        {
            string url = $"series/filter?country={Uri.EscapeDataString(country)}&lang={Uri.EscapeDataString(lang)}";

            if (company != null)
                url += $"&company={company}";

            if (contentRating != null)
                url += $"&contentRating={contentRating}";

            if (genre != null)
                url += $"&genre={genre}";

            if (sort != null)
                url += "&sort=" + sort.ConvertToString();

            if (sortType != null)
                url += "&sortType=" + sortType.ConvertToString();

            if (status != null && status > 0 && status < 4)
                url += $"&status={status}";

            if (year != null)
                url += $"&year={year}";

            return _client.GetAsync<List<SeriesBaseRecord>>(url, cancellationToken);
        }


        public Task<Response<SeriesBaseRecord>> GetAsync(string slug, CancellationToken cancellationToken = default) =>
            _client.GetAsync<SeriesBaseRecord>($"series/slug/{slug}", cancellationToken);

        public Task<Response<Translation>> GetTranslationAsync(int id, string language, CancellationToken cancellationToken = default) =>
            _client.GetAsync<Translation>($"series/{id}/translations/{language}", cancellationToken);
    }
}
