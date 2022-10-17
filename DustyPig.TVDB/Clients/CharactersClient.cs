using DustyPig.TVDB.Models;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class CharactersClient
    {
        private readonly Client _client;

        internal CharactersClient(Client client) => _client = client;

        public Task<Response<Character>> GetAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetAsync<Character>($"characters/{id}", cancellationToken);

    }
}
