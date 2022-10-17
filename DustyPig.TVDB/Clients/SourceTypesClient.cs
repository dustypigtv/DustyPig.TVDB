using DustyPig.TVDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace DustyPig.TVDB.Clients
{
    public class SourceTypesClient
    {
        private readonly Client _client;

        internal SourceTypesClient(Client client) => _client = client;

        public Task<Response<List<SourceType>>> GetAllAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<SourceType>>("sources/types", cancellationToken);

    }
}
