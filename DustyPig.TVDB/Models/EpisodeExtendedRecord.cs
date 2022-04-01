using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class EpisodeExtendedRecord : EpisodeBaseRecord
    {
        [JsonProperty("airsAfterSeason", NullValueHandling = NullValueHandling.Ignore)]
        public int AirsAfterSeason { get; set; }

        [JsonProperty("airsBeforeEpisode", NullValueHandling = NullValueHandling.Ignore)]
        public int AirsBeforeEpisode { get; set; }

        [JsonProperty("airsBeforeSeason", NullValueHandling = NullValueHandling.Ignore)]
        public int AirsBeforeSeason { get; set; }

        [JsonProperty("awards", NullValueHandling = NullValueHandling.Ignore)]
        public List<AwardBaseRecord> Awards { get; set; }

        [JsonProperty("characters", NullValueHandling = NullValueHandling.Ignore)]
        public List<Character> Characters { get; set; }

        [JsonProperty("contentRatings", NullValueHandling = NullValueHandling.Ignore)]
        public List<ContentRating> ContentRatings { get; set; }

        [JsonProperty("network", NullValueHandling = NullValueHandling.Ignore)]
        public NetworkBaseRecord Network { get; set; }

        [JsonProperty("productionCode", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductionCode { get; set; }

        [JsonProperty("remoteIds", NullValueHandling = NullValueHandling.Ignore)]
        public List<RemoteID> RemoteIds { get; set; }

        [JsonProperty("tagOptions", NullValueHandling = NullValueHandling.Ignore)]
        public List<TagOption> TagOptions { get; set; }

        [JsonProperty("trailers", NullValueHandling = NullValueHandling.Ignore)]
        public List<Trailer> Trailers { get; set; }
    }

}
