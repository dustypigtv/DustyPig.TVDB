using DustyPig.TVDB.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class EntityTypesClient
    {
        private readonly Client _client;

        internal EntityTypesClient(Client client) => _client = client;

        public Task<Response<List<EntityType>>> GetAllAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<EntityType>>("entities", cancellationToken);


    }
}
