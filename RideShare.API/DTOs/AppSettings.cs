namespace RideShare.API.DTOs
{
    public class AppSettings
    {
        public JWTSettings JWT { get; set; }
    }

    public class JWTSettings
    {
        public string SecretKey { get; set; }
        public int DurationSeconds { get; set; }
        public string Issuer { get; set; }
    }
}
