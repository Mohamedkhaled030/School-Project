using MediatR;
using Shcool.Core.Bases;

namespace Shcool.Core.Featuers.ApplicationUser.Command.Model
{
    public class UpdateUserComand : IRequest<Response<string>>
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
    }
}
