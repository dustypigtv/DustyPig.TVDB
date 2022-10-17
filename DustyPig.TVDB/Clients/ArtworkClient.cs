using DustyPig.TVDB.Models;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class ArtworkClient
    {
        private readonly Client _client;

        internal ArtworkClient(Client client) => _client = client;

        public Task<Response<ArtworkBaseRecord>> GetAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetAsync<ArtworkBaseRecord>($"artwork/{id}", cancellationToken);


        public Task<Response<ArtworkExtendedRecord>> GetExtendedAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetAsync<ArtworkExtendedRecord>($"artwork/{id}/extended", cancellationToken);
    }
}
