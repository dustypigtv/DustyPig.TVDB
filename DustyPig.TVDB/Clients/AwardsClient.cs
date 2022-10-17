using DustyPig.TVDB.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class AwardsClient
    {
        private readonly Client _client;

        internal AwardsClient(Client client) => _client = client;

        public Task<Response<List<AwardBaseRecord>>> GetAllAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<AwardBaseRecord>>("awards", cancellationToken);

        public Task<Response<AwardBaseRecord>> GetAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetAsync<AwardBaseRecord>($"awards/{id}", cancellationToken);


        public Task<Response<AwardExtendedRecord>> GetExtendedAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetAsync<AwardExtendedRecord>($"awards/{id}/extended", cancellationToken);
    }
}
