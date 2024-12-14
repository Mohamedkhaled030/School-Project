using Microsoft.AspNetCore.Mvc;
using Shcool.Core.Featuers.ApplicationUser.Command.Model;
using Shcool.Core.Featuers.ApplicationUser.Query.Model;
using Shcool.Data.AppMetaData;
using ShcoolProject.Api.Base;

namespace ShcoolProject.Api.Controller
{

    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {
        [HttpPost(Router.ApplicationUserRouter.Create)]
        public async Task<IActionResult> Create([FromBody] AddUserCommand Command)
        {
            var Response = await _Mediator.Send(Command);
            return NewResult(Response);
        }
        [HttpGet(Router.ApplicationUserRouter.Paginated)]
        public async Task<IActionResult> GetList([FromQuery] GetUserPaginationQuery Command)
        {
            var Response = await _Mediator.Send(Command);
            return Ok(Response);
        }
        //(Router.ApplicationUserRouter.GetById)
        [HttpGet(Router.ApplicationUserRouter.GetById)]
        public async Task<IActionResult> GetDepartmentById([FromRoute] string id)
        {
            var Response = await _Mediator.Send(new GetUserByIdQuery() { Id = id });
            return NewResult(Response);
        }
        [HttpPut(Router.ApplicationUserRouter.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateUserComand Command)
        {
            var Response = await _Mediator.Send(Command);
            return NewResult(Response);
        }
        [HttpDelete(Router.ApplicationUserRouter.Delete)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var Response = await _Mediator.Send(new DeleteUserCommand() { Id = id });
            return NewResult(Response);
        }
        [HttpPut(Router.ApplicationUserRouter.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand Command)
        {
            var Response = await _Mediator.Send(Command);
            return NewResult(Response);
        }
    }
}
