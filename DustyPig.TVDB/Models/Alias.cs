using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class Alias
    {
        /// <summary>A 3-4 character string indicating the language of the alias, as defined in Language.</summary>
        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }

        /// <summary>A string containing the alias itself.</summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

}
