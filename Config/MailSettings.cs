namespace Portfolio.Config
{
    public record MailSettings
    {
        public string From { get; set; }
        public string PassKey { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSSL { get; set; }
        public string domain { get; set; }
        public string AdminMail { get; set; }
    }
}
