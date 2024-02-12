using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    /// <summary>
    /// The base record for a series. All series airs time like firstAired, lastAired, nextAired, etc. are in US EST for US series, and for all non-US series, the time of the show’s country capital or most populous city. For streaming services, is the official release time. See https://support.thetvdb.com/kb/faq.php?id=29
    /// </summary>
    public class SeriesBaseRecord
    {
        public List<Alias> Aliases { get; set; } = [];

        public int? AverageRuntime { get; set; }

        public string Country { get; set; }

        public int DefaultSeasonType { get; set; }

        public List<EpisodeBaseRecord> Episodes { get; set; } = new List<EpisodeBaseRecord>();

        public string FirstAired { get; set; }

        public int Id { get; set; }

        public string Image { get; set; }

        public bool IsOrderRandomized { get; set; }

        public string LastAired { get; set; }

        public string LastUpdated { get; set; }

        public string Name { get; set; }

        public List<string> NameTranslations { get; set; } = [];

        public string NextAired { get; set; }

        public string OriginalCountry { get; set; }

        public string OriginalLanguage { get; set; }

        public List<string> OverviewTranslations { get; set; } = [];

        public double Score { get; set; }

        public string Slug { get; set; }

        public Status Status { get; set; }

        public string Year { get; set; }
    }

}
