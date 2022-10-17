using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Tests
{
    [TestClass]
    public class People
    {
        [TestMethod]
        public async Task GetAll()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.People.GetAllAsync();
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task Get()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.People.GetAsync(252097);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetExtended()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.People.GetExtendedAsync(252097);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetTranslation()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.People.GetTranslationAsync(252097, "eng");
            ret.ThrowIfError();
        }
    }
}
