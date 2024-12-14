using MediatR;
using Shcool.Core.Bases;

namespace Shcool.Core.Featuers.Students.Commands.Models
{
    public class AddStudenCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string? DepartmenId { get; set; }
    }
}
