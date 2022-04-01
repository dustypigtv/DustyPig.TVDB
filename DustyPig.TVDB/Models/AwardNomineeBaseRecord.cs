using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class AwardNomineeBaseRecord
    {
        [JsonProperty("character", NullValueHandling = NullValueHandling.Ignore)]
        public Character Character { get; set; }

        [JsonProperty("details", NullValueHandling = NullValueHandling.Ignore)]
        public string Details { get; set; }

        [JsonProperty("episode", NullValueHandling = NullValueHandling.Ignore)]
        public EpisodeBaseRecord Episode { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("isWinner", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsWinner { get; set; }

        [JsonProperty("movie", NullValueHandling = NullValueHandling.Ignore)]
        public MovieBaseRecord Movie { get; set; }

        [JsonProperty("series", NullValueHandling = NullValueHandling.Ignore)]
        public SeriesBaseRecord Series { get; set; }

        [JsonProperty("year", NullValueHandling = NullValueHandling.Ignore)]
        public string Year { get; set; }

        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

}
