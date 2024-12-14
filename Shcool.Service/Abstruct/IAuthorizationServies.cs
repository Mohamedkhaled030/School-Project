

using Microsoft.AspNetCore.Identity;
using Shcool.Data.Dtos;
using Shcool.Data.Entity.Identity;
using Shcool.Data.Requests;
using Shcool.Data.Results;

namespace Shcool.Service.Abstruct
{
    public interface IAuthorizationServies
    {
        public Task<string> AddRoleAsync(string RoleName);
        public Task<bool> IsRoleExiest(string RoleName);
        public Task<string> EditeRoleAsync(EditeRoleDto dto);
        public Task<string> DeleteRoleAsync(string id);
        public Task<List<IdentityRole>> GetRoleListAsync();
        public Task<IdentityRole> GetRoleByIdAsync(string id);
        public Task<MangeUserRoleResult> MangeUserRoleDataAsync(User user);
        public Task<MangeUserCliamsResult> MangeUserCliamsDataAsync(User user);
        public Task<string> UpdateUserRole(UpdateUserRole Update);
        public Task<string> UpdateUserClaims(UpdateUserClaims Update);
    }
}
