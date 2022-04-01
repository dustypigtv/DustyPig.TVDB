using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class EpisodeBaseRecord
    {
        [JsonProperty("aired", NullValueHandling = NullValueHandling.Ignore)]
        public string Aired { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }

        [JsonProperty("imageType", NullValueHandling = NullValueHandling.Ignore)]
        public int ImageType { get; set; }

        [JsonProperty("isMovie", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsMovie { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("nameTranslations", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> NameTranslations { get; set; }

        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        public int Number { get; set; }

        [JsonProperty("overviewTranslations", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> OverviewTranslations { get; set; }

        [JsonProperty("runtime", NullValueHandling = NullValueHandling.Ignore)]
        public int Runtime { get; set; }

        [JsonProperty("seasonNumber", NullValueHandling = NullValueHandling.Ignore)]
        public int SeasonNumber { get; set; }

        [JsonProperty("seasons", NullValueHandling = NullValueHandling.Ignore)]
        public List<SeasonBaseRecord> Seasons { get; set; }

        [JsonProperty("seriesId", NullValueHandling = NullValueHandling.Ignore)]
        public int SeriesId { get; set; }
    }

}
