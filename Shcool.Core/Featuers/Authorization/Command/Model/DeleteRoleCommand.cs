using MediatR;
using Shcool.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace Shcool.Core.Featuers.Authorization.Command.Model
{
    public class DeleteRoleCommand : IRequest<Response<string>>
    {
        [Required]
        public string Id { get; set; }
    }
}
