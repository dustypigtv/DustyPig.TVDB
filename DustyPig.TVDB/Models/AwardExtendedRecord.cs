using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class AwardExtendedRecord : AwardBaseRecord
    {
        [JsonProperty("categories", NullValueHandling = NullValueHandling.Ignore)]
        public List<AwardCategoryBaseRecord> Categories { get; set; }

        [JsonProperty("score", NullValueHandling = NullValueHandling.Ignore)]
        public int Score { get; set; }
    }

}
