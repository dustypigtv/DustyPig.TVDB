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
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.UserInfo.GetAsync();
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetById()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.UserInfo.GetAsync(2328011);
            ret.ThrowIfError();
        }



    }
}
