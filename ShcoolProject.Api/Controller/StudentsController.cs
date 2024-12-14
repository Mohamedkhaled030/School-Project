using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shcool.Core.Featuers.Students.Commands.Models;
using Shcool.Core.Featuers.Students.Queries.Models;
using Shcool.Core.Filter;
using Shcool.Data.AppMetaData;
using ShcoolProject.Api.Base;

namespace ShcoolProject.Api.Controller
{

    [ApiController]
    [Authorize(Roles = "Admin")]
    public class StudentsController : AppControllerBase
    {

        [Authorize(Roles = "User")]
        [ServiceFilter(typeof(AuthFilter))]
        [HttpGet(Router.Student.List)]
        public async Task<IActionResult> GetStudenstList()
        {
            var Response = await _Mediator.Send(new GetStudentListQuery());
            return Ok(Response);
        }
        [AllowAnonymous]
        [HttpGet(Router.Student.Paginated)]
        public async Task<IActionResult> Pagenated([FromQuery] GetStudentPaginatedQuery paginatedQuery)
        {
            var Response = await _Mediator.Send(paginatedQuery);
            return Ok(Response);
        }
        [HttpGet(Router.Student.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var Response = await _Mediator.Send(new GetStudentByIdQuery() { id = id });
            return NewResult(Response);
        }
        [HttpPost(Router.Student.Create)]
        public async Task<IActionResult> Create([FromBody] AddStudenCommand addStudenCommand)
        {
            var Response = await _Mediator.Send(addStudenCommand);
            return NewResult(Response);
        }
        [HttpPut(Router.Student.Update)]
        public async Task<IActionResult> Update([FromBody] EditeStudenCommand UpdateStudenCommand)
        {
            var Response = await _Mediator.Send(UpdateStudenCommand);
            return NewResult(Response);
        }
        [AllowAnonymous]
        [HttpDelete(Router.Student.Delete)]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            var Response = await _Mediator.Send(new DeleteStudenCommand() { id = id });
            return NewResult(Response);
        }
    }
}
