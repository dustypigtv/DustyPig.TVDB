using DustyPig.TVDB.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class ListsClient
    {
        private readonly Client _client;

        internal ListsClient(Client client) => _client = client;

        public Task<Response<List<ListBaseRecord>>> GetAllAsync(int page = 0, CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<ListBaseRecord>>("lists", page, cancellationToken);

        public Task<Response<ListBaseRecord>> GetAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetAsync<ListBaseRecord>($"lists/{id}", cancellationToken);


        public Task<Response<ListBaseRecord>> GetAsync(string slug, CancellationToken cancellationToken = default) =>
            _client.GetAsync<ListBaseRecord>($"lists/{slug}", cancellationToken);


        public Task<Response<ListExtendedRecord>> GetExtendedAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetAsync<ListExtendedRecord>($"lists/{id}/extended", cancellationToken);

        public Task<Response<Translation>> GetListTranslationAsync(int id, string language, CancellationToken cancellationToken = default) =>
            _client.GetAsync<Translation>($"lists/{id}/translations/{language}", cancellationToken);
    }
}
