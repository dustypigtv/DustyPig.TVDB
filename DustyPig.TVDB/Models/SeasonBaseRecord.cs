using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class SeasonBaseRecord
    {
        public string Abbreviation { get; set; }

        public string Country { get; set; }

        public int Id { get; set; }

        public string Image { get; set; }

        public int ImageType { get; set; }

        public string Name { get; set; }

        public List<string> NameTranslations { get; set; } = new List<string>();

        public int Number { get; set; }

        public List<string> OverviewTranslations { get; set; } = new List<string>();

        public int SeriesId { get; set; }

        public string Slug { get; set; }

        public SeasonType Type { get; set; }
    }

}
