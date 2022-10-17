using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class SingleResponseWithLinks<T> : SingleResponse<T>
    {
        [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
        public Links Links { get; set; }
    }
}
