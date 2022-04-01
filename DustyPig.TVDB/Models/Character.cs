using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class Character
    {
        [JsonProperty("aliases", NullValueHandling = NullValueHandling.Ignore)]
        public List<Alias> Aliases { get; set; }

        [JsonProperty("episodeId", NullValueHandling = NullValueHandling.Ignore)]
        public int EpisodeId { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }

        [JsonProperty("isFeatured", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsFeatured { get; set; }

        [JsonProperty("movieId", NullValueHandling = NullValueHandling.Ignore)]
        public int MovieId { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("nameTranslations", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> NameTranslations { get; set; }

        [JsonProperty("overviewTranslations", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> OverviewTranslations { get; set; }

        [JsonProperty("peopleId", NullValueHandling = NullValueHandling.Ignore)]
        public int PeopleId { get; set; }

        [JsonProperty("seriesId", NullValueHandling = NullValueHandling.Ignore)]
        public int SeriesId { get; set; }

        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public int Sort { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public int Type { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("personName", NullValueHandling = NullValueHandling.Ignore)]
        public string PersonName { get; set; }
    }

}
