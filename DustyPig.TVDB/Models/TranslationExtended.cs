using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class TranslationExtended
    {
        public List<Translation> NameTranslations { get; set; } = [];

        public List<Translation> OverviewTranslations { get; set; } = [];

        public List<string> Aliases { get; set; } = [];
    }
}
