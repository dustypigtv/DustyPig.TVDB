using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class AwardExtendedRecord : AwardBaseRecord
    {
        public List<AwardCategoryBaseRecord> Categories { get; set; } = [];

        public long Score { get; set; }
    }

}
