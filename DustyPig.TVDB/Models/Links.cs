using System.Text.Json.Serialization;

namespace DustyPig.TVDB.Models
{
    public class Links
    {
        public string Prev { get; set; }

        public string Self { get; set; }

        public string Next { get; set; }

        [JsonPropertyName("total_items")]
        public int TotalItems { get; set; }

        [JsonPropertyName("page_size")]
        public int PageSize { get; set; }
    }

}
