namespace DustyPig.TVDB.Models
{
    public class Entity
    {
        /// <summary>
        /// Documentation doesn't say nullable, but responses are sometimes null
        /// </summary>
        public int? MovieId { get; set; }

        public int Order { get; set; }

        /// <summary>
        /// Documentation doesn't say nullable, but responses are sometimes null
        /// </summary>
        public int? SeriesId { get; set; }
    }

}
