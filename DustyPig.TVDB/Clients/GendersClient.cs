using DustyPig.TVDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace DustyPig.TVDB.Clients
{
    public class GendersClient
    {
        private readonly Client _client;

        internal GendersClient(Client client) => _client = client;

        public Task<Response<List<Gender>>> GetAllAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<Gender>>("genders", cancellationToken);

    }
}
