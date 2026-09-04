using Reqnroll;
using BDD.Pages;

namespace BDD.Tests.StepDefinitions
{
    [Binding]
    public class SearchRemoteJobsStepDefinitions
    {
        private readonly SearchRemoteJob searchRemoteJob;
#pragma warning disable CS8604
        public SearchRemoteJobsStepDefinitions(Support.TestContext testContext) 
        {
            searchRemoteJob = new SearchRemoteJob(testContext.Driver);
        }
#pragma warning restore CS8604

        [Given("I start the browser and go to {string}")]
        public void GivenIStartTheBrowserAndGoTo(string p0)
        {
            searchRemoteJob.Navigate();
        }

        [When("I click on the {string} link")]
        public void WhenIClickOnTheLink(string careers)
        {
            searchRemoteJob.ClickOnCareers();
        }

        [When("I click on the button {string}")]
        public void WhenIClickOnTheButton(string button)
        {
            switch (button) 
            {
                case "Start your search here":
                    searchRemoteJob.StartSearch();
                    break;
                case "Search":
                    searchRemoteJob.SearchJob(); 
                    break;
                default:
                    throw new ArgumentException($"Unknown button: {button}");
            }
        }

        [When("I enter any programming language {string} in the field {string}")]
        public void WhenIEnterAnyProgrammingLanguageInTheField(string programming_language, string p1)
        {
            searchRemoteJob.SearchProgrammingLanguage(programming_language);
        }

        [When("I select a country {string} in the field {string}")]
        public void WhenISelectACountryInTheField(string country, string p1)
        {
            searchRemoteJob.FindCountry(country);
        }

        [When("I Select option {string}")]
        public void WhenISelectOption(string remote)
        {
            searchRemoteJob.SelectRemote();
        }


        [When("I click on latest element in the list of results")]
        public void WhenIClickOnLatestElementInTheListOfResults()
        {
            searchRemoteJob.ClickLastElement();
        }

        [Then("I expand the element and validate that programming language {string} from search is present")]
        public void ThenIExpandTheElementAndValidateThatProgrammingLanguageFromSearchIsPresent(string programming_language)
        {
            searchRemoteJob.FindTextFromSearch(programming_language);
        }

    }
}
