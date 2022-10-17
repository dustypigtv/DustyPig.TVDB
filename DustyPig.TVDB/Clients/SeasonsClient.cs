using DustyPig.TVDB.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class SeasonsClient
    {
        private readonly Client _client;

        internal SeasonsClient(Client client) => _client = client;

        public Task<Response<List<SeasonBaseRecord>>> GetAllAsync(int page = 0, CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<SeasonBaseRecord>>("seasons", page, cancellationToken);

        public Task<Response<SeasonBaseRecord>> GetAsync(int id, CancellationToken cancellationToken = default) =>
           _client.GetAsync<SeasonBaseRecord>($"seasons/{id}", cancellationToken);


        public Task<Response<SeasonExtendedRecord>> GetExtendedAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetAsync<SeasonExtendedRecord>($"seasons/{id}/extended", cancellationToken);


        public Task<Response<List<SeasonType>>> GetAllTypesAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<SeasonType>>("seasons/types", cancellationToken);


        public Task<Response<Translation>> GetTranslationAsync(int id, string language, CancellationToken cancellationToken = default) =>
            _client.GetAsync<Translation>($"seasons/{id}/translations/{language}", cancellationToken);

    }
}
