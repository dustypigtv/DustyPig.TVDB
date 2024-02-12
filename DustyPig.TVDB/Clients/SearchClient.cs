using DustyPig.TVDB.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class SearchClient
    {
        private readonly Client _client;

        internal SearchClient(Client client) => _client = client;

        /// <summary>
        /// Our search index includes series, movies, people, and companies. Search is limited to 5k results max.
        /// </summary>
        /// <param name="query">The primary search string, which can include the main title for a record including all translations and aliases.</param>
        /// <param name="type">Restrict results to a specific entity type. Can be movie, series, person, or company.</param>
        /// <param name="year">Restrict results to a specific year. Currently only used for series and movies.</param>
        /// <param name="company">Restrict results to a specific company (original network, production company, studio, etc). As an example, "The Walking Dead" would have companies of "AMC", "AMC+", and "Disney+".</param>
        /// <param name="country">Restrict results to a specific country of origin. Should contain a 3 character country code. Currently only used for series and movies.</param>
        /// <param name="director">Restrict results to a specific director. Generally only used for movies. Should include the full name of the director, such as "Steven Spielberg".</param>
        /// <param name="language">Restrict results to a specific primary language. Should include the 3 character language code. Currently only used for series and movies.</param>
        /// <param name="primaryType">Restrict results to a specific type of company. Should include the full name of the type of company, such as "Production Company". Only used for companies.</param>
        /// <param name="network">Restrict results to a specific network. Used for TV and TV movies, and functions the same as the company parameter with more specificity.</param>
        /// <param name="remote_id">Search for a specific remote id. Allows searching for an IMDB or EIDR id, for example.</param>
        /// <param name="offset">Offset results.</param>
        /// <param name="limit">Limit results.</param>
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

        /// <summary>
        /// Search a series, movie, people, episode, company or season by specific reomote id
        /// </summary>
        /// <param name="remote_id">Search for a specific remote id. Allows searching for an IMDB or EIDR id, for example.</param>
        public Task<Response<List<SearchByRemoteIdResult>>> SearchByRemoteIdAsync(string remote_id, CancellationToken cancellationToken = default) =>
            _client.GetAsync<List<SearchByRemoteIdResult>>("search/remoteid/" + Uri.EscapeDataString(remote_id), cancellationToken);
    }
}
