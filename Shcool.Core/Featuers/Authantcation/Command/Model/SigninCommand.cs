using MediatR;
using Shcool.Core.Bases;
using Shcool.Data.Results;

namespace Shcool.Core.Featuers.Authantcation.Command.Model
{
    public class SigninCommand : IRequest<Response<JwtAuthResult>>
    {

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
