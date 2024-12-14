using Microsoft.AspNetCore.Mvc;
using Shcool.Core.Featuers.Emal.Command.Model;
using Shcool.Data.AppMetaData;
using ShcoolProject.Api.Base;

namespace ShcoolProject.Api.Controller
{

    [ApiController]
    public class EmailsController : AppControllerBase
    {
        [HttpPost(Router.Email.SendEmails)]
        public async Task<IActionResult> SendEmails([FromQuery] SendEmailComamnd comamnd)
        {
            var result = await _Mediator.Send(comamnd);
            return NewResult(result);
        }
    }
}
