using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class StudioBaseRecord
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("parentStudio", NullValueHandling = NullValueHandling.Ignore)]
        public int ParentStudio { get; set; }
    }

}
