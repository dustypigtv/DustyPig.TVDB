using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class ArtworkExtendedRecord : ArtworkBaseRecord
    {
        [JsonProperty("episodeId", NullValueHandling = NullValueHandling.Ignore)]
        public int EpisodeId { get; set; }

        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public int Height { get; set; }

        [JsonProperty("movieId", NullValueHandling = NullValueHandling.Ignore)]
        public int MovieId { get; set; }

        [JsonProperty("networkId", NullValueHandling = NullValueHandling.Ignore)]
        public int NetworkId { get; set; }

        [JsonProperty("peopleId", NullValueHandling = NullValueHandling.Ignore)]
        public int PeopleId { get; set; }

        [JsonProperty("seasonId", NullValueHandling = NullValueHandling.Ignore)]
        public int SeasonId { get; set; }

        [JsonProperty("seriesId", NullValueHandling = NullValueHandling.Ignore)]
        public int SeriesId { get; set; }

        [JsonProperty("seriesPeopleId", NullValueHandling = NullValueHandling.Ignore)]
        public int SeriesPeopleId { get; set; }

        [JsonProperty("thumbnailHeight", NullValueHandling = NullValueHandling.Ignore)]
        public int ThumbnailHeight { get; set; }

        [JsonProperty("thumbnailWidth", NullValueHandling = NullValueHandling.Ignore)]
        public int ThumbnailWidth { get; set; }

        [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public long UpdatedAt { get; set; }

        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public int Width { get; set; }
    }

}
