using DustyPig.TVDB.Clients;
using DustyPig.TVDB.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DustyPig.TVDB
{
    public class Client
    {
        public const string API_VERSION = "4.7.1";
        public const string API_AS_OF_DATE = "10/16/2022";

        private static readonly HttpClient _httpClient = new HttpClient() { BaseAddress = new Uri("https://api4.thetvdb.com/v4/") };

        private readonly Dictionary<string, string> _headers;


        public Client()
        {
            _headers = new Dictionary<string, string>();

            Authentication = new AuthenticationClient(this, _headers);
            Artwork = new ArtworkClient(this);
            ArtworkStatuses = new ArtworkStatusesClient(this);
            ArtworkTypes = new ArtworkTypesClient(this);
            Awards = new AwardsClient(this);
        }

        public AuthenticationClient Authentication { get; }

        public ArtworkClient Artwork { get; }

        public ArtworkStatusesClient ArtworkStatuses { get; }

        public ArtworkTypesClient ArtworkTypes { get; }

        public AwardsClient Awards { get; }




        public bool IncludeRawContentInResponse { get; set; }

        public bool AutoThrowIfError { get; set; }




        private static HttpRequestMessage CreateRequest(HttpMethod method, string url, IDictionary<string, string> headers, object data)
        {
            var request = new HttpRequestMessage(method, url);
            if (headers != null)
                foreach (var header in headers)
                    request.Headers.Add(header.Key, header.Value);

            if (data != null)
                request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            return request;
        }

        private async Task<Response<T>> GetResponseAsync<T>(HttpMethod method, string subUrl, IDictionary<string, string> headers, object data, CancellationToken cancellationToken)
        {
            string content = null;
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            string reasonPhrase = null;
            try
            {
                using var request = CreateRequest(method, subUrl, headers, data);
                using var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
                statusCode = response.StatusCode;
                reasonPhrase = response.ReasonPhrase;
                content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                var ret = JsonConvert.DeserializeObject<Response<T>>(content);
                ret.ReasonPhrase = reasonPhrase;
                ret.Success = true;
                ret.RawContent = IncludeRawContentInResponse ? content : null;
                ret.StatusCode = statusCode;
                return ret;
            }
            catch (Exception ex)
            {
                var ret = string.IsNullOrWhiteSpace(reasonPhrase)
                    ? new Response<T> { Error = ex }
                    : new Response<T> { Error = new Exception(reasonPhrase, ex) };

                ret.StatusCode = statusCode;
                ret.ReasonPhrase = reasonPhrase;
                if (IncludeRawContentInResponse)
                    ret.RawContent = content;


                if (AutoThrowIfError)
                    ret.ThrowIfError();

                return ret;
            }
        }





        internal Task<Response<T>> GetAsync<T>(string subUrl, CancellationToken cancellationToken = default) =>
            GetResponseAsync<T>(HttpMethod.Get, subUrl, _headers, null, cancellationToken);

        internal Task<Response<T>> GetAsync<T>(string subUrl, int page, CancellationToken cancellationToken = default)
        {
            string pagedUrl = AddQuery(subUrl, $"page={page}");
            return GetResponseAsync<T>(HttpMethod.Get, pagedUrl, _headers, null, cancellationToken);
        }

        internal Task<Response<T>> PostAsync<T>(string subUrl, object data, CancellationToken cancellationToken) =>
            GetResponseAsync<T>(HttpMethod.Post, subUrl, _headers, data, cancellationToken);


        internal static string AddQuery(string url, string q)
        {
            return url + (url.Contains("?") ? "&" : "?") + q;
        }
    }
}