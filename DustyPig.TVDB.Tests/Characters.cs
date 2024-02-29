using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Tests
{
    [TestClass]
    public class Characters
    {
        [TestMethod]
        public async Task Get()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Characters.GetAsync(64971827);
            ret.ThrowIfError();
        }
    }
}
