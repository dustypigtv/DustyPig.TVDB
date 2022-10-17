using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class Character
    {
        public List<Alias> Aliases { get; set; } = new List<Alias>();

        public RecordInfo Episode { get; set; }

        public int EpisodeId { get; set; }

        public int Id { get; set; }

        public string Image { get; set; }

        public bool IsFeatured { get; set; }

        public int MovieId { get; set; }

        public RecordInfo Movie { get; set; }

        public string Name { get; set; }

        public List<string> NameTranslations { get; set; } = new List<string>();

        public List<string> OverviewTranslations { get; set; } = new List<string>();

        public int PeopleId { get; set; }

        [JsonProperty("personImgURL")]
        public string PersonImageUrl { get; set; }

        public string PeopleType { get; set; }

        public int SeriesId { get; set; }

        public RecordInfo Series { get; set; }

        public int Sort { get; set; }

        public List<TagOption> TagOptions { get; set; } = new List<TagOption>();

        public int Type { get; set; }

        public string Url { get; set; }

        public string PersonName { get; set; }
    }

}
