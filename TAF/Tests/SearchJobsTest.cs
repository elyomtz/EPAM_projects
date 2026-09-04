using TAF.Business;
using TAF.Test;

namespace TAF.Tests
{
    public class SearchJobsTest : BaseTest
    {

        [TestCase("java", "Argentina")]
        public void TestEpam_SearchRemoteJob(string programmingLanguage, string country)
        {
            SearchRemoteJobs searchRemoteJobs = new SearchRemoteJobs(driver);
            searchRemoteJobs.SearchRemoteJobsService(country, programmingLanguage);
            var result = searchRemoteJobs.VerifySearchRemoteJobsResultsService(programmingLanguage);
            Assert.IsTrue(result);
        }
    }
}
