using Newtonsoft.Json;
using System;
using System.Net;

namespace DustyPig.TVDB.Models
{    
    public class Response<T>
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; set; }

        [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
        public Links Links { get; set; }

        public bool Success { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string ReasonPhrase { get; set; }

        public string RawContent { get; set; }

        public Exception Error { get; set; }

        public void ThrowIfError()
        {
            if (!Success)
                throw Error;
        }
    }
}
