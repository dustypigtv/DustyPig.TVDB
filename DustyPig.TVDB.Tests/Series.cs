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
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Series.GetAllAsync();
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task Get()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Series.GetAsync(70327);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetExtended()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Series.GetExtendedAsync(70327);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetArtwork()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Series.GetArtworksAsync(70327, "eng");
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetNextAired()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Series.GetNextAiredAsync(70327);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetEpisodes()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Series.GetEpisodesAsync(70327);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetEpisodesTranslated()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Series.GetSeasonEpisodesTranslatedAsync(70327, Models.SeasonTypes.Official, "eng");
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task Filter()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Series.FilterAsync("US", "eng", year: 1997);
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetSlug()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Series.GetAsync("arrow");
            ret.ThrowIfError();
        }

        [TestMethod]
        public async Task GetTranslation()
        {
            var client = await _ClientFactory.GetClientAsync();
            var ret = await client.Series.GetTranslationAsync(70327, "eng");
            ret.ThrowIfError();
        }

    }
}
