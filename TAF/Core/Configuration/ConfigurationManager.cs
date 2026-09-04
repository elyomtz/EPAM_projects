using Microsoft.Extensions.Configuration;

namespace TAF.Core.Configuration
{
    public static class ConfigurationManager
    {
        public static TestSettings Settings { get; }

        static ConfigurationManager()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            Settings = configuration.Get<TestSettings>()
                       ?? throw new InvalidOperationException(
                           "Could not load test settings.");
        }

    }
}
