using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class SeasonExtendedRecord : SeasonBaseRecord
    {
        public List<ArtworkBaseRecord> Artwork { get; set; } = [];

        public List<EpisodeBaseRecord> Episodes { get; set; } = [];

        public List<Trailer> Trailers { get; set; } = [];

        public List<TagOption> TagOptions { get; set; } = [];

        public List<Translation> Translations { get; set; } = [];
    }
}
