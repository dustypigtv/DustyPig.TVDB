using DustyPig.TVDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace DustyPig.TVDB.Clients
{
    public class ContentRatingsClient
    {
        private readonly Client _client;

        internal ContentRatingsClient(Client client) => _client = client;

        public Task<Response<List<ContentRating>>> GetAllAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<ContentRating>>($"content/ratings", cancellationToken);

    }
}
