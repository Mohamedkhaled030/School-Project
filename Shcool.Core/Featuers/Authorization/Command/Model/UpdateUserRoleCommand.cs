using MediatR;
using Shcool.Core.Bases;
using Shcool.Data.Dtos;

namespace Shcool.Core.Featuers.Authorization.Command.Model
{
    public class UpdateUserRoleCommand : UpdateUserRole, IRequest<Response<string>>
    {
    }
}
