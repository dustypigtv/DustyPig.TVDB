using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Tests
{
    [TestClass]
    public class AwardCategories
    {
        [TestMethod]
        public async Task Get()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.AwardCategories.GetAsync(1);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetExtended()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.AwardCategories.GetExtendedAsync(1);
            ret.ThrowIfError();
        }
    }
}
