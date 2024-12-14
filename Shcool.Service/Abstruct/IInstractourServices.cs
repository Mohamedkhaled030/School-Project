using Microsoft.AspNetCore.Http;
using Shcool.Data.Entity;

namespace Shcool.Service.Abstruct
{
    public interface IInstractourServices
    {
        public Task<List<Instructor>> GetAllInstructorsAsync();

        public Task<Instructor> GetInstructorByIdAsync(int id);


        public Task<decimal> GetSalarySummationOfInstructor();
        public Task<string> AddInstructorAsync(Instructor Instructor, IFormFile file);

        public Task<string> UpdateInstructorAsync(Instructor Instructor);
        public Task<string> DleteInstructorAsync(Instructor Instructor);

    }
}
