using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class SeriesEpisodeData
    {
        [JsonProperty("series", NullValueHandling = NullValueHandling.Ignore)]
        public SeriesExtendedRecord Series { get; set; }

        [JsonProperty("episodes", NullValueHandling = NullValueHandling.Ignore)]
        public List<EpisodeBaseRecord> Episodes { get; set; }
    }

}
