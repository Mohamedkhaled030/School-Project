using MediatR;
using Shcool.Core.Bases;
using Shcool.Core.Featuers.Students.Queries.Results;

namespace Shcool.Core.Featuers.Students.Queries.Models
{
    public class GetStudentListQuery : IRequest<Response<List<GetStudentListResponse>>>
    {
    }
}
