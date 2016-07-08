
namespace SubtitleDownloader
{
    public struct Subtitle
    {
        public string Language, Version, Completed, Download;

        public Subtitle(string language, string version, string completed, string download)
        {
            this.Language = language;
            this.Version = version;
            this.Completed = completed;
            this.Download = download;
        }
    }
}
