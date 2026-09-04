using Microsoft.Extensions.Configuration;

namespace BDD.Configuration
{
    public static class ConfigurationManager
    {
        public static TestSettings Settings { get; }

        static ConfigurationManager()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            Settings = configuration.Get<TestSettings>()
                       ?? throw new InvalidOperationException(
                           "Could not load test settings.");
        }
    }
}
