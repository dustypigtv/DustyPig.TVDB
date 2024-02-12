using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DustyPig.TVDB.Models
{
    public class SearchResult
    {
        public List<string> Aliases { get; set; } = [];

        public List<string> Companies { get; set; } = [];

        public string CompanyType { get; set; }

        public string Country { get; set; }

        public string Director { get; set; }

        [JsonPropertyName("extended_title")]
        public string ExtendedTitle { get; set; }

        [JsonPropertyName("first_air_time")]
        public string FirstAirTime { get; set; }

        public List<string> Genres { get; set; } = [];

        public string Id { get; set; }

        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("is_official")]
        public bool IsOfficial { get; set; }

        public string NameTranslated { get; set; }

        public string Network { get; set; }

        public string ObjectId { get; set; }

        public string OfficialList { get; set; }

        public string Overview { get; set; }

        /// <summary>
        /// Key is language code, value is overview
        /// </summary>
        public Dictionary<string, string> Overviews { get; set; } = [];

        [JsonPropertyName("overview_translated")]
        public List<string> OverviewTranslated { get; set; } = [];

        public string Poster { get; set; }

        public List<string> Posters { get; set; } = [];

        [JsonPropertyName("primary_language")]
        public string PrimaryLanguage { get; set; }

        [JsonPropertyName("primary_type")]
        public string PrimaryType { get; set; }

        [JsonPropertyName("remote_ids")]
        public List<RemoteId> RemoteIds { get; set; } = [];

        public string Status { get; set; }

        public string Slug { get; set; }

        public List<string> Studios { get; set; } = [];

        public string Title { get; set; }

        public string Thumbnail { get; set; }

        /// <summary>
        /// Key is language code, value is overview
        /// </summary>
        public Dictionary<string, string> Translations { get; set; } = [];


        public List<string> TranslationsWithLang { get; set; } = [];

        public int TVDB_Id { get; set; }

        public string Type { get; set; }

        public string Year { get; set; }

    }

}
