using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shcool.Data.Entity.Identity;
using Shcool.Infrustructure.Application_Data;
using Shcool.Service.Abstruct;

namespace Shcool.Service.Implementations
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<User> _UserManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailsService _emailsService;
        private readonly IUrlHelper _urlHelper;
        private readonly ApplicationDbContext _dbcontext;

        public ApplicationUserService(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, IEmailsService emailsService, IUrlHelper urlHelper, ApplicationDbContext context)
        {
            _UserManager = userManager;
            _emailsService = emailsService;
            _urlHelper = urlHelper;
            _dbcontext = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> AddUser(User user, string password)
        {
            var trans = _dbcontext.Database.BeginTransaction();
            try
            {
                var ExistUser = await _UserManager.FindByEmailAsync(user.Email);
                // Email is Exist
                if (ExistUser != null) return "TheEmailIsExist";
                //If User is Exist

                var UserName = await _UserManager.FindByNameAsync(user.UserName);
                if (UserName != null) return "TheNameIsExist";

                //Create
                var createResult = await _UserManager.CreateAsync(user, password);
                if (!createResult.Succeeded) return string.Join(",", createResult.Errors.Select(x => x.Description));

                var addRole = await _UserManager.AddToRoleAsync(user, "User");
                //sendConfirmEmail
                var code = await _UserManager.GenerateEmailConfirmationTokenAsync(user);
                var userAccessor = _httpContextAccessor.HttpContext.Request;
                var returnUrl = userAccessor.Scheme + "://" + userAccessor.Host + _urlHelper.Action("ConfirmEmail", "Authentication", new { userId = user.Id, code = code });
                var massege = $"To Confirm Email Click Link : <a href='{returnUrl}'></a>";
                /*$"/Api/V1/Authentication/ConfirmEmail?userId={user}&code={code}";*/

                //Massege or body
                await _emailsService.SendEmailAsync(user.Email, massege, "Confirm Email");

                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }
    }
}
