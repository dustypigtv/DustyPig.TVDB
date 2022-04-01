using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class Tag
    {
        [JsonProperty("allowsMultiple", NullValueHandling = NullValueHandling.Ignore)]
        public bool AllowsMultiple { get; set; }

        [JsonProperty("helpText", NullValueHandling = NullValueHandling.Ignore)]
        public string HelpText { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("options", NullValueHandling = NullValueHandling.Ignore)]
        public List<TagOption> Options { get; set; }
    }

}
