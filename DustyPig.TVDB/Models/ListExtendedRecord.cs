using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class ListExtendedRecord : ListBaseRecord
    {
        [JsonProperty("entities", NullValueHandling = NullValueHandling.Ignore)]
        public List<Entity> Entities { get; set; }

        [JsonProperty("score", NullValueHandling = NullValueHandling.Ignore)]
        public int Score { get; set; }
    }

}
