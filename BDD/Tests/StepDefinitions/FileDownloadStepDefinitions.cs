using Reqnroll;
using BDD.Pages;
using BDD.Configuration;

namespace BDD.Tests.StepDefinitions
{
    [Binding]
    public class FileDownloadStepDefinitions
    {
        private readonly FileDownload fileDownload;
        readonly string fileName = ConfigurationManager.Settings.FileName;

#pragma warning disable CS8604
        public FileDownloadStepDefinitions(Support.TestContext testContext) 
        {
            fileDownload = new FileDownload(testContext.Driver);
        }
#pragma warning restore CS8604

        [Given("I open the browser and I access the website {string}")]
        public void GivenIOpenTheBrowserAndIAccessTheWebsite(string p0)
        {
            fileDownload.Navigate();
        }

        [When("I click on the {string} in {string} section")]
        public void WhenIClickOnTheInSection(string p0, string policies)
        {
            fileDownload.DownloadFile(fileName);
        }

        [When("I wait for a document to be downloaded")]
        public void WhenIWaitForADocumentToBeDownloaded()
        {
            fileDownload.WaitForFile(fileName);
        }

        [Then("I validate that the document is downloaded and named {string}")]
        public void ThenIValidateThatTheDocumentIsDownloadedAndNamed(string p0)
        {
            fileDownload.FileExists(fileName);
        }

    }
}
