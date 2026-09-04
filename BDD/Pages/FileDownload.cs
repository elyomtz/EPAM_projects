using BDD.Configuration;
using OpenQA.Selenium;
using System.Threading;

namespace BDD.Pages
{
    public class FileDownload : BasePage
    {
        //Locators
        private readonly By cookiesBtn = By.Id("onetrust-accept-btn-handler");
        private readonly By fileLink = By.XPath("//a[contains(@href,'code-of-')]");

        public FileDownload(IWebDriver driver) : base(driver)
        {
        }

        public void DownloadFile(string fileName)
        {
            var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            WaitAndClick(cookiesBtn);
            WaitAndClick(fileLink);
            WaitAndClick(fileLink);
        }

        public void WaitForFile(string fileName)
        {
            var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string finalPath = Path.Combine(folder, fileName);
            string tempPath = finalPath + ".crdownload";

            DateTime end = DateTime.Now.Add(TimeSpan.FromSeconds(10));

            while (DateTime.Now < end)
            {
                if (File.Exists(finalPath) && !File.Exists(tempPath))
                    return;

                Thread.Sleep(500);
            }

            throw new TimeoutException($"File '{fileName}' was not downloaded.");
        }

        public bool FileExists(string fileName)
        {
            var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            return File.Exists(Path.Combine(folder, fileName));
        }

    }
}
