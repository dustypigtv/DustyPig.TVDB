using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class TagOption
    {
        [JsonProperty("helpText", NullValueHandling = NullValueHandling.Ignore)]
        public string HelpText { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("tag", NullValueHandling = NullValueHandling.Ignore)]
        public int Tag { get; set; }

        [JsonProperty("tagName", NullValueHandling = NullValueHandling.Ignore)]
        public string TagName { get; set; }
    }

}
