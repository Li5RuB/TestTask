namespace NewsParser.Common.Settings
{
    public class AppSettings : IAppSettings
    {
        public string OnlinerLink { get; set; }

        public string BobrLink { get; set; }

        public string LentaLink { get; set; }

        public int NumberOfThreads { get; set; }
    }
}
