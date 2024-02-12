using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class Character
    {
        public List<Alias> Aliases { get; set; } = [];

        public RecordInfo Episode { get; set; }

        public int? EpisodeId { get; set; }

        public int Id { get; set; }

        public string Image { get; set; }

        public bool IsFeatured { get; set; }

        public int? MovieId { get; set; }

        public RecordInfo Movie { get; set; }

        public string Name { get; set; }

        public List<string> NameTranslations { get; set; } = [];

        public List<string> OverviewTranslations { get; set; } = [];

        public int PeopleId { get; set; }

        public string PersonImgUrl { get; set; }

        public string PeopleType { get; set; }

        public int? SeriesId { get; set; }

        public RecordInfo Series { get; set; }

        public int Sort { get; set; }

        public List<TagOption> TagOptions { get; set; } = [];

        public long Type { get; set; }

        public string Url { get; set; }

        public string PersonName { get; set; }
    }

}
