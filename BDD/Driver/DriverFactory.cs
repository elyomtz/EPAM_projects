using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BDD.Driver
{
    public class DriverFactory
    {
        private static IWebDriver? driver;

        public IWebDriver CreateDriver()
        {
            var downloadFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", downloadFolder);
            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            chromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
            chromeOptions.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
            chromeOptions.AddUserProfilePreference("safebrowsing.enabled", true);
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }

    }
}
