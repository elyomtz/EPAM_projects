using BDD.Driver;
using OpenQA.Selenium;

namespace BDD.Support
{
    public class TestContext
    {
        private readonly DriverFactory _driverFactory;

        public IWebDriver? Driver { get; private set; }

        public TestContext(DriverFactory driverFactory)
        {
            _driverFactory = driverFactory;
        }

        public void StartDriver()
        {
            Driver = _driverFactory.CreateDriver();
        }

        public void StopDriver()
        {
            if (Driver == null)
                return;

            Driver.Quit();
            Driver.Dispose();

            Driver = null;
        }
    }
}
