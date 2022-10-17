using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Tests
{
    [TestClass]
    public class Awards
    {
        [TestMethod]
        public async Task GetAll()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Awards.GetAllAsync();
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task Get()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Awards.GetAsync(1);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetExtended()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Awards.GetExtendedAsync(1);
            ret.ThrowIfError();
        }
    }
}
