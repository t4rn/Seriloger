namespace Seriloger.Core.Settings
{
    public class SerilogSettings
    {
        public string Uri { get; set; }
        public string LogLevel { get; set; }
        public string IndexFormat { get; set; }
        public string FileDebugPath { get; set; }
        public string FileErrorPath { get; set; }
    }
}
