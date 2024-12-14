using MediatR;
using Shcool.Core.Bases;

namespace Shcool.Core.Featuers.Students.Commands.Models
{
    public class DeleteStudenCommand : IRequest<Response<string>>
    {
        public int id { get; set; }
    }

}
