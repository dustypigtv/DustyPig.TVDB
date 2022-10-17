using DustyPig.TVDB.Models;
using System.Threading.Tasks;
using System.Threading;

namespace DustyPig.TVDB.Clients
{
    public class EpisodesClient
    {
        private readonly Client _client;

        internal EpisodesClient(Client client) => _client = client;

        
        public Task<Response<EpisodeBaseRecord>> GetAllAsync(int page = 0, CancellationToken cancellationToken = default) =>
            _client.GetAsync<EpisodeBaseRecord>("episodes", page, cancellationToken);


        public Task<Response<EpisodeBaseRecord>> GetAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetAsync<EpisodeBaseRecord>($"episodes/{id}", cancellationToken);


        public Task<Response<EpisodeExtendedRecord>> GetExtendedAsync(int id, Meta? meta = null, CancellationToken cancellationToken = default)
        {
            string url = $"episodes/{id}/extended";
            if (meta != null)
                url += $"?meta={meta.ConvertToString()}";
            return _client.GetAsync<EpisodeExtendedRecord>(url, cancellationToken);
        }


        public Task<Response<Translation>> GetTranslationAsync(int id, string language, CancellationToken cancellationToken = default) =>
            _client.GetAsync<Translation>($"episodes/{id}/translations/{language}", cancellationToken);

    }
}
