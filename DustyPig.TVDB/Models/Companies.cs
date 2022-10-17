using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class Companies
    {
        public Company Studio { get; set; }

        public Company Network { get; set; }

        public Company Production { get; set; }

        public Company Distributor { get; set; }

        [JsonProperty("special_effects")]
        public Company SpecialEffects { get; set; }
    }

}
