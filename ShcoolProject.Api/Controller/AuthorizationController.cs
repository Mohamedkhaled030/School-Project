using Microsoft.AspNetCore.Mvc;
using Shcool.Core.Featuers.Authorization.Command.Model;
using Shcool.Core.Featuers.Authorization.Query.Model;
using Shcool.Data.AppMetaData;
using ShcoolProject.Api.Base;

namespace ShcoolProject.Api.Controller
{

    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class AuthorizationController : AppControllerBase
    {
        [HttpPost(Router.AuthorizationRout.Create)]
        public async Task<IActionResult> CreateRole([FromBody] AddRoleCommand Command)
        {
            var Response = await _Mediator.Send(Command);
            return NewResult(Response);
        }
        [HttpPut(Router.AuthorizationRout.Edite)]
        public async Task<IActionResult> EditeRole([FromBody] EditeRoleCommand Command)
        {
            var Response = await _Mediator.Send(Command);
            return NewResult(Response);
        }
        [HttpDelete(Router.AuthorizationRout.Delete)]
        public async Task<IActionResult> DeleteRole([FromRoute] string id)
        {
            var Response = await _Mediator.Send(new DeleteRoleCommand() { Id = id });
            return NewResult(Response);
        }
        [HttpGet(Router.AuthorizationRout.GetListRoles)]
        public async Task<IActionResult> GetListRoles()
        {
            var Response = await _Mediator.Send(new GetRoleListQuery());
            return NewResult(Response);
        }

        [HttpGet(Router.AuthorizationRout.GetRolesById)]
        public async Task<IActionResult> GetRolesById([FromRoute] string userId)
        {
            var Response = await _Mediator.Send(new GetRoleByIdQuery { Id = userId });
            return NewResult(Response);
        }
        [HttpGet(Router.AuthorizationRout.MangeUserRoles)]
        public async Task<IActionResult> MangeUserRoles([FromRoute] string userId)
        {
            var Response = await _Mediator.Send(new MangeUserRoleQuery { userid = userId });
            return NewResult(Response);
        }
        [HttpPut(Router.AuthorizationRout.UpdateUserRole)]
        public async Task<IActionResult> UpdateUserRole([FromBody] UpdateUserRoleCommand command)
        {
            var Response = await _Mediator.Send(command);
            return NewResult(Response);

        }
        [HttpPut(Router.AuthorizationRout.UpdateUserClaim)]
        public async Task<IActionResult> UpdateUserClaim([FromBody] UpdateUserClaimsCommand command)
        {
            var Response = await _Mediator.Send(command);
            return NewResult(Response);

        }

        [HttpGet(Router.AuthorizationRout.MangeUserCliams)]
        public async Task<IActionResult> MangeUserCliams([FromRoute] string userId)
        {
            var Response = await _Mediator.Send(new MangeUserCliamsQuery() { userId = userId });
            return NewResult(Response);

        }


    }
}
