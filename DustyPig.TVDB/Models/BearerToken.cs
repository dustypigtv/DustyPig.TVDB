using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class BearerToken
    {
        [JsonProperty("token", NullValueHandling = NullValueHandling.Ignore)]
        public string Token { get; set; }
    }

}
