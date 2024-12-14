using MediatR;
using Shcool.Core.Bases;
using Shcool.Core.Featuers.Authorization.Command.Model;
using Shcool.Service.Abstruct;

namespace Shcool.Core.Featuers.Authorization.Command.Handler
{
    public class RoleCommandHandler : ResponseHandler, IRequestHandler<AddRoleCommand, Response<string>>,
                                                       IRequestHandler<EditeRoleCommand, Response<string>>,
                                                       IRequestHandler<DeleteRoleCommand, Response<string>>
    {

        private readonly IAuthorizationServies _authorizationServies;

        public RoleCommandHandler(IAuthorizationServies authorizationServies)
        {
            _authorizationServies = authorizationServies;
        }
        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var Result = await _authorizationServies.AddRoleAsync(request.RoleName);
            if (Result == "Success")
                return Success<string>("Name Role Add Successfuly");
            return BadRequest<string>("Name Is Exist");

        }

        public async Task<Response<string>> Handle(EditeRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationServies.EditeRoleAsync(request);
            if (result == "NotFound") return NotFound<string>("The Role not Found");
            else if (result == "Success") return Success<string>("Role Add Successfully");
            return BadRequest<string>(result);


        }

        public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationServies.DeleteRoleAsync(request.Id);
            if (result == "Not Found") return NotFound<string>("The Role Not Found");
            if (result == "Used") return BadRequest<string>("Role Name Is Used");
            if (result == "Success") return Success<string>("Delete Role successed");
            return BadRequest<string>(result);
        }
    }
}
