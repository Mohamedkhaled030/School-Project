using MediatR;
using Shcool.Core.Bases;

namespace Shcool.Core.Featuers.ApplicationUser.Command.Model
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
    }
}
