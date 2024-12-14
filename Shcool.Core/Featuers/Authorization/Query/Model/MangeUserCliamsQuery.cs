using MediatR;
using Shcool.Core.Bases;
using Shcool.Data.Results;

namespace Shcool.Core.Featuers.Authorization.Query.Model
{
    public class MangeUserCliamsQuery : IRequest<Response<MangeUserCliamsResult>>
    {
        public string userId { get; set; }
    }
}
