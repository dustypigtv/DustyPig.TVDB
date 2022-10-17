namespace DustyPig.TVDB.Models
{
    public class ContentRating
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }

        public string ContentType { get; set; }

        public int Order { get; set; }

        public string FullName { get; set; }
    }

}
