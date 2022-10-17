using DustyPig.TVDB.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Clients
{
    public class AuthenticationClient
    {
        private readonly Client _client;
        private readonly Dictionary<string, string> _headers;

        internal AuthenticationClient(Client client, Dictionary<string, string> headers)
        {
            _client = client;
            _headers = headers;
        }

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
