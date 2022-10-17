using DustyPig.TVDB.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class InspirationTypesClient
    {
        private readonly Client _client;

        internal InspirationTypesClient(Client client) => _client = client;


        public Task<Response<List<InspirationType>>> GetAllAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<InspirationType>>("inspiration/types", cancellationToken);


    }
}
