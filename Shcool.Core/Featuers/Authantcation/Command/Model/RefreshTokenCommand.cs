using MediatR;
using Shcool.Core.Bases;
using Shcool.Data.Results;

namespace Shcool.Core.Featuers.Authantcation.Command.Model
{
    public class AddRoleCommand : IRequest<Response<JwtAuthResult>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
