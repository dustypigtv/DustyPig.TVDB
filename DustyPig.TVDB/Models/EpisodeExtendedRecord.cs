using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class EpisodeExtendedRecord : EpisodeBaseRecord
    {
        public List<AwardBaseRecord> Awards { get; set; } = new List<AwardBaseRecord>();

        public List<Character> Characters { get; set; } = new List<Character>();

        public List<Company> Companies { get; set; } = new List<Company>();

        public List<ContentRating> ContentRatings { get; set; } = [];

        public List<Company> Networks { get; set; } = new List<Company>();

        public List<AwardNomineeBaseRecord> Nominations { get; set; } = new List<AwardNomineeBaseRecord>();

        public string ProductionCode { get; set; }

        public List<RemoteId> RemoteIds { get; set; } = [];

        public List<Company> Studios { get; set; } = new List<Company>();

        public List<TagOption> TagOptions { get; set; } = new List<TagOption>();

        public List<Trailer> Trailers { get; set; } = new List<Trailer>();

        public TranslationExtended Translations { get; set; }
    }

}
