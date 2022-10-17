using DustyPig.TVDB.Models;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class FavoritesClient
    {
        private readonly Client _client;

        internal FavoritesClient(Client client) => _client = client;

        public Task<Response<Favorites>> GetAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<Favorites>("user/favorites", cancellationToken);

        public Task<Response<string>> AddNewAsync(NewFavorites newFavorites, CancellationToken cancellationToken = default) =>
            _client.PostAsync<string>("user/favorites", newFavorites, cancellationToken);
    }
}
