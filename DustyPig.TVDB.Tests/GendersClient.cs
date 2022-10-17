using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Tests
{
    [TestClass]
    public class GendersClient
    {
        [TestMethod]
        public async Task GetAll()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Genres.GetAllAsync();
            ret.ThrowIfError();
        }
    }
}
