using Shcool.Data.Entity.Identity;

namespace Shcool.Service.AuthSevices.interfaces
{
    public interface ICurrentUsersServices
    {
        public string GetUserId();
        public Task<User> GetUsersAsync();
        public Task<List<string>> GetCurrentUserRoleAsync();
    }
}
