using MediatR;
using Shcool.Core.Featuers.ApplicationUser.Query.Result;
using Shcool.Core.Warrapers;

namespace Shcool.Core.Featuers.ApplicationUser.Query.Model
{
    public class GetUserPaginationQuery : IRequest<PaginatedResult<GetUserListQueryResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
