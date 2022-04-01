using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class SeriesAirsDays
    {
        [JsonProperty("friday", NullValueHandling = NullValueHandling.Ignore)]
        public bool Friday { get; set; }

        [JsonProperty("monday", NullValueHandling = NullValueHandling.Ignore)]
        public bool Monday { get; set; }

        [JsonProperty("saturday", NullValueHandling = NullValueHandling.Ignore)]
        public bool Saturday { get; set; }

        [JsonProperty("sunday", NullValueHandling = NullValueHandling.Ignore)]
        public bool Sunday { get; set; }

        [JsonProperty("thursday", NullValueHandling = NullValueHandling.Ignore)]
        public bool Thursday { get; set; }

        [JsonProperty("tuesday", NullValueHandling = NullValueHandling.Ignore)]
        public bool Tuesday { get; set; }

        [JsonProperty("wednesday", NullValueHandling = NullValueHandling.Ignore)]
        public bool Wednesday { get; set; }
    }

}
