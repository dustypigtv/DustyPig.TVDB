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
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Seasons.GetAllAsync();
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task Get()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Seasons.GetAsync(10);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetExtended()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Seasons.GetExtendedAsync(10);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAllTypes()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Seasons.GetAllTypesAsync();
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetTranslation()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Seasons.GetTranslationAsync(10, "ita");
            ret.ThrowIfError();
        }


    }
}
