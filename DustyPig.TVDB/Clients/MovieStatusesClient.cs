using DustyPig.TVDB.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class MovieStatusesClient
    {
        private readonly Client _client;

        internal MovieStatusesClient(Client client) => _client = client;

        public Task<Response<List<Status>>> GetAllAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<Status>>("movies/statuses", cancellationToken);
    }
}
