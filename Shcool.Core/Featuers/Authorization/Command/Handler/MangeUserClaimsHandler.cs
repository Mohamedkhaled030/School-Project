using MediatR;
using Shcool.Core.Bases;
using Shcool.Core.Featuers.Authorization.Command.Model;
using Shcool.Service.Abstruct;

namespace Shcool.Core.Featuers.Authorization.Command.Handler
{
    public class MangeUserClaimsHandler : ResponseHandler, IRequestHandler<UpdateUserClaimsCommand, Response<string>>
    {
        private readonly IAuthorizationServies _authorizationServies;

        public MangeUserClaimsHandler(IAuthorizationServies authorizationServies)
        {
            _authorizationServies = authorizationServies;
        }

        public async Task<Response<string>> Handle(UpdateUserClaimsCommand request, CancellationToken cancellationToken)
        {
            var resilt = await _authorizationServies.UpdateUserClaims(request);
            switch (resilt)
            {
                case "UserNotFound": return NotFound<string>("User Not Found");
                case "FaildRemoveClaims": return BadRequest<string>("Faild Remove Claims");
                case "FaildUpdateClaims": return NotFound<string>("Faild To Update Claims");
                case "FaildUpdate": return BadRequest<string>("Faild Update");
            }
            return Success("Update success");
        }
    }
}
