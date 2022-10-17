using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Tests
{
    [TestClass]
    public class Seasons
    {
        [TestMethod]
        public async Task GetAll()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Seasons.GetAllAsync();
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task Get()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Seasons.GetAsync(10);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetExtended()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Seasons.GetExtendedAsync(10);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAllTypes()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Seasons.GetAllTypesAsync();
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetTranslation()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Seasons.GetTranslationAsync(10, "ita");
            ret.ThrowIfError();
        }


    }
}
