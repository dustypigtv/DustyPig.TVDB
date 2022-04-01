using Newtonsoft.Json;

namespace DustyPig.TVDB.Models
{
    public class CompanyType
    {
        [JsonProperty("companyTypeId", NullValueHandling = NullValueHandling.Ignore)]
        public int CompanyTypeId { get; set; }

        [JsonProperty("companyTypeName", NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyTypeName { get; set; }
    }

}
