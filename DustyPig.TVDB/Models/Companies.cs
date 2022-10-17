using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class Companies
    {
        public List<Company> Studio { get; set; } = new List<Company>();

        public List<Company> Network { get; set; } = new List<Company>();

        public List<Company> Production { get; set; } = new List<Company>();

        public List<Company> Distributor { get; set; } = new List<Company>();

        public List<Company> SpecialEffects { get; set; } = new List<Company>();
    }

}
