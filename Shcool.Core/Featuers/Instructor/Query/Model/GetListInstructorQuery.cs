using MediatR;
using Shcool.Core.Bases;
using Shcool.Core.Featuers.Instructor.Query.Result;

namespace Shcool.Core.Featuers.Instructor.Query.Model
{
    public class GetListInstructorQuery : IRequest<Response<List<GetInstructorListResponse>>>
    {
    }
}
