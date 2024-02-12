using DustyPig.TVDB.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class LoginClient
    {
        private readonly Client _client;
        private readonly Dictionary<string, string> _headers;

        internal LoginClient(Client client, Dictionary<string, string> headers)
        {
            _client = client;
            _headers = headers;
        }

        /// <summary>
        /// Sets the auth token without calling the <see cref="LoginAsync"/> api. Used for setting tokens that are stored locally
        /// </summary>
        public void SetAuthToken(string token)
        {
            _headers.Clear();
            _headers.Add("Authorization", "Bearer " + token);
        }


        /// <summary>
        /// Create an auth token. The token has one month valition length. If successfull, this automatically calls <see cref="SetAuthToken(string)"/>
        /// </summary>
        public async Task<Response<BearerToken>> LoginAsync(Credentials credentials, CancellationToken cancellationToken = default)
        {
            _headers.Clear();
            var response = await _client.PostAsync<BearerToken>("login", credentials, cancellationToken).ConfigureAwait(false);
            if (response.Success)
                SetAuthToken(response.Data.Token);
            return response;
        }
    }
}
