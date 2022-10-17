using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class SeriesExtendedRecord : SeriesBaseRecord
    {
        public SeriesAirsDays AirsDays { get; set; } = new SeriesAirsDays();

        public string AirsTime { get; set; }

        public List<ArtworkExtendedRecord> Artworks { get; set; } = new List<ArtworkExtendedRecord>();

        public List<Character> Characters { get; set; } = new List<Character>();

        public object Lists { get; set; }

        public List<GenreBaseRecord> Genres { get; set; } = new List<GenreBaseRecord>();

        public List<Company> Companies { get; set; } = new List<Company>();

        public List<RemoteId> RemoteIds { get; set; } = new List<RemoteId>();

        public List<SeasonBaseRecord> Seasons { get; set; } = new List<SeasonBaseRecord>();

        public List<Trailer> Trailers { get; set; } = new List<Trailer>();
    }

}
