using DustyPig.TVDB.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class PeopleClient
    {
        private readonly Client _client;

        internal PeopleClient(Client client) => _client = client;

        public Task<Response<List<PeopleBaseRecord>>> GetAllAsync(int page, CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<PeopleBaseRecord>>("people", page, cancellationToken);

        public Task<Response<PeopleBaseRecord>> GetAsync(int id, CancellationToken cancellationToken = default) =>
            _client.GetAsync<PeopleBaseRecord>($"people/{id}", cancellationToken);


        public Task<Response<PeopleExtendedRecord>> GetExtendedAsync(int id, bool translations = false, CancellationToken cancellationToken = default)
        {
            string url = $"people/{id}/extended";
            if (translations)
                url += "?meta=translations";
            return _client.GetAsync<PeopleExtendedRecord>(url, cancellationToken);
        }

        public Task<Response<Translation>> GetTranslationAsync(int id, string language, CancellationToken cancellationToken = default) =>
            _client.GetAsync<Translation>($"people/{id}/translations/{language}", cancellationToken);
    }
}
