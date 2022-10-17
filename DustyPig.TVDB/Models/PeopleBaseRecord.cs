using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class PeopleBaseRecord
    {
        public List<Alias> Aliases { get; set; } = new List<Alias>();

        public int Id { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public int Score { get; set; }
    }

}
