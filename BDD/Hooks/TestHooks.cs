using Reqnroll;

namespace BDD.Hooks
{
    [Binding]
    public class TestHooks
    {
        private readonly Support.TestContext _testContext;

        public TestHooks(Support.TestContext testContext)
        {
            _testContext = testContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _testContext.StartDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _testContext.StopDriver();
        }
    }
}
