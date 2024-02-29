using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Tests
{
    [TestClass]
    public class Companies
    {
        [TestMethod]
        public async Task GetAllCompanies()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Companies.GetAllCompaniesAsync();
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAllTypes()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Companies.GetAllTypesAsync();
            ret.ThrowIfError();
        }
    }
}
