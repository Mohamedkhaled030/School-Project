using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shcool.Core.Bases;
using Shcool.Core.Featuers.ApplicationUser.Query.Model;
using Shcool.Core.Featuers.ApplicationUser.Query.Result;
using Shcool.Core.Warrapers;
using Shcool.Data.Entity.Identity;

namespace Shcool.Core.Featuers.ApplicationUser.Query.Handel
{
    public class UserQueryHandler : ResponseHandler, IRequestHandler<GetUserPaginationQuery, PaginatedResult<GetUserListQueryResponse>>
                                                   , IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>
    {
        private readonly IMapper _Mapper;
        private readonly UserManager<User> _UserManager;


        public UserQueryHandler(IMapper mapper, UserManager<User> userManager)
        {
            _Mapper = mapper;
            _UserManager = userManager;
        }

        public async Task<PaginatedResult<GetUserListQueryResponse>> Handle(GetUserPaginationQuery request, CancellationToken cancellationToken)
        {
            var users = _UserManager.Users.AsQueryable();
            var paginatedList = await _Mapper.ProjectTo<GetUserListQueryResponse>(users)
                                                      .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }

        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var users = await _UserManager.FindByIdAsync(request.Id);
            if (users == null) return NotFound<GetUserByIdResponse>("The Objct Not Found");
            var result = _Mapper.Map<GetUserByIdResponse>(users);
            return Success(result);

        }
    }
}
