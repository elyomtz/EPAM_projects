using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using BDD.Configuration;

namespace BDD.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver { get; }
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }
        public void Navigate()
        {
            var url = ConfigurationManager.Settings.Url;
            Driver.Navigate().GoToUrl(url);
        }

        protected IWebElement WaitForElement(By locator)
        {
            try
            {
                return wait.Until(Driver => Driver.FindElement(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new Exception($"Element not found: {locator}", ex);
            }
        }

        public void Click(By locator)
        {
            try
            {
                WaitForElement(locator).Click();
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to click element: {locator}", ex);
            }
        }

        protected void EnterText(By locator, string text)
        {
            try
            {
                var element = WaitUntilVisible(locator);
                element.Clear();
                element.SendKeys(text);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to enter text in: {locator}", ex);
            }
        }

        protected void WaitAndClick(By locator)
        {
            int attempts = 0;
            var explicitWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromSeconds(0.25)
            };

            while (attempts < 3)
            {
                try
                {
                    IWebElement elemToFound = explicitWait.Until(Driver =>
                    {
                        var elem = Driver.FindElement(locator);
                        return elem.Displayed ? elem : null;
                    });
                    elemToFound.Click();
                    break;
                }
                catch (Exception)
                {
                    attempts++;
                    Console.WriteLine("Element not found, trying again");
                }
            }
        }

        public IWebElement WaitUntilVisible(By locator)
        {
            return wait.Until(Driver =>
            {
                var element = Driver.FindElement(locator);

                return element.Displayed
                    ? element
                    : null;
            })!;
        }

        public IReadOnlyCollection<IWebElement> WaitForElementsVisible(By locator)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            return wait.Until(d =>
            {
                var elements = d.FindElements(locator);

                return elements.Count > 0 && elements.All(e => e.Displayed)
                    ? elements
                    : null;
            });
        }

    }
}
