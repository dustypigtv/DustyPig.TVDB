using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class MovieExtendedRecord : MovieBaseRecord
    {
        [JsonProperty("artworks", NullValueHandling = NullValueHandling.Ignore)]
        public List<ArtworkBaseRecord> Artworks { get; set; }

        [JsonProperty("audioLanguages", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> AudioLanguages { get; set; }

        [JsonProperty("awards", NullValueHandling = NullValueHandling.Ignore)]
        public List<AwardBaseRecord> Awards { get; set; }

        [JsonProperty("boxOffice", NullValueHandling = NullValueHandling.Ignore)]
        public string BoxOffice { get; set; }

        [JsonProperty("budget", NullValueHandling = NullValueHandling.Ignore)]
        public string Budget { get; set; }

        [JsonProperty("characters", NullValueHandling = NullValueHandling.Ignore)]
        public List<Character> Characters { get; set; }

        [JsonProperty("lists", NullValueHandling = NullValueHandling.Ignore)]
        public List<ListBaseRecord> Lists { get; set; }

        [JsonProperty("genres", NullValueHandling = NullValueHandling.Ignore)]
        public List<GenreBaseRecord> Genres { get; set; }

        [JsonProperty("originalCountry", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalCountry { get; set; }

        [JsonProperty("originalLanguage", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalLanguage { get; set; }

        [JsonProperty("releases", NullValueHandling = NullValueHandling.Ignore)]
        public List<Release> Releases { get; set; }

        [JsonProperty("remoteIds", NullValueHandling = NullValueHandling.Ignore)]
        public List<RemoteID> RemoteIds { get; set; }

        [JsonProperty("runtime", NullValueHandling = NullValueHandling.Ignore)]
        public int? Runtime { get; set; }

        [JsonProperty("contentRatings", NullValueHandling = NullValueHandling.Ignore)]
        public List<ContentRating> ContentRatings { get; set; }

        [JsonProperty("studios", NullValueHandling = NullValueHandling.Ignore)]
        public List<StudioBaseRecord> Studios { get; set; }

        [JsonProperty("subtitleLanguages", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> SubtitleLanguages { get; set; }

        [JsonProperty("tagOptions", NullValueHandling = NullValueHandling.Ignore)]
        public List<TagOption> TagOptions { get; set; }

        [JsonProperty("trailers", NullValueHandling = NullValueHandling.Ignore)]
        public List<Trailer> Trailers { get; set; }

        [JsonProperty("inspirations", NullValueHandling = NullValueHandling.Ignore)]
        public List<Inspiration> Inspirations { get; set; }

        [JsonProperty("productionCountries", NullValueHandling = NullValueHandling.Ignore)]
        public List<ProductionCountry> ProductionCountries { get; set; }

        [JsonProperty("spokenLanguages", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> SpokenLanguages { get; set; }

        [JsonProperty("firstRelease", NullValueHandling = NullValueHandling.Ignore)]
        public Release FirstRelease { get; set; }

        [JsonProperty("companies", NullValueHandling = NullValueHandling.Ignore)]
        public Companies Companies { get; set; }
    }

}
