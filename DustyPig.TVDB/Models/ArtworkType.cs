using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class ArtworkType
    {
        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public int Height { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("imageFormat", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageFormat { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("recordType", NullValueHandling = NullValueHandling.Ignore)]
        public string RecordType { get; set; }

        [JsonProperty("slug", NullValueHandling = NullValueHandling.Ignore)]
        public string Slug { get; set; }

        [JsonProperty("thumbHeight", NullValueHandling = NullValueHandling.Ignore)]
        public int ThumbHeight { get; set; }

        [JsonProperty("thumbWidth", NullValueHandling = NullValueHandling.Ignore)]
        public int ThumbWidth { get; set; }

        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public int Width { get; set; }
    }

}
