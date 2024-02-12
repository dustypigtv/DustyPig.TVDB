using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class ArtworkExtendedRecord : ArtworkBaseRecord
    {
        public int EpisodeId { get; set; }

        public int MovieId { get; set; }

        public int NetworkId { get; set; }

        public int PeopleId { get; set; }

        public int SeasonId { get; set; }

        public int SeriesId { get; set; }

        public int SeriesPeopleId { get; set; }

        public ArtworkStatus Status { get; set; }

        public List<TagOption> TagOptions { get; set; } = [];

        public long ThumbnailHeight { get; set; }

        public long ThumbnailWidth { get; set; }

        public long? UpdatedAt { get; set; }
    }

}
