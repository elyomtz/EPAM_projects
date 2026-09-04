using CI_CD.Business;

namespace CI_CD.Tests
{
    public class FileDownloadTest : BaseTest
    {
        [Test]
        [Category("Unit")]
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