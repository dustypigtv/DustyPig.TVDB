using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class AwardCategoryExtendedRecord : AwardCategoryBaseRecord
    {
        [JsonProperty("nominees", NullValueHandling = NullValueHandling.Ignore)]
        public List<AwardNomineeBaseRecord> Nominees { get; set; }
    }

}
