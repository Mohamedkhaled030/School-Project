using Shcool.Data.Entity.Identity;
using Shcool.Data.Results;
using System.IdentityModel.Tokens.Jwt;

namespace Shcool.Service.Abstruct
{
    public interface IAuthenticationServices
    {

        public Task<JwtAuthResult> GetJwTTokenAsync(User user);
        public Task<JwtAuthResult> GetRefreshTokenAsync(User user, JwtSecurityToken JwtToken, string RefreshToken, DateTime? expierDate);
        public JwtSecurityToken ReadJwtToken(string accessToken);
        public Task<string> ValidateTokenAsync(string accessToken);
        public Task<(string, DateTime?)> ValidateDetalis(JwtSecurityToken JwtToken, string accessToken, string RefreshToken);
        public Task<string> ConfirmEmail(string userId, string code);
        public Task<string> SendResetPasswordCode(string email);
        public Task<string> ConfirmResetPasswordCode(string Code, string Email);
        public Task<string> ResetPasswordCode(string Email, string Password);

    }
}
