namespace DustyPig.TVDB.Models
{
    public class ArtworkExtendedRecord : ArtworkBaseRecord
    {
        public int EpisodeId { get; set; }

        public int Height { get; set; }

        public int MovieId { get; set; }

        public int NetworkId { get; set; }

        public int PeopleId { get; set; }

        public int SeasonId { get; set; }

        public int SeriesId { get; set; }

        public int SeriesPeopleId { get; set; }

        public int ThumbnailHeight { get; set; }

        public int ThumbnailWidth { get; set; }

        public long UpdatedAt { get; set; }

        public int Width { get; set; }
    }

}
