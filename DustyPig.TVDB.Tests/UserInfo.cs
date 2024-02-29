using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Tests
{
    [TestClass]
    public class UserInfo
    {
        [TestMethod]
        public async Task Get()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.UserInfo.GetAsync();
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetById()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.UserInfo.GetAsync(2328011);
            ret.ThrowIfError();
        }



    }
}
