using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.TVDB.Models
{
    public class Company
    {
        [JsonProperty("activeDate", NullValueHandling = NullValueHandling.Ignore)]
        public string ActiveDate { get; set; }

        [JsonProperty("aliases", NullValueHandling = NullValueHandling.Ignore)]
        public List<Alias> Aliases { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("inactiveDate", NullValueHandling = NullValueHandling.Ignore)]
        public string InactiveDate { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("nameTranslations", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> NameTranslations { get; set; }

        [JsonProperty("overviewTranslations", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> OverviewTranslations { get; set; }

        [JsonProperty("primaryCompanyType", NullValueHandling = NullValueHandling.Ignore)]
        public int PrimaryCompanyType { get; set; }

        [JsonProperty("slug", NullValueHandling = NullValueHandling.Ignore)]
        public string Slug { get; set; }
    }

}
