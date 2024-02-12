using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class SeasonBaseRecord
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public int ImageType { get; set; }

        public string LastUpdated { get; set; }

        public string Name { get; set; }

        public List<string> NameTranslations { get; set; } = [];

        public int Number { get; set; }

        public List<string> OverviewTranslations { get; set; } = [];

        public Companies Companies { get; set; }

        public int SeriesId { get; set; }

        public SeasonType Type { get; set; }

        public string Year { get; set; }
    }

}
