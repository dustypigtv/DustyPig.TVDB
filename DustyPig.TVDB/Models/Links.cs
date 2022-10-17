using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class Links
    {
        [JsonProperty("prev", NullValueHandling = NullValueHandling.Ignore)]
        public string Prev { get; set; }

        [JsonProperty("self", NullValueHandling = NullValueHandling.Ignore)]
        public string Self { get; set; }

        [JsonProperty("next", NullValueHandling = NullValueHandling.Ignore)]
        public string Next { get; set; }

        [JsonProperty("total_items", NullValueHandling = NullValueHandling.Ignore)]
        public int TotalItems { get; set; }

        [JsonProperty("page_size", NullValueHandling = NullValueHandling.Ignore)]
        public int PageSize { get; set; }
    }

}
