using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class MovieExtendedRecord : MovieBaseRecord
    {
        public List<ArtworkBaseRecord> Artworks { get; set; } = new List<ArtworkBaseRecord>();

        public List<string> AudioLanguages { get; set; } = new List<string>();

        public List<AwardBaseRecord> Awards { get; set; } = new List<AwardBaseRecord>();

        public string BoxOffice { get; set; }

        public string BoxOfficeUS { get; set; }

        public string Budget { get; set; }

        public List<Character> Characters { get; set; } = new List<Character>();

        public List<Company> Companies { get; set; } = new List<Company>();

        public List<ContentRating> ContentRatings { get; set; } = new List<ContentRating>();

        [JsonProperty("first_releast")]
        public Release FirstRelease { get; set; }

        public List<GenreBaseRecord> Genres { get; set; } = new List<GenreBaseRecord>();

        public List<Inspiration> Inspirations { get; set; } = new List<Inspiration>();

        public List<ListBaseRecord> Lists { get; set; } = new List<ListBaseRecord>();

        public string OriginalCountry { get; set; }

        public string OriginalLanguage { get; set; }

        [JsonProperty("production_countries")]
        public List<ProductionCountry> ProductionCountries { get; set; } = new List<ProductionCountry>();

        public List<Release> Releases { get; set; } = new List<Release>();

        public List<RemoteId> RemoteIds { get; set; } = new List<RemoteId>();

        [JsonProperty("spoken_languages")]
        public List<string> SpokenLanguages { get; set; } = new List<string>();

        public List<StudioBaseRecord> Studios { get; set; } = new List<StudioBaseRecord>();

        public List<string> SubtitleLanguages { get; set; } = new List<string>();

        public List<TagOption> TagOptions { get; set; } = new List<TagOption>();

        public List<Trailer> Trailers { get; set; } = new List<Trailer>();

        public TranslationExtended Translations { get; set; }


    }

}
