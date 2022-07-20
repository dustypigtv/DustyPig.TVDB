using DustyPig.TVDB.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Tests
{
    [TestClass]
    public class UnitTests
    {

        const string ENV_KEY_VARIABLE = "TVDB_API_KEY";

        const string ENV_PIN_VARIABLE = "TVDB_API_PIN";

        private static string GetEnvVar(string name)
        {
            string ret = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);

            if (string.IsNullOrWhiteSpace(ret))
                ret = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User);

            if (string.IsNullOrWhiteSpace(ret))
                ret = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Machine);

            return ret;
        }


        static Client _client = new Client();
        static bool LoggedIn = false;
        static bool LoggingIn = false;

        private static async Task WaitForToken()
        {
            Client.AutoThrowIfError = true;
            Client.IncludeRawContentInResponse = true;

            while (!LoggedIn)
            {
                if (!LoggingIn)
                {
                    LoggingIn = true;

                    var creds = new Credentials
                    {
                        Apikey = GetEnvVar(ENV_KEY_VARIABLE),
                        Pin = GetEnvVar(ENV_PIN_VARIABLE)
                    };
                    var response = await _client.LoginAsync(creds);
                    response.ThrowIfError();

                    LoggedIn = true;
                }
                await Task.Delay(100);
            }
        }

        [TestMethod]
        public async Task GetAllArtworkStatuses()
        {
            await WaitForToken();
            var response = await _client.GetAllArtworkStatusesAsync();
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAllArtworkTypes()
        {
            await WaitForToken();
            var response = await _client.GetAllArtworkTypesAsync();
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAllAwards()
        {
            await WaitForToken();
            var response = await _client.GetAllAwardsAsync();
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAllCompanies()
        {
            await WaitForToken();
            var response = await _client.GetAllCompaniesAsync(0);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAllCompanyTypes()
        {
            await WaitForToken();
            var response = await _client.GetAllCompanyTypesAsync();
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAllContentRatings()
        {
            await WaitForToken();
            var response = await _client.GetAllContentRatingsAsync();
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAllCountries()
        {
            await WaitForToken();
            var response = await _client.GetAllCountriesAsync();
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAllGenders()
        {
            await WaitForToken();
            var response = await _client.GetAllGendersAsync();
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAllGenres()
        {
            await WaitForToken();
            var response = await _client.GetAllGenresAsync();
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAllInspirationTypes()
        {
            await WaitForToken();
            var response = await _client.GetAllInspirationTypesAsync();
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAllLanguages()
        {
            await WaitForToken();
            var response = await _client.GetAllLanguagesAsync();
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAllLists()
        {
            await WaitForToken();
            var response = await _client.GetAllListsAsync(0);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAllMovies()
        {
            await WaitForToken();
            var response = await _client.GetAllMovieAsync(0);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAllMovieStatuses()
        {
            await WaitForToken();
            var response = await _client.GetAllMovieStatusesAsync();
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAllPeopleTypes()
        {
            await WaitForToken();
            var response = await _client.GetAllPeopleTypesAsync();
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAllSeasons()
        {
            await WaitForToken();
            var response = await _client.GetAllSeasonsAsync(0);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAllSeries()
        {
            await WaitForToken();
            var response = await _client.GetAllSeriesAsync(0);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAllSeriesStatuses()
        {
            await WaitForToken();
            var response = await _client.GetAllSeriesStatusesAsync();
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAllSourceTypes()
        {
            await WaitForToken();
            var response = await _client.GetAllSourceTypesAsync();
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetArtworkBase()
        {
            await WaitForToken();
            var response = await _client.GetArtworkBaseAsync(25430);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetArtworkExtended()
        {
            await WaitForToken();
            var response = await _client.GetArtworkExtendedAsync(25430);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAward()
        {
            await WaitForToken();
            var response = await _client.GetAwardAsync(1);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAwardCategory()
        {
            await WaitForToken();
            var response = await _client.GetAwardCategoryAsync(1);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAwardCategoryExtended()
        {
            await WaitForToken();
            var response = await _client.GetAwardCategoryExtendedAsync(1);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetAwardExtended()
        {
            await WaitForToken();
            var response = await _client.GetAwardExtendedAsync(1);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetCharacterBase()
        {
            await WaitForToken();
            var response = await _client.GetCharacterBaseAsync(64971827);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetCompany()
        {
            await WaitForToken();
            var response = await _client.GetCompanyAsync(265);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetEntityTypes()
        {
            await WaitForToken();
            var response = await _client.GetEntityTypesAsync();
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetEpisodeBase()
        {
            await WaitForToken();
            var response = await _client.GetEpisodeBaseAsync(2);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetEpisodeExtended()
        {
            await WaitForToken();
            var response = await _client.GetEpisodeExtendedAsync(2);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetEpisodeTranslation()
        {
            await WaitForToken();
            var response = await _client.GetEpisodeTranslationAsync(2, "spa");
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetGenreBase()
        {
            await WaitForToken();
            var response = await _client.GetGenreBaseAsync(1);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetList()
        {
            await WaitForToken();
            var response = await _client.GetListAsync(1);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetListExtended()
        {
            await WaitForToken();
            var response = await _client.GetListExtendedAsync(1);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetListTranslation()
        {
            await WaitForToken();
            var response = await _client.GetListTranslationAsync(1, "spa");
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetMovieBase()
        {
            await WaitForToken();
            var response = await _client.GetMovieBaseAsync(3033);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetMovieExtended()
        {
            await WaitForToken();
            var response = await _client.GetMovieExtendedAsync(3033);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetMovieTranslation()
        {
            await WaitForToken();
            var response = await _client.GetMovieTranslationAsync(3033, "spa");
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetPeopleBase()
        {
            await WaitForToken();
            var response = await _client.GetPeopleBaseAsync(252097);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetPeopleExtended()
        {
            await WaitForToken();
            var response = await _client.GetPeopleExtendedAsync(252097);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetPeopleTranslation()
        {
            await WaitForToken();
            var response = await _client.GetPeopleTranslationAsync(252097, "spa");
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetSearchResults()
        {
            await WaitForToken();
            var response = await _client.GetSearchResultsAsync("Buffy the Vampire Slayer");
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetSeasonBase()
        {
            await WaitForToken();
            var response = await _client.GetSeasonBaseAsync(10);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetSeasonExtended()
        {
            await WaitForToken();
            var response = await _client.GetSeasonExtendedAsync(10);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetSeasonTranslation()
        {
            await WaitForToken();
            var response = await _client.GetSeasonTranslationAsync(10, "ita");
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetSeasonTypes()
        {
            await WaitForToken();
            var response = await _client.GetSeasonTypesAsync();
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetSeriesBase()
        {
            await WaitForToken();
            var response = await _client.GetSeriesBaseAsync(70327);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetSeriesEpisodes()
        {
            await WaitForToken();
            var response = await _client.GetSeriesEpisodesAsync(70327);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetSeriesExtended()
        {
            await WaitForToken();
            var response = await _client.GetSeriesExtendedAsync(70327);
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetSeriesSeasonEpisodesTranslated()
        {
            await WaitForToken();
            var response = await _client.GetSeriesSeasonEpisodesTranslatedAsync(70327, SeasonTypes.Default, "spa");
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetSeriesTranslation()
        {
            await WaitForToken();
            var response = await _client.GetSeriesTranslationAsync(70327, "spa");
            response.ThrowIfError();
        }

        [TestMethod]
        public async Task GetUpdates()
        {
            await WaitForToken();
            var response = await _client.GetUpdatesAsync(DateTime.Now.AddDays(-1), page: 0);
            response.ThrowIfError();
        }
    }
}
