using DustyPig.TVDB.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class SeriesStatusesClient
    {
        private readonly Client _client;

        internal SeriesStatusesClient(Client client) => _client = client;

        public Task<Response<List<Status>>> GetAllAsync(CancellationToken cancellationToken = default) =>
           _client.GetAsync<List<Status>>("series/statuses", cancellationToken);
    }
}
