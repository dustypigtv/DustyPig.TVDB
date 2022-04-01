using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class Translation
    {
        [JsonProperty("aliases", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Aliases { get; set; }

        [JsonProperty("isAlias", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsAlias { get; set; }

        [JsonProperty("isPrimary", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsPrimary { get; set; }

        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("overview", NullValueHandling = NullValueHandling.Ignore)]
        public string Overview { get; set; }

        /// <summary>Only populated for movie translations.  We disallow taglines without a title.</summary>
        [JsonProperty("tagline", NullValueHandling = NullValueHandling.Ignore)]
        public string Tagline { get; set; }
    }

}
