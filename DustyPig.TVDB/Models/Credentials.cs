using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class Credentials
    {
        [JsonProperty("apikey", Required = Required.Always)]
        public string Apikey { get; set; }

        [JsonProperty("pin", NullValueHandling = NullValueHandling.Ignore)]
        public string Pin { get; set; }
    }

}
