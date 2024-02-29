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
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Movies.GetAllAsync();
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task Get()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Movies.GetAsync(3033);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetExtended()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Movies.GetExtendedAsync(3033);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task Filter()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Movies.FilterAsync("US", "eng", 2012);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetSlug()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Movies.GetAsync("the-avengers");
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetTranslation()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Movies.GetTranslationAsync(2022, "eng");
            ret.ThrowIfError();
        }


    }
}
