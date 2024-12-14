using MediatR;
using Shcool.Core.Bases;
using Shcool.Core.Featuers.ApplicationUser.Query.Result;

namespace Shcool.Core.Featuers.ApplicationUser.Query.Model
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {
        public string Id { get; set; }
    }
}
