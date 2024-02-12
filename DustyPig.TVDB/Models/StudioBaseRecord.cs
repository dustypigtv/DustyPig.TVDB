namespace DustyPig.TVDB.Models
{
    public class StudioBaseRecord
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentStudio { get; set; }
    }

}
