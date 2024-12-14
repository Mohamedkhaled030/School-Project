using MediatR;
using Shcool.Core.Bases;
using Shcool.Data.Requests;

namespace Shcool.Core.Featuers.Authorization.Command.Model
{
    public class UpdateUserClaimsCommand : UpdateUserClaims, IRequest<Response<string>>
    {
    }
}
