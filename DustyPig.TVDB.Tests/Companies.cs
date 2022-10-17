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
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Companies.GetAllCompaniesAsync();
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAllTypes()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Companies.GetAllTypesAsync();
            ret.ThrowIfError();
        }
    }
}
