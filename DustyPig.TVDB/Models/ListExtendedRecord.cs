using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class ListExtendedRecord : List
    {
        public List<Entity> Entities { get; set; } = new List<Entity>();
    }

}
