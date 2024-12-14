using MediatR;
using Shcool.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace Shcool.Core.Featuers.Authantcation.Query.Model
{
    public class ConfirmEmailQuery : IRequest<Response<string>>
    {
        [Required]
        public string userId { get; set; }
        [Required(ErrorMessage = "no empty")]
        public string code { get; set; }
    }
}
