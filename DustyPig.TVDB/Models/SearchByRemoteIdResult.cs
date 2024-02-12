namespace DustyPig.TVDB.Models
{
    public class SearchByRemoteIdResult
    {
        public SeriesBaseRecord Series { get; set; }

        public PeopleBaseRecord People { get; set; }

        public MovieBaseRecord Movie { get; set; }

        public EpisodeBaseRecord Episode { get; set; }

        public Company Company { get; set; }
    }
}
