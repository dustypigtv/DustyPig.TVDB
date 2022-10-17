using DustyPig.TVDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace DustyPig.TVDB.Clients
{
    public class SearchClient
    {
        private readonly Client _client;

        internal SearchClient(Client client) => _client = client;

        public Task<Response<List<SearchResult>>> SearchAsync(string query = null, SearchTypes? type = null, int? year = null, string company = null, string country = null, string director = null, string language = null, string primaryType = null, string network = null, string remote_id = null, int? offset = null, int? limit = null, CancellationToken cancellationToken = default)
        {
            string url = "search?query=" + Uri.EscapeDataString(query);

            if (type != null)
                url += "&type=" + type.ConvertToString();

            if (year != null)
                url += $"&year{year}";

            if (!string.IsNullOrWhiteSpace(company))
                url += $"&company=" + Uri.EscapeDataString(company.Trim());

            if (!string.IsNullOrWhiteSpace(country))
                url += $"&country=" + Uri.EscapeDataString(country.Trim());

            if (!string.IsNullOrWhiteSpace(director))
                url += $"&director=" + Uri.EscapeDataString(director.Trim());

            if (!string.IsNullOrWhiteSpace(language))
                url += $"&language=" + Uri.EscapeDataString(language.Trim());

            if (!string.IsNullOrWhiteSpace(primaryType))
                url += $"&primaryType=" + Uri.EscapeDataString(primaryType.Trim());

            if (!string.IsNullOrWhiteSpace(network))
                url += $"&network=" + Uri.EscapeDataString(network.Trim());

            if (!string.IsNullOrWhiteSpace(remote_id))
                url += "&remote_id=" + Uri.EscapeDataString(remote_id);

            if (offset != null)
                url += $"&offset={offset}";

            if (limit != null)
                url += $"&limit={limit}";

            return _client.GetAsync<List<SearchResult>>(url, cancellationToken);
        }

        public Task<Response<List<SearchResult>>> SearchByRemoteIdAsync(string remote_id, CancellationToken cancellationToken = default)
        {
            string url = "search?remoteId=" + Uri.EscapeDataString(remote_id);
            return _client.GetAsync<List<SearchResult>>(url, cancellationToken);
        }

    }
}
