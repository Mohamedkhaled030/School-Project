using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shcool.Service.AuthSevices.interfaces;

namespace Shcool.Core.Filter
{
    public class AuthFilter : IAsyncActionFilter
    {
        private readonly ICurrentUsersServices _currentUsersServices;

        public AuthFilter(ICurrentUsersServices currentUsersServices)
        {
            _currentUsersServices = currentUsersServices;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated == true)
            {
                var Role = await _currentUsersServices.GetCurrentUserRoleAsync();
                if (Role.All(x => x != "User"))
                {
                    context.Result = new ObjectResult("forbidden")
                    {
                        StatusCode = StatusCodes.Status403Forbidden
                    };
                }
                else
                {
                    await next();
                }
            }
        }
    }
}
