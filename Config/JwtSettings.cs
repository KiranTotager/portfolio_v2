namespace Portfolio.Config
{
    public record JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
        public int RefreshTokenExpiryTimeAudience { get; set; }
        public int AuthTokenExpiryTime { get; set; }
    }
}
