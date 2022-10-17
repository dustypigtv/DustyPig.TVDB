using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Tests
{
    [TestClass]
    public class Movies
    {
        [TestMethod]
        public async Task GetAll()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Movies.GetAllAsync();
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task Get()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Movies.GetAsync(3033);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetExtended()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Movies.GetExtendedAsync(3033);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task Filter()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Movies.FilterAsync("US", "eng", 2012);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetSlug()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Movies.GetAsync("the-avengers");
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetTranslation()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Movies.GetTranslationAsync(2022, "eng");
            ret.ThrowIfError();
        }


    }
}
