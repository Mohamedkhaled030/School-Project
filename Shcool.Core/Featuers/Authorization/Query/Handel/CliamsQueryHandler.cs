using MediatR;
using Microsoft.AspNetCore.Identity;
using Shcool.Core.Bases;
using Shcool.Core.Featuers.Authorization.Query.Model;
using Shcool.Data.Entity.Identity;
using Shcool.Data.Results;
using Shcool.Service.Abstruct;

namespace Shcool.Core.Featuers.Authorization.Query.Handel
{
    public class CliamsQueryHandler : ResponseHandler, IRequestHandler<MangeUserCliamsQuery, Response<MangeUserCliamsResult>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthorizationServies _authorizationServies;

        public CliamsQueryHandler(IAuthorizationServies authorizationServies, UserManager<User> userManager)
        {
            _userManager = userManager;
            _authorizationServies = authorizationServies;
        }
        public async Task<Response<MangeUserCliamsResult>> Handle(MangeUserCliamsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.userId);
            if (user == null) return NotFound<MangeUserCliamsResult>("User Not Found");
            var result = await _authorizationServies.MangeUserCliamsDataAsync(user);
            return Success(result);

        }
    }
}
