using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class ListBaseRecord
    {
        public List<Alias> Aliases { get; set; } = new List<Alias>();

        public int Id { get; set; }

        public bool IsOfficial { get; set; }

        public string Name { get; set; }

        public List<string> NameTranslations { get; set; } = new List<string>();

        public string Overview { get; set; }

        public List<string> OverviewTranslations { get; set; } = new List<string>();

        public string Url { get; set; }
    }

}
