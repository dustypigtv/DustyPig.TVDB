using System.Text.Json.Serialization;

namespace DustyPig.TVDB.Models
{
    public class Inspiration
    {
        public int Id { get; set; }

        public string Type { get; set; }

        [JsonPropertyName("type_name")]
        public string TypeName { get; set; }

        public string Url { get; set; }
    }

}
