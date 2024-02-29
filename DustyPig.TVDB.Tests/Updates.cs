using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
namespace DustyPig.TVDB.Tests
{
    [TestClass]
    public class Updates
    {
        [TestMethod]
        public async Task GetAll()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Updates.GetAsync(DateTime.Now.AddDays(-1));
            ret.ThrowIfError();
        }
    }
}
