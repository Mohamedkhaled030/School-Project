
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shcool.Data.Dtos;
using Shcool.Data.Entity.Identity;
using Shcool.Data.Helper;
using Shcool.Data.Requests;
using Shcool.Data.Results;
using Shcool.Infrustructure.Application_Data;
using Shcool.Service.Abstruct;
using System.Security.Claims;




namespace Shcool.Service.Implementations
{
    public class AuthorizationServies : IAuthorizationServies
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext dbContext;
        private readonly IdentityRole identityRole1;

        public AuthorizationServies(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, ApplicationDbContext dbContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            this.dbContext = dbContext;
        }

        public async Task<string> AddRoleAsync(string RoleName)
        {
            IdentityRole identityRole = new IdentityRole();

            identityRole.Name = RoleName;
            var result = await _roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
                return "Success";
            return "Faild";
        }

        public async Task<string> EditeRoleAsync(EditeRoleDto dto)
        {
            var role = await _roleManager.FindByIdAsync(dto.Id);
            if (role == null)
                return "NotFound";

            role.Name = dto.Name;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
                return "Success";
            var error = string.Join("-", result.Errors);
            return error;


        }

        public async Task<string> DeleteRoleAsync(string id)
        {
            //the role is exist or not
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return "Not Found";

            //check if user has this role or not
            var user = await _userManager.GetUsersInRoleAsync(role.Name);
            //return exption
            if (user != null && user.Count() > 0) return "Used";
            //delete error
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded) return "Success";
            var error = string.Join("-", result.Errors);
            return error;

        }

        public async Task<bool> IsRoleExiest(string RoleName)
        {
            //var check = await _roleManager.FindByNameAsync(RoleName);
            //if (check != null)
            //    return true;
            //return false;
            return await _roleManager.RoleExistsAsync(RoleName);
        }

        public async Task<List<IdentityRole>> GetRoleListAsync()
        {
            var result = await _roleManager.Roles.ToListAsync();
            return result;
        }

        public async Task<IdentityRole> GetRoleByIdAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return role;
        }

        public async Task<MangeUserRoleResult> MangeUserRoleDataAsync(User _User)
        {
            //get all User
            //Get role for User
            // var roleforUser = await _userManager.GetRolesAsync(_User);
            //get all roles
            var roles = await _roleManager.Roles.ToListAsync();
            var response = new MangeUserRoleResult();
            response.UserId = _User.Id;

            var roleList = new List<UserRoles>();
            foreach (var role in roles)
            {
                var userRole = new UserRoles();
                userRole.Id = role.Id;
                userRole.Name = role.Name;

                if (await _userManager.IsInRoleAsync(_User, role.Name))
                    userRole.HasRole = true;

                else userRole.HasRole = false;
                roleList.Add(userRole);
            }
            response.userRoles = roleList;
            return response;
        }

        public async Task<string> UpdateUserRole(UpdateUserRole Update)
        {
            var Transaction = dbContext.Database.BeginTransaction();
            try
            {
                var user = await _userManager.FindByIdAsync(Update.UserId);
                if (user == null) return "UserNotFound";
                var UserRole = await _userManager.GetRolesAsync(user);
                var RemoveRole = await _userManager.RemoveFromRolesAsync(user, UserRole);
                if (!RemoveRole.Succeeded) return "FaildRemoveRole";
                var RoleSelect = Update.userRoles.Where(x => x.HasRole == true).Select(x => x.Name);
                var result = await _userManager.AddToRolesAsync(user, RoleSelect);
                if (!result.Succeeded) return "FildToUpdateRole";
                await Transaction.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await Transaction.RollbackAsync();
                return "FaildUpdate";
            }

        }

        public async Task<MangeUserCliamsResult> MangeUserCliamsDataAsync(User user)
        {
            var response = new MangeUserCliamsResult();
            response.UserId = user.Id;
            var ListUserCliam = new List<UserCliams>();

            var userCliam = await _userManager.GetClaimsAsync(user);
            foreach (var claim in CliamStory.ClaimList)
            {
                var userRole = new UserCliams();
                userRole.Type = claim.Type;
                if (userCliam.Any(x => x.ValueType == claim.ValueType))
                    userRole.Value = true;
                else userRole.Value = false;

                ListUserCliam.Add(userRole);

            }
            response.userCliams = ListUserCliam;
            return response;

        }

        public async Task<string> UpdateUserClaims(UpdateUserClaims Update)
        {
            var trancet = dbContext.Database.BeginTransaction();
            try
            {
                var User = await _userManager.FindByIdAsync(Update.UserId);
                if (User == null) return "UserNotFound";
                var ClaimUser = await _userManager.GetClaimsAsync(User);
                var RemoveClaim = await _userManager.RemoveClaimsAsync(User, ClaimUser);
                if (!RemoveClaim.Succeeded) return "FaildRemoveClaims";
                var ClaimsSelect = Update.userCliams.Where(x => x.Value == true).Select(x => new Claim(x.Type, x.Value.ToString()));
                var result = await _userManager.AddClaimsAsync(User, ClaimsSelect);
                if (!result.Succeeded) return "FaildUpdateClaims";
                await trancet.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trancet.RollbackAsync();
                return "FaildUpdate";

            }




        }
    }
}
