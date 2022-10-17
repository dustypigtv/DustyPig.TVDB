namespace DustyPig.TVDB.Models
{
    public class AwardNomineeBaseRecord
    {
        public Character Character { get; set; }

        public string Details { get; set; }

        public EpisodeBaseRecord Episode { get; set; }

        public int Id { get; set; }

        public bool IsWinner { get; set; }

        public MovieBaseRecord Movie { get; set; }

        public SeriesBaseRecord Series { get; set; }

        public string Year { get; set; }

        public string Category { get; set; }

        public string Name { get; set; }
    }

}
