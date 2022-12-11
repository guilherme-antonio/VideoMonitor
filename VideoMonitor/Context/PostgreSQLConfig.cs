namespace VideoMonitor.Context
{
    public class PostgreSQLConfig
    {
        public const string Config = "PostgreSQLConfig";

        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
    }
}
