using MediatR;
using Shcool.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace Shcool.Core.Featuers.Authantcation.Query.Model
{
    public class ResetPasswordQuery : IRequest<Response<string>>
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
