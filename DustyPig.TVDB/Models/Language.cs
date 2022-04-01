using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class Language
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("nativeName", NullValueHandling = NullValueHandling.Ignore)]
        public string NativeName { get; set; }

        [JsonProperty("shortCode", NullValueHandling = NullValueHandling.Ignore)]
        public string ShortCode { get; set; }
    }

}
