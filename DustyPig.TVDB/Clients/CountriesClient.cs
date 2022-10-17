using DustyPig.TVDB.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class CountriesClient
    {
        private readonly Client _client;

        internal CountriesClient(Client client) => _client = client;

        public Task<Response<List<Country>>> GetAllAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<Country>>("countries", cancellationToken);
    }
}
