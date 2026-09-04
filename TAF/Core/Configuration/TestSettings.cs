namespace TAF.Core.Configuration
{
    public class TestSettings
    {
        public string Url { get; set; } = string.Empty;
        public BrowserType Browser { get; set; }
        public int TimeoutSeconds { get; set; }
        public string ScreenshotPath { get; set; } = string.Empty;
        public string DownloadPath { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;

    }
}
