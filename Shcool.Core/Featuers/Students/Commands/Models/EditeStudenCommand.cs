using MediatR;
using Shcool.Core.Bases;

namespace Shcool.Core.Featuers.Students.Commands.Models
{
    public class EditeStudenCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? DepartmenId { get; set; }
    }
}
