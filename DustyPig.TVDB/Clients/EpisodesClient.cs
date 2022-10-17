using DustyPig.TVDB.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class EpisodesClient
    {
        private readonly Client _client;

        internal EpisodesClient(Client client) => _client = client;

        /// <summary>
        /// Returns a list of <see cref="EpisodeBaseRecord"/>s with the basic attributes.
        /// Note that all episodes are returned, even those that may not be included in a series' default season order.
        /// </summary>
        public Task<Response<List<EpisodeBaseRecord>>> GetAllAsync(int page = 0, CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<EpisodeBaseRecord>>("episodes", page, cancellationToken);


        public Task<Response<EpisodeBaseRecord>> GetAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetAsync<EpisodeBaseRecord>($"episodes/{id}", cancellationToken);


        /// <summary>
        /// Returns a single <see cref="EpisodeExtendedRecord"/>
        /// </summary>
        /// <param name="id">Required</param>
        /// <param name="translations">Whether to include <see cref="TranslationExtended"/></param>
        public Task<Response<EpisodeExtendedRecord>> GetExtendedAsync(int id, bool translations = false, CancellationToken cancellationToken = default)
        {
            string url = $"episodes/{id}/extended";
            if (translations)
                url = Client.AddQuery(url, "meta=translations");
            return _client.GetAsync<EpisodeExtendedRecord>(url, cancellationToken);
        }


        public Task<Response<Translation>> GetTranslationAsync(int id, string language, CancellationToken cancellationToken = default) =>
            _client.GetAsync<Translation>($"episodes/{id}/translations/{language}", cancellationToken);
    }
}
