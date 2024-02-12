namespace DustyPig.TVDB.Models
{
    public class StudioBaseRecord
    {
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Not nullable in swagger, but records often have null if there is no parent studio
        /// </summary>
        public int? ParentStudio { get; set; }
    }

}
