using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class SeasonBaseRecord
    {
        [JsonProperty("abbreviation", NullValueHandling = NullValueHandling.Ignore)]
        public string Abbreviation { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }

        [JsonProperty("imageType", NullValueHandling = NullValueHandling.Ignore)]
        public int ImageType { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("nameTranslations", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> NameTranslations { get; set; }

        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        public int Number { get; set; }

        [JsonProperty("overviewTranslations", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> OverviewTranslations { get; set; }

        [JsonProperty("seriesId", NullValueHandling = NullValueHandling.Ignore)]
        public int SeriesId { get; set; }

        [JsonProperty("slug", NullValueHandling = NullValueHandling.Ignore)]
        public string Slug { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public SeasonType Type { get; set; }
    }

}
