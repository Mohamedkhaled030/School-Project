using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shcool.Data.Entity.Identity;
using Shcool.Data.Helper;
using Shcool.Data.Results;
using Shcool.Infrustructure.Abstruct;
using Shcool.Infrustructure.Application_Data;
using Shcool.Service.Abstruct;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Shcool.Service.Implementations
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly JwtSettings _jwtsettings;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly UserManager<User> _userManager;
        private readonly IEmailsService _emailsService;
        private readonly ApplicationDbContext _dbContext;

        //private readonly ConcurrentDictionary<string, RefreshToken> _UserRefreshToken;
        public AuthenticationServices(JwtSettings jwtSettings, IRefreshTokenRepository refreshTokenRepository, UserManager<User> userManager, IEmailsService emailsService, ApplicationDbContext dbContext)
        {
            _jwtsettings = jwtSettings;
            _refreshTokenRepository = refreshTokenRepository;
            _userManager = userManager;
            _emailsService = emailsService;
            _dbContext = dbContext;
            //_UserRefreshToken = new ConcurrentDictionary<string, RefreshToken>();
        }
        public async Task<JwtAuthResult> GetJwTTokenAsync(User user)
        {
            var (JwtToken, accessToken) = await GenerateJwtToken(user);


            var RefreshToken = new RefreshToken()
            {
                UserName = user.UserName,
                ExpireAt = DateTime.Now.AddDays(_jwtsettings.RefreshTokenExpireDate),
                StringToken = GenerateRefreshToken()
            };
            //_UserRefreshToken.AddOrUpdate(RefreshToken.StringToken, RefreshToken, (s, t) => RefreshToken);
            var UserRefreshToken = new UserRefreshToken()
            {
                AddedTime = DateTime.UtcNow,
                ExpiryDate = DateTime.Now.AddDays(_jwtsettings.RefreshTokenExpireDate),
                IsRevoked = false,
                IsUsed = true,
                RefreshToken = RefreshToken.StringToken,
                Token = accessToken,
                UserId = user.Id,
                JwtId = JwtToken.Id,
            };
            await _refreshTokenRepository.AddAsync(UserRefreshToken);
            var Response = new JwtAuthResult();
            Response.AccessToken = accessToken;
            Response.RefreshToken = RefreshToken;
            return Response;
        }

        private async Task<(JwtSecurityToken, string)> GenerateJwtToken(User user)
        {

            var claims = await GetClaims(user);
            var JwtToken = new JwtSecurityToken(_jwtsettings.issure, _jwtsettings.audience,
                              claims, expires: DateTime.Now.AddDays(_jwtsettings.AccessTokenExpireDate),
                              signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes
                              (_jwtsettings.secret)), SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(JwtToken);
            return (JwtToken, accessToken);
        }
        private async Task<List<Claim>> GetClaims(User user)
        {
            var role = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>()
            {
                new Claim(nameof(UserClaimModel.id),user.Id),
                new Claim(nameof(UserClaimModel.PhoneNumber),user.PhoneNumber),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),



            };
            foreach (var rols in role)
            {
                claims.Add(new Claim(ClaimTypes.Role, rols));
            }
            var claimsUser = await _userManager.GetClaimsAsync(user);
            claims.AddRange(claimsUser);
            return claims;
        }
        private string GenerateRefreshToken()
        {
            var RandmNumber = new byte[32];
            var RandonGenerateNumber = RandomNumberGenerator.Create();
            RandonGenerateNumber.GetBytes(RandmNumber);
            return Convert.ToBase64String(RandmNumber);
        }
        public async Task<JwtAuthResult> GetRefreshTokenAsync(User user, JwtSecurityToken JwtToken, string RefreshToken, DateTime? expiredata)
        {
            //read token to get clims

            //cenerate refresh token
            var (jwtSecurtyToken, newToken) = await GenerateJwtToken(user);

            var response = new JwtAuthResult();
            response.AccessToken = newToken;

            var refreshTokenResult = new RefreshToken();
            refreshTokenResult.UserName = JwtToken.Claims.FirstOrDefault(x => x.Type == (nameof(UserClaimModel.UserName))).Value;
            refreshTokenResult.ExpireAt = (DateTime)expiredata;
            refreshTokenResult.StringToken = RefreshToken;

            response.RefreshToken = refreshTokenResult;
            return response;
        }
        public async Task<string> ValidateTokenAsync(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();


            var parameter = new TokenValidationParameters()
            {
                ValidateIssuer = _jwtsettings.ValidateIssure,
                ValidIssuers = new[] { _jwtsettings.issure },
                ValidateIssuerSigningKey = _jwtsettings.ValidateIssureSigningKey,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtsettings.secret)),
                ValidAudience = _jwtsettings.audience,
                ValidateAudience = _jwtsettings.ValidateAudience,
                ValidateLifetime = _jwtsettings.ValidateLifetime
            };
            var validtor = handler.ValidateToken(accessToken, parameter, out SecurityToken validatedToken);
            try
            {
                if (validatedToken == null)
                    return "Invalid Token";
                return "Not Expier";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public JwtSecurityToken ReadJwtToken(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException(nameof(accessToken));
            var handler = new JwtSecurityTokenHandler();

            var response = handler.ReadJwtToken(accessToken);

            return response;
        }

        public async Task<(string, DateTime?)> ValidateDetalis(JwtSecurityToken JwtToken, string accessToken, string RefreshToken)
        {
            if (JwtToken == null || !JwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
                return ("AlgorithmsNotEqual", null);
            if (JwtToken.ValidTo > DateTime.UtcNow)
                return ("TokenisNotExpiare", null);

            //get user

            var userid = JwtToken.Claims.FirstOrDefault(x => x.Type == (nameof(UserClaimModel.id))).Value;
            var userRefreshToken = await _refreshTokenRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.Token == accessToken &&
                                                                          x.RefreshToken == RefreshToken &&
                                                                          x.UserId == userid);
            //validation token ,refreshtoken  
            if (userRefreshToken == null)
                return ("RefreshtokenisNotFound", null);
            if (userRefreshToken.ExpiryDate < DateTime.UtcNow)
            {
                userRefreshToken.IsRevoked = true;
                userRefreshToken.IsUsed = false;
                await _refreshTokenRepository.UpdateAsync(userRefreshToken);
                return ("RefreshTokenisExpiare", null);
            }
            var expairdate = userRefreshToken.ExpiryDate;
            return (userid, expairdate);
        }

        public async Task<string> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
                return "EroorConfirmEmail";
            var user = await _userManager.FindByIdAsync(userId);
            var confirmEmail = await _userManager.ConfirmEmailAsync(user, code);
            if (!confirmEmail.Succeeded)
                return "EroorConfirmEmail";
            return "Success";
        }

        public async Task<string> SendResetPasswordCode(string email)
        {
            var trans = _dbContext.Database.BeginTransaction();
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null) return "UserNotFound";
                var generate = new Random();
                var randomNumber = generate.Next(0, 100000).ToString("D6");
                user.Code = randomNumber;
                var UpdateResult = await _userManager.UpdateAsync(user);
                if (!UpdateResult.Succeeded) return "ErroreUpdateUser";
                var message = "Code To Rest Password : " + user.Code;

                await _emailsService.SendEmailAsync(user.Email, message, "Reast Password");
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "Faild";
            }

        }

        public async Task<string> ConfirmResetPasswordCode(string Code, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return "UserNotFound";
            if (user.Code == Code) return "Success";
            return "Faild";
        }

        public async Task<string> ResetPasswordCode(string Email, string Password)
        {
            var trans= _dbContext.Database.BeginTransaction();
            try
            {
                var user = await _userManager.FindByEmailAsync(Email);
                if (user == null) return "UserNotFound";
                await _userManager.RemovePasswordAsync(user);
                await _userManager.AddPasswordAsync(user, Password);
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex) 
            {
                await trans.RollbackAsync();
                return "Faild";
            }
        }
    }
}
