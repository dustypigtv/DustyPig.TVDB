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
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.AwardCategories.GetAsync(1);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetExtended()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.AwardCategories.GetExtendedAsync(1);
            ret.ThrowIfError();
        }
    }
}
