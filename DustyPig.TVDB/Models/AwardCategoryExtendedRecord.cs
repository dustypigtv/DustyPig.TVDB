using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class AwardCategoryExtendedRecord : AwardCategoryBaseRecord
    {
        public List<AwardNomineeBaseRecord> Nominees { get; set; } = new List<AwardNomineeBaseRecord>();
    }

}
