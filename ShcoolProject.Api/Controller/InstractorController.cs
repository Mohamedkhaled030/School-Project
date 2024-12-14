using Microsoft.AspNetCore.Mvc;
using Shcool.Core.Featuers.Instructor.Commands.Model;
using Shcool.Core.Featuers.Instructor.Query.Model;
using Shcool.Data.AppMetaData;
using ShcoolProject.Api.Base;

namespace ShcoolProject.Api.Controller
{

    public class InstractorController : AppControllerBase
    {
        [HttpGet(Router.InstructorRouter.GetInstructorList)]
        public async Task<IActionResult> GetInstructorList()
        {
            var Response = await _Mediator.Send(new GetListInstructorQuery());
            return Ok(Response);
        }
        [HttpPost(Router.InstructorRouter.AddInstructor)]
        public async Task<IActionResult> AddInstructor([FromForm] AddInstructorCommand command)
        {
            var Response = await _Mediator.Send(command);
            return Ok(Response);
        }
        [HttpPost(Router.InstructorRouter.GetSalarySummitionInstractour)]
        public async Task<IActionResult> GetSalarySummitionInstractour()
        {
            var Response = await _Mediator.Send(new GetSalarySummationQuery());
            return Ok(Response);
        }
    }
}
