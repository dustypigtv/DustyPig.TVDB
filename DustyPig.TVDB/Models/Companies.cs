using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class Companies
    {
        [JsonProperty("studio", NullValueHandling = NullValueHandling.Ignore)]
        public List<Company> Studio { get; set; }

        [JsonProperty("network", NullValueHandling = NullValueHandling.Ignore)]
        public List<Company> Network { get; set; }

        [JsonProperty("production", NullValueHandling = NullValueHandling.Ignore)]
        public List<Company> Production { get; set; }

        [JsonProperty("distributor", NullValueHandling = NullValueHandling.Ignore)]
        public List<Company> Distributor { get; set; }

        [JsonProperty("specialEffects", NullValueHandling = NullValueHandling.Ignore)]
        public List<Company> SpecialEffects { get; set; }
    }

}
