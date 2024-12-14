using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shcool.Core.Bases;
using Shcool.Core.Featuers.Authorization.Command.Model;
using Shcool.Core.Featuers.Authorization.Query.Model;
using Shcool.Core.Featuers.Authorization.Query.Result;
using Shcool.Data.Entity.Identity;
using Shcool.Data.Results;
using Shcool.Service.Abstruct;

namespace Shcool.Core.Featuers.Authorization.Command.Handler
{
    public class RoleQueryHandler : ResponseHandler, IRequestHandler<GetRoleListQuery, Response<List<GetRoleListReult>>>,
                                                     IRequestHandler<GetRoleByIdQuery, Response<GetRoleByIdResult>>,
                                                     IRequestHandler<MangeUserRoleQuery, Response<MangeUserRoleResult>>,
                                                     IRequestHandler<UpdateUserRoleCommand, Response<string>>
    {
        private readonly IAuthorizationServies _authorizationServies;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public RoleQueryHandler(IAuthorizationServies authorizationServies, IMapper mapper, UserManager<User> userManager)
        {
            _authorizationServies = authorizationServies;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<Response<List<GetRoleListReult>>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _authorizationServies.GetRoleListAsync();

            var result = _mapper.Map<List<GetRoleListReult>>(roles);
            return Success(result);

        }

        public async Task<Response<GetRoleByIdResult>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _authorizationServies.GetRoleByIdAsync(request.Id);
            if (role == null) return NotFound<GetRoleByIdResult>("Role Not Found");
            var result = _mapper.Map<GetRoleByIdResult>(role);
            return Success(result);
        }

        public async Task<Response<MangeUserRoleResult>> Handle(MangeUserRoleQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.userid);
            if (user == null) return NotFound<MangeUserRoleResult>("User Not Found");
            var result = await _authorizationServies.MangeUserRoleDataAsync(user);
            return Success(result);
        }

        public async Task<Response<string>> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var resilt = await _authorizationServies.UpdateUserRole(request);
            switch (resilt)
            {
                case "UserNotFound": return NotFound<string>("User Not Found");
                case "FaildRemoveRole": return BadRequest<string>("Faild Remove Role");
                case "FildToUpdateRole": return NotFound<string>("Faild To Update Role");
                case "FaildUpdate": return BadRequest<string>("Faild Update");
            }
            return Success("Update success");
        }
    }
}
