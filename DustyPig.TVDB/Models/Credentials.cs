using System.Text.Json.Serialization;

namespace DustyPig.TVDB.Models
{
    public class Credentials
    {
#if NET7_0_OR_GREATER
        [JsonRequired]
#endif
        [JsonPropertyName("apikey")]
        public string Apikey { get; set; }

        [JsonPropertyName("pin")]
        public string Pin { get; set; }
    }

}
