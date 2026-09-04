using API.Business;

namespace API.Tests
{
    public class ReadArticleTest : BaseTest
    {
        [TestCase(3)]
        public void TestEpam_ValidateTitleInsights(int clicks)
        {
            ReadArticles readArticles = new ReadArticles(driver);
            List<string> result = readArticles.ReadArticlesService(clicks);
            var testResult = readArticles.CompareTextsService(result);
            Assert.IsTrue(testResult);
        }
    }
}