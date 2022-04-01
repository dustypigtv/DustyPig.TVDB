using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class SearchResult
    {
        [JsonProperty("aliases", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Aliases { get; set; }

        [JsonProperty("companies", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Companies { get; set; }

        [JsonProperty("companyType", NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyType { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("director", NullValueHandling = NullValueHandling.Ignore)]
        public string Director { get; set; }

        [JsonProperty("extendedTitle", NullValueHandling = NullValueHandling.Ignore)]
        public string ExtendedTitle { get; set; }

        [JsonProperty("genres", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Genres { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("imageUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageUrl { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("nameTranslated", NullValueHandling = NullValueHandling.Ignore)]
        public string NameTranslated { get; set; }

        [JsonProperty("officialList", NullValueHandling = NullValueHandling.Ignore)]
        public string OfficialList { get; set; }

        [JsonProperty("overview", NullValueHandling = NullValueHandling.Ignore)]
        public string Overview { get; set; }

        [JsonProperty("overview_translated", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> OverviewTranslated { get; set; }

        [JsonProperty("posters", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Posters { get; set; }

        [JsonProperty("primaryLanguage", NullValueHandling = NullValueHandling.Ignore)]
        public string PrimaryLanguage { get; set; }

        [JsonProperty("primaryType", NullValueHandling = NullValueHandling.Ignore)]
        public string PrimaryType { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("translationsWithLang", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> TranslationsWithLang { get; set; }

        [JsonProperty("tvdb_id", NullValueHandling = NullValueHandling.Ignore)]
        public int TVDB_Id { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("year", NullValueHandling = NullValueHandling.Ignore)]
        public string Year { get; set; }

        [JsonProperty("thumbnail", NullValueHandling = NullValueHandling.Ignore)]
        public string Thumbnail { get; set; }

        [JsonProperty("poster", NullValueHandling = NullValueHandling.Ignore)]
        public string Poster { get; set; }

        [JsonProperty("translations", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Translations { get; set; }

        [JsonProperty("is_official", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsOfficial { get; set; }

        [JsonProperty("remoteIds", NullValueHandling = NullValueHandling.Ignore)]
        public List<RemoteID> RemoteIds { get; set; }

        [JsonProperty("network", NullValueHandling = NullValueHandling.Ignore)]
        public string Network { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("overviews", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Overviews { get; set; }
    }

}
