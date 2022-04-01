using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class AwardCategoryBaseRecord
    {
        [JsonProperty("allowCoNominees", NullValueHandling = NullValueHandling.Ignore)]
        public bool AllowCoNominees { get; set; }

        [JsonProperty("award", NullValueHandling = NullValueHandling.Ignore)]
        public AwardBaseRecord Award { get; set; }

        [JsonProperty("forMovies", NullValueHandling = NullValueHandling.Ignore)]
        public bool ForMovies { get; set; }

        [JsonProperty("forSeries", NullValueHandling = NullValueHandling.Ignore)]
        public bool ForSeries { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

}
