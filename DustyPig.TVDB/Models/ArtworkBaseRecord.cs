namespace DustyPig.TVDB.Models
{
    public class ArtworkBaseRecord
    {

        public int Id { get; set; }

        public string Image { get; set; }

        public string Language { get; set; }

        public double? Score { get; set; }

        public string Thumbnail { get; set; }

        /// <summary>
        /// The artwork type corresponds to the ids from the /artwork/types endpoint.
        /// </summary>
        public long Type { get; set; }

        public long Height { get; set; }

        public long Width { get; set; }

        public bool IncludesText { get; set; }
    }

}
