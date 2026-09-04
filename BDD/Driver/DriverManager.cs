using OpenQA.Selenium;

namespace BDD.Driver
{
    public class DriverManager
    {
        public IWebDriver Driver { get; }

        public DriverManager() 
        {
            Driver = new DriverFactory().CreateDriver();
        }

        public void QuitDriver()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
