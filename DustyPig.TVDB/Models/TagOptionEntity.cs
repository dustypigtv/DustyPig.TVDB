using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class TagOptionEntity
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("tagName", NullValueHandling = NullValueHandling.Ignore)]
        public string TagName { get; set; }

        [JsonProperty("tagId", NullValueHandling = NullValueHandling.Ignore)]
        public int TagId { get; set; }
    }

}
