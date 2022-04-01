using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class SeriesBaseRecord
    {
        [JsonProperty("abbreviation", NullValueHandling = NullValueHandling.Ignore)]
        public string Abbreviation { get; set; }

        [JsonProperty("aliases", NullValueHandling = NullValueHandling.Ignore)]
        public List<Alias> Aliases { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("defaultSeasonType", NullValueHandling = NullValueHandling.Ignore)]
        public int DefaultSeasonType { get; set; }

        [JsonProperty("firstAired", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstAired { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }

        [JsonProperty("isOrderRandomized", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsOrderRandomized { get; set; }

        [JsonProperty("lastAired", NullValueHandling = NullValueHandling.Ignore)]
        public string LastAired { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("nameTranslations", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> NameTranslations { get; set; }

        [JsonProperty("nextAired", NullValueHandling = NullValueHandling.Ignore)]
        public string NextAired { get; set; }

        [JsonProperty("originalCountry", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalCountry { get; set; }

        [JsonProperty("originalLanguage", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalLanguage { get; set; }

        [JsonProperty("overviewTranslations", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> OverviewTranslations { get; set; }

        [JsonProperty("score", NullValueHandling = NullValueHandling.Ignore)]
        public double Score { get; set; }

        [JsonProperty("slug", NullValueHandling = NullValueHandling.Ignore)]
        public string Slug { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public Status Status { get; set; }
    }

}
