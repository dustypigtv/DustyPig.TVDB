using DustyPig.TVDB.Models;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class AwardCategoriesClient
    {
        private readonly Client _client;

        internal AwardCategoriesClient(Client client) => _client = client;


        public Task<Response<AwardCategoryBaseRecord>> GetAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetAsync<AwardCategoryBaseRecord>($"awards/categories/{id}", cancellationToken);


        public Task<Response<AwardCategoryExtendedRecord>> GetExtendedAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetAsync<AwardCategoryExtendedRecord>($"awards/categories/{id}/extended", cancellationToken);
    }
}
