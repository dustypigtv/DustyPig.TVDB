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
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.ArtworkStatuses.GetAllAsync();
            ret.ThrowIfError();
        }
    }
}
