using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class SeriesExtendedRecord : SeriesBaseRecord
    {
        [JsonProperty("airsDays", NullValueHandling = NullValueHandling.Ignore)]
        public SeriesAirsDays AirsDays { get; set; }

        [JsonProperty("airsTime", NullValueHandling = NullValueHandling.Ignore)]
        public string AirsTime { get; set; }

        [JsonProperty("artworks", NullValueHandling = NullValueHandling.Ignore)]
        public List<ArtworkExtendedRecord> Artworks { get; set; }

        [JsonProperty("characters", NullValueHandling = NullValueHandling.Ignore)]
        public List<Character> Characters { get; set; }

        [JsonProperty("lists", NullValueHandling = NullValueHandling.Ignore)]
        public object Lists { get; set; }

        [JsonProperty("genres", NullValueHandling = NullValueHandling.Ignore)]
        public List<GenreBaseRecord> Genres { get; set; }

        [JsonProperty("companies", NullValueHandling = NullValueHandling.Ignore)]
        public List<Company> Companies { get; set; }

        [JsonProperty("remoteIds", NullValueHandling = NullValueHandling.Ignore)]
        public List<RemoteID> RemoteIds { get; set; }

        [JsonProperty("seasons", NullValueHandling = NullValueHandling.Ignore)]
        public List<SeasonBaseRecord> Seasons { get; set; }

        [JsonProperty("trailers", NullValueHandling = NullValueHandling.Ignore)]
        public List<Trailer> Trailers { get; set; }
    }

}
