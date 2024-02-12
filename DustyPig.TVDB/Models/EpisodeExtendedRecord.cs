using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class EpisodeExtendedRecord : EpisodeBaseRecord
    {
        public List<AwardBaseRecord> Awards { get; set; } = [];

        public List<Character> Characters { get; set; } = [];

        public List<Company> Companies { get; set; } = [];

        public List<ContentRating> ContentRatings { get; set; } = [];

        public List<Company> Networks { get; set; } = [];

        public List<AwardNomineeBaseRecord> Nominations { get; set; } = [];

        public string ProductionCode { get; set; }

        public List<RemoteId> RemoteIds { get; set; } = [];

        public List<Company> Studios { get; set; } = [];

        public List<TagOption> TagOptions { get; set; } = [];

        public List<Trailer> Trailers { get; set; } = [];

        public TranslationExtended Translations { get; set; }
    }

}
