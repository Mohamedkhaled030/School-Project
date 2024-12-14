using MediatR;
using Shcool.Core.Bases;

namespace Shcool.Core.Featuers.ApplicationUser.Command.Model
{
    public class ChangePasswordCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
        public string CurruntPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
