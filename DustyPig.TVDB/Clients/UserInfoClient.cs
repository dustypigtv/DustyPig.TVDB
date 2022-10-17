using DustyPig.TVDB.Models;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class UserInfoClient
    {
        private readonly Client _client;

        internal UserInfoClient(Client client) => _client = client;

        public Task<Response<UserInfo>> GetAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<UserInfo>("user", cancellationToken);

        public Task<Response<UserInfo>> GetAsync(long id, CancellationToken cancellationToken = default) =>
                _client.GetAsync<UserInfo>($"user/{id}", cancellationToken);
    }
}
