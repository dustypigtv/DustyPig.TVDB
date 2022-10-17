namespace DustyPig.TVDB.Models
{
    public class AwardCategoryBaseRecord
    {
        public bool AllowCoNominees { get; set; }

        public AwardBaseRecord Award { get; set; }

        public bool ForMovies { get; set; }

        public bool ForSeries { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }
    }

}
