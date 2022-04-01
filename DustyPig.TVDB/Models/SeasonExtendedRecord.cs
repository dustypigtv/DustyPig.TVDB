using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class SeasonExtendedRecord : SeasonBaseRecord
    {
        [JsonProperty("artwork", NullValueHandling = NullValueHandling.Ignore)]
        public List<ArtworkBaseRecord> Artwork { get; set; }

        [JsonProperty("episodes", NullValueHandling = NullValueHandling.Ignore)]
        public List<EpisodeBaseRecord> Episodes { get; set; }

        [JsonProperty("trailers", NullValueHandling = NullValueHandling.Ignore)]
        public List<Trailer> Trailers { get; set; }

        [JsonProperty("companies", NullValueHandling = NullValueHandling.Ignore)]
        public Companies Companies { get; set; }

        [JsonProperty("tagOptions", NullValueHandling = NullValueHandling.Ignore)]
        public List<TagOption> TagOptions { get; set; }
    }

}
