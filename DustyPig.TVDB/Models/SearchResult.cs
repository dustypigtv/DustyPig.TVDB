using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class SearchResult
    {
        public List<string> Aliases { get; set; } = new List<string>();

        public List<string> Companies { get; set; } = new List<string>();

        public string CompanyType { get; set; }

        public string Country { get; set; }

        public string Director { get; set; }

        [JsonProperty("extended_title")]
        public string ExtendedTitle { get; set; }

        [JsonProperty("first_air_time")]
        public string FirstAirTime { get; set; }

        public List<string> Genres { get; set; } = new List<string>();

        public string Id { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        public string Name { get; set; }

        [JsonProperty("is_official")]
        public bool IsOfficial { get; set; }

        public string NameTranslated { get; set; }

        public string Network { get; set; }

        public string ObjectId { get; set; }

        public string OfficialList { get; set; }

        public string Overview { get; set; }

        /// <summary>
        /// Key is language code, value is overview
        /// </summary>
        public Dictionary<string, string> Overviews { get; set; } = new Dictionary<string, string>();

        [JsonProperty("overview_translated")]
        public List<string> OverviewTranslated { get; set; } = new List<string>();

        public string Poster { get; set; }

        public List<string> Posters { get; set; } = new List<string>();

        [JsonProperty("primary_language")]
        public string PrimaryLanguage { get; set; }

        [JsonProperty("primary_type")]
        public string PrimaryType { get; set; }

        [JsonProperty("remote_ids")]
        public List<RemoteId> RemoteIds { get; set; } = new List<RemoteId>();

        public string Status { get; set; }

        public string Slug { get; set; }

        public List<string> Studios { get; set; } = new List<string>();

        public string Title { get; set; }

        public string Thumbnail { get; set; }

        /// <summary>
        /// Key is language code, value is overview
        /// </summary>
        public Dictionary<string, string> Translations { get; set; } = new Dictionary<string, string>();


        public List<string> TranslationsWithLang { get; set; } = new List<string>();

        public int TVDB_Id { get; set; }

        public string Type { get; set; }

        public string Year { get; set; }

    }

}
