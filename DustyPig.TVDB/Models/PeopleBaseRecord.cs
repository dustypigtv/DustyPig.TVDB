using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class PeopleBaseRecord
    {
        public List<Alias> Aliases { get; set; } = [];

        public int Id { get; set; }

        public string Image { get; set; }

        public string LastUpdated { get; set; }

        public string Name { get; set; }

        public List<string> NameTranslations { get; set; } = [];

        public List<string> OverviewTranslations { get; set; } = [];

        public int Score { get; set; }
    }

}
