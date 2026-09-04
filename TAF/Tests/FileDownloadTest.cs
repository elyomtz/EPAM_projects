using TAF.Business;
using TAF.Test;

namespace TAF.Tests
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
