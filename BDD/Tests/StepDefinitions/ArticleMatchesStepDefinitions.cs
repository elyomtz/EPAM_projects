using BDD.Pages;
using Reqnroll;

namespace BDD.Tests.StepDefinitions
{
    [Binding]
    public class ArticleMatchesStepDefinitions
    {
        private readonly ArticleMatches articleMatches;
        private int index;
        private List<string> slidesText;

#pragma warning disable CS8618
#pragma warning disable CS8604
        public ArticleMatchesStepDefinitions(Support.TestContext testContext)

        {
            articleMatches = new ArticleMatches(testContext.Driver);
        }
#pragma warning restore CS8604 
#pragma warning restore CS8618 
        [Given("I initialize the browser and open the website {string}")]
        public void GivenIInitializeTheBrowserAndOpenTheWebsite(string p0)
        {
            articleMatches.Navigate();
        }

        [When("I select {string} from the top menu")]
        public void WhenISelectFromTheTopMenu(string insights)
        {
            articleMatches.ClickOnInsights();
        }

        [When("I swipe the carousel two or more times {int}")]
        public void WhenISwipeTheCarouselTwoOrMoreTimes(int clicks)
        {
            index = articleMatches.ClickCarouselArrow(clicks);
            slidesText = articleMatches.GetSlidesTexts();
        }

        [When("I click the button {string}")]
        public void WhenIClickTheButton(string p0)
        {
            articleMatches.ClickReadMoreBtn(index);
        }

        [Then("I validate that the name of the article matches with the one of the carousel")]
        public void ThenIValidateThatTheNameOfTheArticleMatchesWithTheOneOfTheCarousel()
        {
            articleMatches.CompareTexts(slidesText);
        }

    }
}
