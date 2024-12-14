using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shcool.Data.Entity.Identity;

namespace Shcool.Infrustructure.Seeder
{
    public static class UserSeeder
    {
        public static async Task SeedAsync(UserManager<User> _userManager)
        {
            var userCount = await _userManager.Users.CountAsync();

            var defaultUser = new User()
            {
                UserName = "Khaled",
                Email = "k@gmail.com",
                FullName = "mohamed Khaled",
                Country = "Egypt",
                PhoneNumber = "0100",
                Address = "7st",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true
            };
            if (userCount <= 0)
            {
                await _userManager.CreateAsync(defaultUser, "123456_mM");
                await _userManager.AddToRoleAsync(defaultUser, "Admin");
                await _userManager.AddToRoleAsync(defaultUser, "User");
            }
        }
    }
}

