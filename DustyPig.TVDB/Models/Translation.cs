using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class Translation
    {
        public List<string> Aliases { get; set; } = new List<string>();

        public bool IsAlias { get; set; }

        public bool IsPrimary { get; set; }

        public string Language { get; set; }

        public string Name { get; set; }

        public string Overview { get; set; }

        /// <summary>Only populated for movie translations.  We disallow taglines without a title.</summary>
        public string Tagline { get; set; }
    }

}
