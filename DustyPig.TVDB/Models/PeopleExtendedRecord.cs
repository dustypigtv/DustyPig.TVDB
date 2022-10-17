using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class PeopleExtendedRecord : PeopleBaseRecord
    {
        public List<AwardBaseRecord> Awards { get; set; } = new List<AwardBaseRecord>();

        public List<BiographyRecord> Biographies { get; set; } = new List<BiographyRecord>();

        public string Birth { get; set; }

        public string BirthPlace { get; set; }

        public List<Character> Characters { get; set; } = new List<Character>();

        public string Death { get; set; }

        public int Gender { get; set; }

        public List<Race> Races { get; set; } = new List<Race>();

        public List<RemoteId> RemoteIds { get; set; } = new List<RemoteId>();

        public string Slug { get; set; }

        public List<TagOption> TagOptions { get; set; } = new List<TagOption>();

        public TranslationExtended Translations { get; set; }
    }

}
