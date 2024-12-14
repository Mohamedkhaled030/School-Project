using MediatR;
using Shcool.Core.Bases;
using Shcool.Core.Featuers.Department.Query.Result;

namespace Shcool.Core.Featuers.Department.Query.Model
{
    public class GetDepartmentListStudentCountQuery : IRequest<Response<List<GetDepartmentListStudentCountResult>>>
    {
    }
}
