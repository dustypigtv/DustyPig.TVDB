using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class BiographyRecord
    {
        [JsonProperty("biography", NullValueHandling = NullValueHandling.Ignore)]
        public string Biography { get; set; }

        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }
    }

}
