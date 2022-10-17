using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class SeasonExtendedRecord : SeasonBaseRecord
    {
        public List<ArtworkBaseRecord> Artwork { get; set; } = new List<ArtworkBaseRecord>();

        public List<EpisodeBaseRecord> Episodes { get; set; } = new List<EpisodeBaseRecord>();

        public List<Trailer> Trailers { get; set; } = new List<Trailer>();

        public List<TagOption> TagOptions { get; set; } = new List<TagOption>();

        public List<Translation> Translations { get; set; } = new List<Translation>();
    }
}
