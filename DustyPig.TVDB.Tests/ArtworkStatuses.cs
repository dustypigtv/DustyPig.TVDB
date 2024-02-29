using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Tests
{
    [TestClass]
    public class ArtworkStatuses
    {
        [TestMethod]
        public async Task Getall()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.ArtworkStatuses.GetAllAsync();
            ret.ThrowIfError();
        }
    }
}
