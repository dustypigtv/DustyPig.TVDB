using DustyPig.TVDB.Converters;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DustyPig.TVDB.Models
{
    public class EpisodeBaseRecord
    {
        public string Aired { get; set; }

        public int AirsAfterSeason { get; set; }

        public int AirsBeforeEpisode { get; set; }

        public int AirsBeforeSeason { get; set; }

        public string FinaleType { get; set; }

        public int Id { get; set; }

        public string Image { get; set; }

        public int? ImageType { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        public bool IsMovie { get; set; }

        public string LastUpdated { get; set; }

        public int LinkedMovie { get; set; }

        public string Name { get; set; }

        public List<string> NameTranslations { get; set; } = [];

        public int? Number { get; set; }

        public string Overview { get; set; }

        public List<string> OverviewTranslations { get; set; } = [];

        public int? Runtime { get; set; }

        public int? SeasonNumber { get; set; }

        public List<SeasonBaseRecord> Seasons { get; set; } = [];

        public int SeriesId { get; set; }

        public string SeasonName { get; set; }

        public string Year { get; set; }
    }

}
