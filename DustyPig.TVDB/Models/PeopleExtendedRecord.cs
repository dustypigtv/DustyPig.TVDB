using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class PeopleExtendedRecord : PeopleBaseRecord
    {
        [JsonProperty("awards", NullValueHandling = NullValueHandling.Ignore)]
        public List<AwardBaseRecord> Awards { get; set; }

        [JsonProperty("biographies", NullValueHandling = NullValueHandling.Ignore)]
        public List<BiographyRecord> Biographies { get; set; }

        [JsonProperty("birth", NullValueHandling = NullValueHandling.Ignore)]
        public string Birth { get; set; }

        [JsonProperty("birthPlace", NullValueHandling = NullValueHandling.Ignore)]
        public string BirthPlace { get; set; }

        [JsonProperty("characters", NullValueHandling = NullValueHandling.Ignore)]
        public List<Character> Characters { get; set; }

        [JsonProperty("death", NullValueHandling = NullValueHandling.Ignore)]
        public string Death { get; set; }

        [JsonProperty("gender", NullValueHandling = NullValueHandling.Ignore)]
        public int Gender { get; set; }

        [JsonProperty("races", NullValueHandling = NullValueHandling.Ignore)]
        public List<Race> Races { get; set; }

        [JsonProperty("remoteIds", NullValueHandling = NullValueHandling.Ignore)]
        public List<RemoteID> RemoteIds { get; set; }

        [JsonProperty("tagOptions", NullValueHandling = NullValueHandling.Ignore)]
        public List<TagOption> TagOptions { get; set; }
    }

}
