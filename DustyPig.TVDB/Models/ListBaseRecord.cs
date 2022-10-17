using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class List
    {
        public List<Alias> Aliases { get; set; } = new List<Alias>();

        public int Id { get; set; }

        public string Image { get; set; }

        public bool ImageIsFallback { get; set; }

        public bool IsOfficial { get; set; }

        public string Name { get; set; }

        public List<string> NameTranslations { get; set; } = new List<string>();

        public string Overview { get; set; }

        public List<string> OverviewTranslations { get; set; } = new List<string>();

        public List<RemoteId> RemoteIds { get; set; } = new List<RemoteId>();

        public List<TagOption> Tags { get; set; }

        public int Score { get; set; }

        public string Url { get; set; }
    }

}
