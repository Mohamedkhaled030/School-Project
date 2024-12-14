using Shcool.Data.Entity.Identity;

namespace Shcool.Service.Abstruct
{
    public interface IApplicationUserService
    {
        public Task<string> AddUser(User user, string password);
    }
}
