using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class TranslationExtended
    {
        public List<Translation> NameTranslations { get; set; } = new List<Translation>();

        public List<Translation> OverviewTranslations { get; set; } = new List<Translation>();

        public List<string> Aliases { get; set; } = [];
    }
}
