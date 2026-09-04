using API.Business;
using API.Core.Configuration;
using API.Core.Logger;
using API.Tests;
using log4net;
using System.Net;

namespace API.Core.API_Test_Core
{
    public class TestBase
    {
        protected ApiClient ApiClient = null!;
        protected UserService UserService = null!;

        private readonly ILog logger = LoggerManager.Create<TestBase>();


        [SetUp]
        public void SetUp()
        {

            ApiClient = new ApiClient(ConfigurationManager.Settings.ApiTestingUrl);

            UserService = new UserService(ApiClient);

            logger.Info($"Starting test: {TestContext.CurrentContext.Test.Name}");
        }


        [TearDown]
        public void TearDown()
        {
            logger.Info($"Finished test: {TestContext.CurrentContext.Test.Name}");

            logger.Info($"Test result: {TestContext.CurrentContext.Result.Outcome.Status}");
        }
    }
}
