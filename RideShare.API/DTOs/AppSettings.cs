namespace RideShare.API.DTOs
{
    public class AppSettings
    {
        public JWTSettings JWT { get; set; }
        public EmailSettings EmailOptions { get; set; }
    }

    public class JWTSettings
    {
        public string SecretKey { get; set; }
        public int DurationSeconds { get; set; }
        public string Issuer { get; set; }
    }
    public class EmailSettings
    {
        public string FromEmail { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
    }
}
