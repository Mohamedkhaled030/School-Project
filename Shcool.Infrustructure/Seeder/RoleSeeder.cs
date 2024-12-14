using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Shcool.Infrustructure.Seeder
{
    public static class RoleSeeder
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> _RoleManager)
        {
            var Rolecount = await _RoleManager.Roles.CountAsync();
            if (Rolecount <= 0)
            {
                var defaultRole = new IdentityRole()
                {
                    Name = "Admin",

                }; var defaultRole2 = new IdentityRole()
                {
                    Name = "User",

                };
                await _RoleManager.CreateAsync(defaultRole);
                await _RoleManager.CreateAsync(defaultRole2);
            }
        }
    }
}
