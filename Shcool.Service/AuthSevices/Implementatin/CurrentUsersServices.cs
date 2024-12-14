using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shcool.Data.Entity.Identity;
using Shcool.Data.Helper;
using Shcool.Service.AuthSevices.interfaces;

namespace Shcool.Service.AuthSevices.Implementatin
{

    public class CurrentUsersServices : ICurrentUsersServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public CurrentUsersServices(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        public string GetUserId()
        {
            var userid = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == nameof(UserClaimModel.id)).Value;
            if (userid == null) throw new UnauthorizedAccessException();
            return userid;
        }
        public async Task<User> GetUsersAsync()
        {
            var userId = GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw new UnauthorizedAccessException();
            return user;
        }



        public async Task<List<string>> GetCurrentUserRoleAsync()
        {
            var user = await GetUsersAsync();
            var role = await _userManager.GetRolesAsync(user);
            return role.ToList();
        }
    }
}
