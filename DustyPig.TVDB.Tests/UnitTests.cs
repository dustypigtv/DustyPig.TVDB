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

                    await _client.LoginAsync(new Credentials
                    {
                        Apikey = GetEnvVar(ENV_KEY_VARIABLE),
                        Pin = GetEnvVar(ENV_PIN_VARIABLE)
                    });

                    LoggedIn = true;
                }
                await Task.Delay(100);
            }
        }

        [TestMethod]
        public async Task GetAllArtworkStatuses()
        {
            await WaitForToken();
            await _client.GetAllArtworkStatusesAsync();
        }

        [TestMethod]
        public async Task GetAllArtworkTypes()
        {
            await WaitForToken();
            await _client.GetAllArtworkTypesAsync();
        }

        [TestMethod]
        public async Task GetAllAwards()
        {
            await WaitForToken();
            await _client.GetAllAwardsAsync();
        }

        [TestMethod]
        public async Task GetAllCompanies()
        {
            await WaitForToken();
            await _client.GetAllCompaniesAsync(0);
        }

        [TestMethod]
        public async Task GetAllCompanyTypes()
        {
            await WaitForToken();
            await _client.GetAllCompanyTypesAsync();
        }

        [TestMethod]
        public async Task GetAllContentRatings()
        {
            await WaitForToken();
            await _client.GetAllContentRatingsAsync();
        }

        [TestMethod]
        public async Task GetAllCountries()
        {
            await WaitForToken();
            await _client.GetAllCountriesAsync();
        }

        [TestMethod]
        public async Task GetAllGenders()
        {
            await WaitForToken();
            await _client.GetAllGendersAsync();
        }

        [TestMethod]
        public async Task GetAllGenres()
        {
            await WaitForToken();
            await _client.GetAllGenresAsync();
        }

        [TestMethod]
        public async Task GetAllInspirationTypes()
        {
            await WaitForToken();
            await _client.GetAllInspirationTypesAsync();
        }

        [TestMethod]
        public async Task GetAllLanguages()
        {
            await WaitForToken();
            await _client.GetAllLanguagesAsync();
        }

        [TestMethod]
        public async Task GetAllLists()
        {
            await WaitForToken();
            await _client.GetAllListsAsync(0);
        }

        [TestMethod]
        public async Task GetAllMovies()
        {
            await WaitForToken();
            await _client.GetAllMovieAsync(0);
        }

        [TestMethod]
        public async Task GetAllMovieStatuses()
        {
            await WaitForToken();
            await _client.GetAllMovieStatusesAsync();
        }

        [TestMethod]
        public async Task GetAllPeopleTypes()
        {
            await WaitForToken();
            await _client.GetAllPeopleTypesAsync();
        }

        [TestMethod]
        public async Task GetAllSeasons()
        {
            await WaitForToken();
            await _client.GetAllSeasonsAsync(0);
        }

        [TestMethod]
        public async Task GetAllSeries()
        {
            await WaitForToken();
            await _client.GetAllSeriesAsync(0);
        }

        [TestMethod]
        public async Task GetAllSeriesStatuses()
        {
            await WaitForToken();
            await _client.GetAllSeriesStatusesAsync();
        }

        [TestMethod]
        public async Task GetAllSourceTypes()
        {
            await WaitForToken();
            await _client.GetAllSourceTypesAsync();
        }

        [TestMethod]
        public async Task GetArtworkBase()
        {
            await WaitForToken();
            await _client.GetArtworkBaseAsync(25430);
        }

        [TestMethod]
        public async Task GetArtworkExtended()
        {
            await WaitForToken();
            await _client.GetArtworkExtendedAsync(25430);
        }

        [TestMethod]
        public async Task GetAward()
        {
            await WaitForToken();
            await _client.GetAwardAsync(1);
        }

        [TestMethod]
        public async Task GetAwardCategory()
        {
            await WaitForToken();
            await _client.GetAwardCategoryAsync(1);
        }

        [TestMethod]
        public async Task GetAwardCategoryExtended()
        {
            await WaitForToken();
            await _client.GetAwardCategoryExtendedAsync(1);
        }

        [TestMethod]
        public async Task GetAwardExtended()
        {
            await WaitForToken();
            await _client.GetAwardExtendedAsync(1);
        }

        [TestMethod]
        public async Task GetCharacterBase()
        {
            await WaitForToken();
            await _client.GetCharacterBaseAsync(64971827);
        }

        [TestMethod]
        public async Task GetCompany()
        {
            await WaitForToken();
            await _client.GetCompanyAsync(265);
        }

        [TestMethod]
        public async Task GetEntityTypes()
        {
            await WaitForToken();
            await _client.GetEntityTypesAsync();
        }

        [TestMethod]
        public async Task GetEpisodeBase()
        {
            await WaitForToken();
            await _client.GetEpisodeBaseAsync(2);
        }

        [TestMethod]
        public async Task GetEpisodeExtended()
        {
            await WaitForToken();
            await _client.GetEpisodeExtendedAsync(2);
        }

        [TestMethod]
        public async Task GetEpisodeTranslation()
        {
            await WaitForToken();
            await _client.GetEpisodeTranslationAsync(2, "spa");
        }

        [TestMethod]
        public async Task GetGenreBase()
        {
            await WaitForToken();
            await _client.GetGenreBaseAsync(1);
        }

        [TestMethod]
        public async Task GetList()
        {
            await WaitForToken();
            await _client.GetListAsync(1);
        }

        [TestMethod]
        public async Task GetListExtended()
        {
            await WaitForToken();
            await _client.GetListExtendedAsync(1);
        }

        [TestMethod]
        public async Task GetListTranslation()
        {
            await WaitForToken();
            await _client.GetListTranslationAsync(1, "spa");
        }

        [TestMethod]
        public async Task GetMovieBase()
        {
            await WaitForToken();
            await _client.GetMovieBaseAsync(3033);
        }

        [TestMethod]
        public async Task GetMovieExtended()
        {
            await WaitForToken();
            await _client.GetMovieExtendedAsync(3033);
        }

        [TestMethod]
        public async Task GetMovieTranslation()
        {
            await WaitForToken();
            await _client.GetMovieTranslationAsync(3033, "spa");
        }

        [TestMethod]
        public async Task GetPeopleBase()
        {
            await WaitForToken();
            await _client.GetPeopleBaseAsync(252097);
        }

        [TestMethod]
        public async Task GetPeopleExtended()
        {
            await WaitForToken();
            await _client.GetPeopleExtendedAsync(252097);
        }

        [TestMethod]
        public async Task GetPeopleTranslation()
        {
            await WaitForToken();
            await _client.GetPeopleTranslationAsync(252097, "spa");
        }

        [TestMethod]
        public async Task GetSearchResults()
        {
            await WaitForToken();
            await _client.GetSearchResultsAsync("Buffy the Vampire Slayer");
        }

        [TestMethod]
        public async Task GetSeasonBase()
        {
            await WaitForToken();
            await _client.GetSeasonBaseAsync(10);
        }

        [TestMethod]
        public async Task GetSeasonExtended()
        {
            await WaitForToken();
            await _client.GetSeasonExtendedAsync(10);
        }

        [TestMethod]
        public async Task GetSeasonTranslation()
        {
            await WaitForToken();
            await _client.GetSeasonTranslationAsync(10, "ita");
        }

        [TestMethod]
        public async Task GetSeasonTypes()
        {
            await WaitForToken();
            await _client.GetSeasonTypesAsync();
        }

        [TestMethod]
        public async Task GetSeriesBase()
        {
            await WaitForToken();
            await _client.GetSeriesBaseAsync(70327);
        }

        [TestMethod]
        public async Task GetSeriesEpisodes()
        {
            await WaitForToken();
            await _client.GetSeriesEpisodesAsync(70327);
        }

        [TestMethod]
        public async Task GetSeriesExtended()
        {
            await WaitForToken();
            await _client.GetSeriesExtendedAsync(70327);
        }

        [TestMethod]
        public async Task GetSeriesSeasonEpisodesTranslated()
        {
            await WaitForToken();
            await _client.GetSeriesSeasonEpisodesTranslatedAsync(70327, SeasonTypes.Default, "spa");
        }

        [TestMethod]
        public async Task GetSeriesTranslation()
        {
            await WaitForToken();
            await _client.GetSeriesTranslationAsync(70327, "spa");
        }

        [TestMethod]
        public async Task GetUpdates()
        {
            await WaitForToken();
            await _client.GetUpdatesAsync(DateTime.Now.AddDays(-1), page: 0);
        }
    }
}
