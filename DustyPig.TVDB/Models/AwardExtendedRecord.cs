using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class AwardExtendedRecord : AwardBaseRecord
    {
        public List<AwardCategoryBaseRecord> Categories { get; set; } = new List<AwardCategoryBaseRecord>();

        public int Score { get; set; }
    }

}
