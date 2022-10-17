using DustyPig.TVDB.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class ArtworkStatusesClient
    {
        private readonly Client _client;

        internal ArtworkStatusesClient(Client client) => _client = client;

        public Task<Response<List<ArtworkStatus>>> GetAllAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<ArtworkStatus>>("artwork/statuses", cancellationToken);

    }
}
