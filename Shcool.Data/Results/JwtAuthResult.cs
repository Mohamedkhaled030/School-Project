namespace Shcool.Data.Results
{
    public class JwtAuthResult
    {
        public string AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
    public class RefreshToken
    {
        public string UserName { get; set; }
        public string StringToken { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
