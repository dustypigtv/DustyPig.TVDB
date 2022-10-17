using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Tests
{
    [TestClass]
    public class Search
    {
        [TestMethod]
        public async Task SearchMovie()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Search.SearchAsync("Buffy the Vampire Slayer", language: "eng");
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task SearchByRemoteId()
        {
            //60735
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Search.SearchByRemoteIdAsync("60735");
            ret.ThrowIfError();
        }
    }
}
