using MediatR;
using Shcool.Core.Bases;
using Shcool.Core.Featuers.Authorization.Query.Result;

namespace Shcool.Core.Featuers.Authorization.Query.Model
{
    public class GetRoleByIdQuery : IRequest<Response<GetRoleByIdResult>>
    {
        public string Id { get; set; }
    }
}
