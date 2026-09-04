using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace BDD.Pages
{
    public class SearchRemoteJob : BasePage
    {
        //Locators
        private readonly By careers = By.LinkText("Careers");
        private readonly By cookiesBtn = By.Id("onetrust-accept-btn-handler");
        private readonly By searchBtn = By.CssSelector(".pinned-button-text");
        private readonly By countryDropdown = By.Id("react-select-2-input");
        private readonly By searchField = By.Name("search");
        private readonly By remoteCheckbox = By.ClassName("Checkbox_labelElement___nzU3");
        private readonly By submitSearchButton = By.Name("submit_search_box_button");
        private readonly By resultElements = By.CssSelector("[class*='JobCard_labelLink']");
        private readonly By headerElement = By.TagName("h1");
        private readonly By jobDetails = By.CssSelector("[class*='JobDetails_firstSkill']");

        public SearchRemoteJob(IWebDriver driver) : base(driver)
        {
        }

        public void ClickOnCareers()
        {
            Click(careers);
        }

        public void StartSearch()
        {
            WaitAndClick(cookiesBtn);
            Driver.FindElement(searchBtn).Click();
        }

        public void SearchProgrammingLanguage(string programmingLanguage)
        {
            WaitAndClick(cookiesBtn);
            Click(searchField);
            EnterText(searchField, programmingLanguage);
        }

        public void FindCountry(string country)
        {
            try
            {
                var input = Driver.FindElement(countryDropdown);
                new Actions(Driver)
                .Click(input)
                .SendKeys(country)
                .SendKeys(Keys.Enter)
                .Perform();
            }
            catch (Exception ex)
            {
                throw new Exception($"Country not found", ex);
            }
        }

        public bool SelectRemote()
        {
            try
            {
                WaitAndClick(remoteCheckbox);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while trying to select a country: " + ex.Message);
                return false;
            }
        }

        public void SearchJob()
        {
            WaitAndClick(submitSearchButton);
        }

        public bool ClickLastElement()
        {
            IReadOnlyCollection<IWebElement> resultLanguage = WaitForElementsVisible(resultElements);

            if (resultLanguage.Count > 0)
            {
                int attempts = 0;
                while (attempts < 3)
                {
                    try
                    {
                        //Find the latest element in the list of results
                        resultLanguage = WaitForElementsVisible(resultElements);
                        resultLanguage.Last().Click();
                        break;
                    }
                    catch (OpenQA.Selenium.StaleElementReferenceException)
                    {
                        attempts++;
                        Console.WriteLine("Stale element, trying again");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Programming language not found");
                return false;
            }

            return true;
        }

        public bool FindTextFromSearch(string programmingLanguage)
        {
            WaitUntilVisible(headerElement);
            string textH1 = Driver.FindElement(headerElement).Text.ToUpper();

            WaitUntilVisible(jobDetails);
            string textJobDetails = Driver.FindElement(headerElement).Text.ToUpper();

            if (textH1.Contains(programmingLanguage.ToUpper()) || textJobDetails.Contains(programmingLanguage.ToUpper()))
            {
                Console.WriteLine($"Remote job for {programmingLanguage} found");
                return true;
            }
            else
            {
                Console.WriteLine($"Remote job for {programmingLanguage} not found in the search result");
                return false;
            }
        }

    }
}
