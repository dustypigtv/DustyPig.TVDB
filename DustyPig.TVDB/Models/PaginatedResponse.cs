using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class PaginatedResponse<T> : SingleResponse<T>
    {
        [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
        public Links Links { get; set; }
    }
}
