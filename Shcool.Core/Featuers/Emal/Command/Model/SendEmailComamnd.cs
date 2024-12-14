using MediatR;
using Shcool.Core.Bases;

namespace Shcool.Core.Featuers.Emal.Command.Model
{
    public class SendEmailComamnd : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string Massege { get; set; }
    }
}
