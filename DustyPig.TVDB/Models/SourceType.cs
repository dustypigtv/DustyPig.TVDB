using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class SourceType
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("postfix", NullValueHandling = NullValueHandling.Ignore)]
        public string Postfix { get; set; }

        [JsonProperty("prefix", NullValueHandling = NullValueHandling.Ignore)]
        public string Prefix { get; set; }

        [JsonProperty("slug", NullValueHandling = NullValueHandling.Ignore)]
        public string Slug { get; set; }

        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public int Sort { get; set; }
    }

}
