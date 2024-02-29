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
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.People.GetAllAsync();
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task Get()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.People.GetAsync(252097);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetExtended()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.People.GetExtendedAsync(252097);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetTranslation()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.People.GetTranslationAsync(252097, "eng");
            ret.ThrowIfError();
        }
    }
}
