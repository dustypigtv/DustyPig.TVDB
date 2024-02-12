using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class EpisodeBaseRecord
    {
        public string Aired { get; set; }

        public int AirsAfterSeason { get; set; }

        public int AirsBeforeEpisode { get; set; }

        public int AirsBeforeSeason { get; set; }

        /// <summary>
        /// season, midseason, or series
        /// </summary>
        public string FinaleType { get; set; }

        public int Id { get; set; }

        public string Image { get; set; }

        public int? ImageType { get; set; }

        public int IsMovie { get; set; }

        public string LastUpdated { get; set; }

        public int LinkedMovie { get; set; }

        public string Name { get; set; }

        public List<string> NameTranslations { get; set; } = [];

        /// <summary>
        /// Not nullable in documentation, but some results are null
        /// </summary>
        public int? Number { get; set; }

        public string Overview { get; set; }

        public List<string> OverviewTranslations { get; set; } = [];

        public int? Runtime { get; set; }

        /// <summary>
        /// Not nullable in documentation, but some results are null
        /// </summary>
        public int? SeasonNumber { get; set; }

        public List<SeasonBaseRecord> Seasons { get; set; } = [];

        public int SeriesId { get; set; }

        public string SeasonName { get; set; }

        public string Year { get; set; }
    }

}
