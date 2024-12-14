using Microsoft.AspNetCore.Mvc;
using Shcool.Core.Featuers.Department.Query.Model;
using Shcool.Data.AppMetaData;
using ShcoolProject.Api.Base;

namespace ShcoolProject.Api.Controller
{

    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.Department.GetById)]
        public async Task<IActionResult> GetDepartmentById([FromQuery] GetDepartmentIdQuery query)
        {
            var Response = await _Mediator.Send(query);
            return NewResult(Response);
        }
        [HttpGet(Router.Department.GetViewDepartmentStudentCount)]
        public async Task<IActionResult> GetViewDepartmentStudentCount()
        {
            var Response = await _Mediator.Send(new GetDepartmentListStudentCountQuery());
            return NewResult(Response);
        }
        [HttpGet(Router.Department.GetProcDepartmentStudentById)]
        public async Task<IActionResult> GetProcDepartmentStudentById([FromRoute] string id)
        {
            var Response = await _Mediator.Send(new GetDepartmentStudenCountByIdQuery() { DiD = id });
            return NewResult(Response);
        }

    }
}
