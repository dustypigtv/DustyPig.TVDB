using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Tests
{
    [TestClass]
    public class Series
    {
        [TestMethod]
        public async Task GetAll()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Series.GetAllAsync();
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task Get()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Series.GetAsync(70327);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetExtended()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Series.GetExtendedAsync(70327);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetArtwork()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Series.GetArtworksAsync(70327, "eng");
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetNextAired()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Series.GetNextAiredAsync(70327);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetEpisodes()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Series.GetEpisodesAsync(70327);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetEpisodesTranslated()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Series.GetSeasonEpisodesTranslatedAsync(70327, Models.SeasonTypes.Official, "eng");
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task Filter()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Series.FilterAsync("US", "eng", year: 1997);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetSlug()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Series.GetAsync("arrow");
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetTranslation()
        {
            await _Main.WaitForToken();
            var ret = await _Main.ApiClient.Series.GetTranslationAsync(70327, "eng");
            ret.ThrowIfError();
        }

    }
}
