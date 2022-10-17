using DustyPig.TVDB.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class UpdatesClient
    {
        private readonly Client _client;

        internal UpdatesClient(Client client) => _client = client;

        public Task<Response<List<EntityUpdate>>> GetUpdatesAsync(DateTime since, UpdateTypes? type = null, Models.Action? action = null, int page = 0, CancellationToken cancellationToken = default)
        {
            string url = $"updates?since={since.ToUnixEpochTime()}";
            if (type != null)
                url += $"&type={type.ConvertToString()}";

            if (action != null)
                url += $"&action={action.ConvertToString()}";

            return _client.GetAsync<List<EntityUpdate>>(url, page, cancellationToken);
        }

    }
}
