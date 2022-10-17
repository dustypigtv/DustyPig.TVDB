using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class SeriesBaseRecord
    {
        public string Abbreviation { get; set; }

        public List<Alias> Aliases { get; set; } = new List<Alias>();

        public string Country { get; set; }

        public int DefaultSeasonType { get; set; }

        public string FirstAired { get; set; }

        public int Id { get; set; }

        public string Image { get; set; }

        public bool IsOrderRandomized { get; set; }

        public string LastAired { get; set; }

        public string Name { get; set; }

        public List<string> NameTranslations { get; set; } = new List<string>();

        public string NextAired { get; set; }

        public string OriginalCountry { get; set; }

        public string OriginalLanguage { get; set; }

        public List<string> OverviewTranslations { get; set; } = new List<string>();

        public double Score { get; set; }

        public string Slug { get; set; }

        public Status Status { get; set; }
    }

}
