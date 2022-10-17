using DustyPig.TVDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;

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

        public Task<Response<SeriesExtendedRecord>> GetArtworksAsync(int id, string lang = null, int? type = null, CancellationToken cancellationToken = default)
        {
            string url = $"series{id}/artworks";

            if (!string.IsNullOrEmpty(lang))
                url += (url.Contains("?") ? "&" : "?") + $"lang={Uri.EscapeDataString(lang)}";

            if (type != null && type.Value > 0 && type.Value < 4)
                url += (url.Contains("?") ? "&" : "?") + $"type={type}";

            return _client.GetAsync<SeriesExtendedRecord>(url, cancellationToken);
        }

        public Task<Response<SeriesBaseRecord>> GetNextAiredAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetAsync<SeriesBaseRecord>($"series/{id}/nextAired", cancellationToken);


        public Task<Response<SeriesExtendedRecord>> GetExtendedAsync(int id, Meta? meta = null, CancellationToken cancellationToken = default)
        {
            string url = $"series/{id}/extended";
            if (meta != null)
                url += $"?meta={meta.ConvertToString()}";
            return _client.GetAsync<SeriesExtendedRecord>(url, cancellationToken);
        }

        public Task<Response<SeriesEpisodeData>> GetEpisodesAsync(int id, SeasonTypes season_type = SeasonTypes.Default, int page = 0, int? season = null, int? episodeNumber = null, CancellationToken cancellationToken = default)
        {
            string url = $"series/{id}/episodes/{season_type.ConvertToString()}";
            if (season != null)
                url += $"?season={season}";
            if (episodeNumber != null)
            {
                url += url.Contains("?") ? "&" : "?";
                url += $"episodeNumber={episodeNumber}";
            }

            return _client.GetAsync<SeriesEpisodeData>(url, page, cancellationToken);
        }

        public Task<Response<SeriesEpisodeData>> GetSeasonEpisodesTranslatedAsync(int id, SeasonTypes season_type, string lang, int page = 0, CancellationToken cancellationToken = default)
        {
            string url = $"series/{id}/episodes/{season_type.ConvertToString()}/{lang}";
            return _client.GetAsync<SeriesEpisodeData>(url, page, cancellationToken);
        }


        public Task<Response<List<SeriesBaseRecord>>> FilterAsync(string country, string lang, int? company = null, int? contentRating = null, int? genre = null, FilterSort? sort = null, SortType? sortType = null, int? status = null, int? year = null, CancellationToken cancellationToken = default)
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
