using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Tests
{
    [TestClass]
    public class EntityTypes
    {
        [TestMethod]
        public async Task GetAll()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.EntityTypes.GetAllAsync();
            ret.ThrowIfError();
        }
    }
}
