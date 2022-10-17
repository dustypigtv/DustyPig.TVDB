using DustyPig.TVDB.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class GenresClient
    {
        private readonly Client _client;

        internal GenresClient(Client client) => _client = client;

        public Task<Response<List<GenreBaseRecord>>> GetAllAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<GenreBaseRecord>>("genres", cancellationToken);


        public Task<Response<GenreBaseRecord>> GetAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetAsync<GenreBaseRecord>($"genres/{id}", cancellationToken);

    }
}
