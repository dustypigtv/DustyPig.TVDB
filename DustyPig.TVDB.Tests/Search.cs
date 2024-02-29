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
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Search.SearchAsync("Buffy the Vampire Slayer", language: "eng");
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task SearchByRemoteId()
        {
            //60735
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Search.SearchByRemoteIdAsync("60735");
            ret.ThrowIfError();
        }
    }
}
