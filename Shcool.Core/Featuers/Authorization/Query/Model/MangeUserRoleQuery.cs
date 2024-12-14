using MediatR;
using Shcool.Core.Bases;
using Shcool.Data.Results;

namespace Shcool.Core.Featuers.Authorization.Query.Model
{
    public class MangeUserRoleQuery : IRequest<Response<MangeUserRoleResult>>
    {
        public string userid { get; set; }
    }
}
