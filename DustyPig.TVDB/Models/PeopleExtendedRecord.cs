using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class PeopleExtendedRecord : PeopleBaseRecord
    {
        public List<AwardBaseRecord> Awards { get; set; } = [];

        public List<BiographyRecord> Biographies { get; set; } = [];

        public string Birth { get; set; }

        public string BirthPlace { get; set; }

        public List<Character> Characters { get; set; } = [];

        public string Death { get; set; }

        public int Gender { get; set; }

        public List<Race> Races { get; set; } = [];

        public List<RemoteId> RemoteIds { get; set; } = [];

        public string Slug { get; set; }

        public List<TagOption> TagOptions { get; set; } = [];

        public TranslationExtended Translations { get; set; }
    }

}
