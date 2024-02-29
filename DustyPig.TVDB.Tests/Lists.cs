using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Tests
{
    [TestClass]
    public class Lists
    {
        [TestMethod]
        public async Task GetAll()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Lists.GetAllAsync();
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task Get()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Lists.GetAsync(1);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetExtended()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Lists.GetExtendedAsync(1);
            ret.ThrowIfError();
        }
    }
}
