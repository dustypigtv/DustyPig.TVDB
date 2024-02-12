using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class SeriesEpisodeData
    {
        public SeriesExtendedRecord Series { get; set; }

        public List<EpisodeBaseRecord> Episodes { get; set; } = [];
    }

}
