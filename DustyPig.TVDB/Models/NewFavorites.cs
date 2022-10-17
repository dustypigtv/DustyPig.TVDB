using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class NewFavorites
    {
        [JsonProperty("series")]
        public int Series { get; set; }

        [JsonProperty("movies")]    
        public int Movies { get; set; }


        [JsonProperty("episodes")]
        public int Episodes { get; set; }

        [JsonProperty("artwork")]
        public int Artwork { get; set; }

        [JsonProperty("people")]
        public int People { get; set; }


        [JsonProperty("lists")]
        public int List { get; set; }
    }
}
