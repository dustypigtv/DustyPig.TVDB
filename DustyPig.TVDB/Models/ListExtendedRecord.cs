using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class ListExtendedRecord : ListBaseRecord
    {
        public List<Entity> Entities { get; set; } = new List<Entity>();

        public int Score { get; set; }
    }

}
