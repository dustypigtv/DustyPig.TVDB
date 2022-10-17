using DustyPig.TVDB.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class ArtworkTypesClient
    {
        private readonly Client _client;

        internal ArtworkTypesClient(Client client) => _client = client;

        public Task<Response<List<ArtworkType>>> GetAllAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<ArtworkType>>("artwork/types", cancellationToken);

    }
}
