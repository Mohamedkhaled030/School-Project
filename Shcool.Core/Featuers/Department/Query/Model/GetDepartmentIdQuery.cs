using MediatR;
using Shcool.Core.Bases;
using Shcool.Core.Featuers.Department.Query.Result;

namespace Shcool.Core.Featuers.Department.Query.Model
{
    public class GetDepartmentIdQuery : IRequest<Response<GetDepartmentIdResponse>>
    {
        public int id { get; set; }
        public int StudentPageSize { get; set; }
        public int StudentPageNumber { get; set; }
    }
}
