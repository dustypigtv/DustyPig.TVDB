using DustyPig.TVDB.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class LanguagesClient
    {
        private readonly Client _client;

        internal LanguagesClient(Client client) => _client = client;

        public Task<Response<List<Language>>> GetAllLanguagesAsync(CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<Language>>("languages", cancellationToken);

    }
}
