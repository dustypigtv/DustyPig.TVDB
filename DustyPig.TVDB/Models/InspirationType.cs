using System.Text.Json.Serialization;

namespace DustyPig.TVDB.Models
{
    public class InspirationType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [JsonPropertyName("reference_name")]
        public string ReferenceName { get; set; }

        public string Url { get; set; }
    }
}
