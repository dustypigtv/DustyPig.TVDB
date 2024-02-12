using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DustyPig.TVDB.Models
{
    public class MovieExtendedRecord : MovieBaseRecord
    {
        public List<ArtworkBaseRecord> Artworks { get; set; } = [];

        public List<string> AudioLanguages { get; set; } = [];

        public List<AwardBaseRecord> Awards { get; set; } = [];

        public string BoxOffice { get; set; }

        public string BoxOfficeUS { get; set; }

        public string Budget { get; set; }

        public List<Character> Characters { get; set; } = [];

        public Companies Companies { get; set; }

        public List<ContentRating> ContentRatings { get; set; } = [];

        [JsonPropertyName("first_releast")]
        public Release FirstRelease { get; set; }

        public List<GenreBaseRecord> Genres { get; set; } = [];

        public List<Inspiration> Inspirations { get; set; } = [];

        public List<List> Lists { get; set; } = [];

        public string OriginalCountry { get; set; }

        public string OriginalLanguage { get; set; }

        [JsonPropertyName("production_countries")]
        public List<ProductionCountry> ProductionCountries { get; set; } = [];

        public List<Release> Releases { get; set; } = [];

        public List<RemoteId> RemoteIds { get; set; } = [];

        [JsonPropertyName("spoken_languages")]
        public List<string> SpokenLanguages { get; set; } = [];

        public List<StudioBaseRecord> Studios { get; set; } = [];

        public List<string> SubtitleLanguages { get; set; } = [];

        public List<TagOption> TagOptions { get; set; } = [];

        public List<Trailer> Trailers { get; set; } = [];

        public TranslationExtended Translations { get; set; }


    }

}
