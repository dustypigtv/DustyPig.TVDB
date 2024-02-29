using DustyPig.TVDB.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace DustyPig.TVDB.Tests
{
    [TestClass]
#pragma warning disable IDE1006 // Naming Styles
    public class _Main
#pragma warning restore IDE1006 // Naming Styles
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


        public static Client ApiClient { get; } = new Client();
        static bool LoggedIn = false;
        static bool LoggingIn = false;

        public static async Task WaitForToken()
        {
            ApiClient.IncludeRawContentInResponse = true;

            while (!LoggedIn)
            {
                if (!LoggingIn)
                {
                    LoggingIn = true;

                    await ApiClient.Login.LoginAsync(new Credentials
                    {
                        Apikey = GetEnvVar(ENV_KEY_VARIABLE),
                        Pin = GetEnvVar(ENV_PIN_VARIABLE)
                    });

                    LoggedIn = true;
                }
                await Task.Delay(100);
            }
        }

    }
}
