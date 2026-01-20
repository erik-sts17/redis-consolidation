namespace Back.Redis.Api.Configurations.Models
{
    public class RedisSettings
    {
        public string Host { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Port { get; set; }
        public bool UseSsl { get; set; }
    }
}
