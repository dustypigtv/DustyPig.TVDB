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
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Updates.GetAsync(DateTime.Now.AddDays(-1));
            ret.ThrowIfError();
        }
    }
}
