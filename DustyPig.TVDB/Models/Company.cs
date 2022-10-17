using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class Company
    {
        public string ActiveDate { get; set; }

        public List<Alias> Aliases { get; set; } = new List<Alias>();

        public string Country { get; set; }

        public int Id { get; set; }

        public string InactiveDate { get; set; }

        public string Name { get; set; }

        public List<string> NameTranslations { get; set; } = new List<string>();

        public List<string> OverviewTranslations { get; set; } = new List<string>();

        public int PrimaryCompanyType { get; set; }

        public string Slug { get; set; }
    }

}
