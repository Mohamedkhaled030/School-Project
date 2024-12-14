using MediatR;
using Shcool.Core.Featuers.Students.Queries.Results;
using Shcool.Core.Warrapers;
using Shcool.Data.Enum;

namespace Shcool.Core.Featuers.Students.Queries.Models
{
    public class GetStudentPaginatedQuery : IRequest<PaginatedResult<GetStudentPagnitedListResponse>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public StudentOrderEnum OrderBy { get; set; }
        public string? SearchBy { get; set; }
    }
}
