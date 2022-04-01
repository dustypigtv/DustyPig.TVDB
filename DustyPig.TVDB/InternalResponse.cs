using DustyPig.TVDB.Models;
using Newtonsoft.Json;

namespace DustyPig.TVDB
{
    class InternalResponse<T>
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
        internal Links Links { get; set; }
    }

}
