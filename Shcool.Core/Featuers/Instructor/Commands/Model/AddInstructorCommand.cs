using MediatR;
using Microsoft.AspNetCore.Http;
using Shcool.Core.Bases;

namespace Shcool.Core.Featuers.Instructor.Commands.Model
{
    public class AddInstructorCommand : IRequest<Response<string>>
    {


        public string? NameEn { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int? SupervisorId { get; set; }
        public decimal? Salary { get; set; }
        public IFormFile? Image { get; set; }

        public int DID { get; set; }
    }
}
