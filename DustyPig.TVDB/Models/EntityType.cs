using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class EntityType
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("seriesId", NullValueHandling = NullValueHandling.Ignore)]
        public int SeriesId { get; set; }
    }

}
