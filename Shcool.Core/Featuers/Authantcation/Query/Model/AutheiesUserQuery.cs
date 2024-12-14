using MediatR;
using Shcool.Core.Bases;

namespace Shcool.Core.Featuers.Authantcation.Query.Model
{
    public class AutheiesUserQuery : IRequest<Response<string>>
    {
        public string AccessToken { get; set; }
    }
}
