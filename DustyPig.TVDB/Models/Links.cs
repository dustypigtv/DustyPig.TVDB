using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class Links
    {
        public string Prev { get; set; }

        public string Self { get; set; }

        public string Next { get; set; }

        [JsonProperty("total_items")]
        public int TotalItems { get; set; }

        [JsonProperty("page_size")]
        public int PageSize { get; set; }
    }

}
