using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class EntityUpdate
    {
        [JsonProperty("entityType", NullValueHandling = NullValueHandling.Ignore)]
        public string EntityType { get; set; }

        [JsonProperty("method", NullValueHandling = NullValueHandling.Ignore)]
        public string Method { get; set; }

        [JsonProperty("recordId", NullValueHandling = NullValueHandling.Ignore)]
        public int RecordId { get; set; }

        [JsonProperty("timeStamp", NullValueHandling = NullValueHandling.Ignore)]
        public long TimeStamp { get; set; }

        /// <summary>Only present for episodes records</summary>
        [JsonProperty("seriesId", NullValueHandling = NullValueHandling.Ignore)]
        public int SeriesId { get; set; }
    }

}
