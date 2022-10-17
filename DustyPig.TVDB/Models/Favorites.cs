using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class Favorites
    {
        [JsonProperty("series")]
        public List<int> Series { get; set; } = new List<int>();

        [JsonProperty("episodes")]
        public List<int> Episodes { get; set; } = new List<int>();

        [JsonProperty("artwork")]
        public List<int> Artwork { get; set; } = new List<int>();

        [JsonProperty("people")]
        public List<int> People { get; set; } = new List<int>();

        [JsonProperty("movies")]
        public List<int> Movies { get; set; } = new List<int>();

        [JsonProperty("lists")]
        public List<int> Lists { get; set; } = new List<int>();
    }
}
