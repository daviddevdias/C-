namespace ReelApp
{
    public static class Config
    {
        public const string AppTitle = "Reel";
        public const string AppVersion = "1.3.5";
        public const int UrlCapturePort = 39731;

        public static readonly string[] YoutubeUrlPrefixes = {
            "https://www.youtube.com/",
            "https://youtube.com/",
            "https://youtu.be/"
        };

        public static readonly string[] AudioFormats = { "MP3", "M4A", "WAV" };
        public static readonly string[] VideoFormats = { "MP4", "WEBM", "MOV" };
    }
}