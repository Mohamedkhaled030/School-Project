using MediatR;
using Shcool.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace Shcool.Core.Featuers.Authorization.Command.Model
{
    public class AddRoleCommand : IRequest<Response<string>>
    {
        [Required]
        public string RoleName { get; set; }
    }
}
