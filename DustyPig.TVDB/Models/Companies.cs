using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DustyPig.TVDB.Models
{
    public class Companies
    {
        public List<Company> Studio { get; set; } = [];

        public List<Company> Network { get; set; } = [];

        public List<Company> Production { get; set; } = [];

        public List<Company> Distributor { get; set; } = [];

        [JsonPropertyName("special_effects")]
        public List<Company> SpecialEffects { get; set; } = [];
    }

}
