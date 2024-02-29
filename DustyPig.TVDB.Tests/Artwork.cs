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
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Artwork.GetAsync(25430);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetArtworkExtended()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Artwork.GetExtendedAsync(25430);
            ret.ThrowIfError();
        }
    }
}
