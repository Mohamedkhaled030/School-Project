using MediatR;
using Shcool.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace Shcool.Core.Featuers.Authantcation.Command.Model
{
    public class SendResetPasswordCommand : IRequest<Response<string>>
    {
        [Required]
        public string Email { get; set; }
    }
}
