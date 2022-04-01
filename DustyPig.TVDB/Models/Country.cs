using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class Country
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("shortCode", NullValueHandling = NullValueHandling.Ignore)]
        public string ShortCode { get; set; }
    }

}
