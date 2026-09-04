using BDD.Pages;
using Reqnroll;

namespace BDD.Tests.StepDefinitions
{
    [Binding]
    public class SearchWordsStepDefinitions
    {
        private readonly SearchForWords searchForWords;

#pragma warning disable CS8604
        public SearchWordsStepDefinitions(Support.TestContext testContext)
        {
            searchForWords = new SearchForWords(testContext.Driver);
        }
#pragma warning restore CS8604

        [Given("I open the browser and navigate to {string}")]
        public void GivenIOpenTheBrowserAndNavigateTo(string p0)
        {
            searchForWords.Navigate();
        }

        [When("I find a magnifier icon and click on it")]
        public void WhenIFindAMagnifierIconAndClickOnIt()
        {
            searchForWords.FindSearchIcon();
        }

        [When("I enter the words {string}\\/{string}\\/{string} on the search box and click the Find button")]
        public void WhenIEnterTheWordsOnTheSearchBoxAndClickTheFindButton(string keyword1, string keyword2, string keyword3)
        {
            searchForWords.GlobalSearch(keyword1, keyword2, keyword3);
        }

        [Then("I validate that the words {string}\\/{string}\\/{string} appear on the results")]
        public void ThenIValidateThatTheWordsAppearOnTheResults(string keyword1, string keyword2, string keyword3)
        {
            searchForWords.ValidateResults(keyword1, keyword2, keyword3);
        }

    }
}
