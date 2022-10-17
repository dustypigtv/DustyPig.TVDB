using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Tests
{
    [TestClass]
    public class Artwork
    {
        [TestMethod]
        public async Task GetArtworkBase()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Artwork.GetAsync(25430);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetArtworkExtended()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Artwork.GetExtendedAsync(25430);
            ret.ThrowIfError();
        }
    }
}
