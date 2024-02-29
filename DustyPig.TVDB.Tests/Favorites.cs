using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Tests
{
    [TestClass]
    public class Favorites
    {
        [TestMethod]
        public async Task Get()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Favorites.GetAsync();
            ret.ThrowIfError();
        }

        //No api method yet to delete favorites, and if you try to add one you already have then the test will fail.
        //So can't use this in an automated environment

        //[TestMethod]
        //public async Task Post()
        //{
        //    var client = await _Main.GetClientAsync();
        //    var ret = await _Main.ApiClient.Favorites.AddNewAsync(new Models.FavoriteRecord
        //    {
        //        Series = 279121
        //    });
        //    ret.ThrowIfError();
        //}
    }
}
