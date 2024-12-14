namespace Shcool.Data.Helper
{
    public class JwtSettings
    {
        public string secret { get; set; }
        public string issure { get; set; }
        public string audience { get; set; }
        public bool ValidateAudience { get; set; }
        public bool ValidateIssure { get; set; }
        public bool ValidateLifetime { get; set; }
        public bool ValidateIssureSigningKey { get; set; }
        public int AccessTokenExpireDate { get; set; }
        public int RefreshTokenExpireDate { get; set; }
    }
}
