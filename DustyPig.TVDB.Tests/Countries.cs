using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Tests
{
    [TestClass]
    public class Countries
    {
        [TestMethod]
        public async Task GetAll()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Countries.GetAllAsync();
            ret.ThrowIfError();
        }
    }
}
