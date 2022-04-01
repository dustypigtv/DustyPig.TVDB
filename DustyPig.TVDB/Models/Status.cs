using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class Status
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("keepUpdated", NullValueHandling = NullValueHandling.Ignore)]
        public bool KeepUpdated { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("recordType", NullValueHandling = NullValueHandling.Ignore)]
        public string RecordType { get; set; }
    }

}
