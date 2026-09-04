using API.Business;

namespace API.Tests
{
    public class FileDownloadTest : BaseTest
    {

        [Test]
        public void TestEpam_FileDownload()
        {
            FileDownload fileDownload = new FileDownload(driver);
            fileDownload.FileDownloadService();
            fileDownload.WaitForFileService();
            var result = fileDownload.FileExistsService();
            Assert.IsTrue(result);
        }

    }
}
