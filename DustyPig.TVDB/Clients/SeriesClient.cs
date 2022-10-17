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


        public Task<Response<Translation>> GetSeriesTranslationAsync(int id, string language, CancellationToken cancellationToken = default) =>
            _client.GetAsync<Translation>($"series/{id}/translations/{language}", cancellationToken);


        public Task<Response<List<Status>>> GetAllSeriesStatusesAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<Status>>("series/statuses", cancellationToken);

    }
}
