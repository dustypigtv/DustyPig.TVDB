using DustyPig.TVDB.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class PeopleTypesClient
    {
        private readonly Client _client;

        internal PeopleTypesClient(Client client) => _client = client;

        public Task<Response<List<PeopleType>>> GetAllAsync(CancellationToken cancellationToken = default) =>
           _client.GetAsync<List<PeopleType>>("people/types", cancellationToken);

    }
}
