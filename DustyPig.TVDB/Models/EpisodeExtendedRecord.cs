using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class EpisodeExtendedRecord : EpisodeBaseRecord
    {
        public int AirsAfterSeason { get; set; }

        public int AirsBeforeEpisode { get; set; }

        public int AirsBeforeSeason { get; set; }

        public List<AwardBaseRecord> Awards { get; set; } = new List<AwardBaseRecord>();

        public List<Character> Characters { get; set; } = new List<Character>();

        public List<ContentRating> ContentRatings { get; set; } = new List<ContentRating>();

        public NetworkBaseRecord Network { get; set; }

        public string ProductionCode { get; set; }

        public List<RemoteId> RemoteIds { get; set; } = new List<RemoteId>();

        public List<TagOption> TagOptions { get; set; } = new List<TagOption>();

        public TranslationExtended Translations { get; set; }

        public List<Trailer> Trailers { get; set; } = new List<Trailer>();
    }

}
