namespace DustyPig.TVDB.Models
{
    public class ParentCompany
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CompanyRelationship CompanyRelationship { get; set; }
    }
}
