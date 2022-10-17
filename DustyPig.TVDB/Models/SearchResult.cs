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

        public string ExtendedTitle { get; set; }

        public List<string> Genres { get; set; } = new List<string>();

        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string NameTranslated { get; set; }

        public string OfficialList { get; set; }

        public string Overview { get; set; }

        [JsonProperty("overview_translated")]
        public List<string> OverviewTranslated { get; set; } = new List<string>();

        public List<string> Posters { get; set; } = new List<string>();

        public string PrimaryLanguage { get; set; }

        public string PrimaryType { get; set; }

        public string Status { get; set; }

        public List<string> TranslationsWithLang { get; set; } = new List<string>();

        public int TVDB_Id { get; set; }

        public string Type { get; set; }

        public string Year { get; set; }

        public string Thumbnail { get; set; }

        public string Poster { get; set; }

        public Dictionary<string, object> Translations { get; set; } = new Dictionary<string, object>();

        [JsonProperty("is_official")]
        public bool IsOfficial { get; set; }

        public List<RemoteId> RemoteIds { get; set; } = new List<RemoteId>();

        public string Network { get; set; }

        public string Title { get; set; }

        public Dictionary<string, object> Overviews { get; set; } = new Dictionary<string, object>();
    }

}
