using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    /// <summary>
    /// The extended record for a series. All series airs time like firstAired, lastAired, nextAired, etc. are in US EST for US series, and for all non-US series, the time of the show�s country capital or most populous city. For streaming services, is the official release time. See https://support.thetvdb.com/kb/faq.php?id=29
    /// </summary>
    public class SeriesExtendedRecord : SeriesBaseRecord
    {
        public string Abbreviation { get; set; }

        public SeriesAirsDays AirsDays { get; set; } = new SeriesAirsDays();

        public string AirsTime { get; set; }

        public List<ArtworkExtendedRecord> Artworks { get; set; } = [];

        public List<Character> Characters { get; set; } = [];

        public List<Company> Companies { get; set; } = [];

        public List<ContentRating> ContentRatings { get; set; } = [];

        public List<GenreBaseRecord> Genres { get; set; } = [];

        public Company LatestNetwork { get; set; }

        public object Lists { get; set; }

        public Company OriginalNetwork { get; set; }

        public string Overview { get; set; }

        public List<RemoteId> RemoteIds { get; set; } = [];

        public List<SeasonBaseRecord> Seasons { get; set; } = [];

        public List<SeasonType> SeasonTypes { get; set; } = [];

        public List<TagOption> Tags { get; set; } = [];

        public List<Trailer> Trailers { get; set; } = [];

        public TranslationExtended Translations { get; set; }
    }

}
