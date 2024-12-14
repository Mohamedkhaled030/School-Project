using MediatR;
using Shcool.Core.Bases;
using Shcool.Core.Featuers.Students.Queries.Results;

namespace Shcool.Core.Featuers.Students.Queries.Models
{
    public class GetStudentByIdQuery : IRequest<Response<GetSingleStudentResponse>>
    {
        public int id { get; set; }
    }
}
