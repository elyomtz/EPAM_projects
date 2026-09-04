using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace BDD.Pages
{
    public class SearchForWords : BasePage
    {

        //Locators
        private readonly By searchIconBtn = By.ClassName("search-icon");
        private readonly By findBtn = By.XPath(".//*[@class='search-results__input-holder']/following-sibling::button");
        private readonly By headerSearchPanel = By.ClassName("header-search__panel");
        private readonly By searchInputPanel = By.Name("q");
        private readonly By resultsLinks = By.ClassName("search-results__item");

        public SearchForWords(IWebDriver driver) : base(driver)
        {
        }

        public void FindSearchIcon()
        {
            IWebElement searchIcon = Driver.FindElement(searchIconBtn);
            searchIcon.Click();
        }

        public void GlobalSearch(string keyword1, string keyword2, string keyword3)
        {
            var searchPanelWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2))
            {
                PollingInterval = TimeSpan.FromSeconds(0.25),
                Message = "Search panel has not been found"
            };

            var searchPanel = searchPanelWait.Until(driver => driver.FindElement(headerSearchPanel));
            var searchInput = searchPanel.FindElement(searchInputPanel);
            var clickAndSendKeysActions = new Actions(Driver);
            clickAndSendKeysActions.Click(searchInput)
                .Pause(TimeSpan.FromSeconds(1))
                .SendKeys(keyword1 + "/" + keyword2 + "/" + keyword3)
                .Perform();
            //Click “Find” button
            var findButton = searchPanel.FindElement(findBtn);
            findButton.Click();
        }

        public bool ValidateResults(string keyword1, string keyword2, string keyword3)
        {
            // Find all search result links
            var results = Driver.FindElements(resultsLinks);

            string[] keywords = { keyword1, keyword2, keyword3 };

            // Validate that all links in a list contain a word “BLOCKCHAIN”/”Cloud”/”Automation” in the text
            bool allResultsValid = results.All(result =>
                keywords.Any(keyword =>
                    result.Text.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0));

            if (allResultsValid)
            {
                Console.WriteLine("All search results contain one of the required keywords.");
                return true;
            }
            else
            {
                Console.WriteLine("Some search results do not contain the required keywords.");
                return false;
            }
        }
    }
}
