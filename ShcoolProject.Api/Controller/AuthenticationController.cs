using Microsoft.AspNetCore.Mvc;
using Shcool.Core.Featuers.Authantcation.Command.Model;
using Shcool.Core.Featuers.Authantcation.Query.Model;
using Shcool.Data.AppMetaData;
using ShcoolProject.Api.Base;

namespace ShcoolProject.Api.Controller
{

    [ApiController]
    public class AuthenticationController : AppControllerBase
    {
        [HttpPost(Router.Authentication.SignIn)]
        public async Task<IActionResult> Create([FromForm] SigninCommand command)
        {
            return NewResult(await _Mediator.Send(command));
        }
        [HttpPost(Router.Authentication.RefreshToken)]
        public async Task<IActionResult> RefreshToken([FromForm] AddRoleCommand command)
        {
            return NewResult(await _Mediator.Send(command));
        }
        [HttpGet(Router.Authentication.ValidateToken)]

        public async Task<IActionResult> ValidateToken([FromQuery] AutheiesUserQuery query)
        {
            return NewResult(await _Mediator.Send(query));
        }
        [HttpGet(Router.Authentication.ConfirmEmail)]

        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailQuery query)
        {
            return NewResult(await _Mediator.Send(query));
        }
        [HttpPost(Router.Authentication.SendReastPassword)]

        public async Task<IActionResult> SendReastPassword([FromQuery] SendResetPasswordCommand command)
        {
            return NewResult(await _Mediator.Send(command));
        }
        [HttpGet(Router.Authentication.ConfirmReastPassword)]

        public async Task<IActionResult> ConfirmReastPassword([FromQuery] ResetPasswordQuery query)
        {
            return NewResult(await _Mediator.Send(query));
        }

        [HttpPost(Router.Authentication.ReastPassword)]

        public async Task<IActionResult> ReastPassword([FromForm] ResetPasswordCommand command)
        {
            return NewResult(await _Mediator.Send(command));
        }
    }
}
