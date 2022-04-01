using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class Entity
    {
        [JsonProperty("movieId", NullValueHandling = NullValueHandling.Ignore)]
        public int MovieId { get; set; }

        [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
        public int Order { get; set; }

        [JsonProperty("seriesId", NullValueHandling = NullValueHandling.Ignore)]
        public int SeriesId { get; set; }
    }

}
