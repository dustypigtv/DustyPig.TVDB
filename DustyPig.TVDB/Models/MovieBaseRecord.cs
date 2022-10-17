using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class MovieBaseRecord
    {
        public List<Alias> Aliases { get; set; } = new List<Alias>();

        public int Id { get; set; }

        public string Image { get; set; }

        public string LastUpdated { get; set; }

        public string Name { get; set; }

        public List<string> NameTranslations { get; set; } = new List<string>();

        public List<string> OverviewTranslations { get; set; } = new List<string>();

        public int Runtime { get; set; }

        public double Score { get; set; }

        public string Slug { get; set; }

        public Status Status { get; set; }

        public string Year { get; set; }
    }

}
