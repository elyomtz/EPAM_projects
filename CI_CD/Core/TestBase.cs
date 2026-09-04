using log4net;
using CI_CD.Core.API_Test_Core;
using CI_CD.Core.Logger;
using CI_CD.Core.Configuration;
using CI_CD.Business;

namespace CI_CD.Core
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
