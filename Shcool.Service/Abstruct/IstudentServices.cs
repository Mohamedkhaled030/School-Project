using Shcool.Data.Entity;
using Shcool.Data.Enum;

namespace Shcool.Service.Abstruct
{
    public interface IstudentServices
    {
        public Task<List<Student>> GetStudentsAsync();
        public Task<Student> GetStudentByIdWithIncloudAsync(int id);
        public Task<Student> GetStudentByIdAsync(int id);

        public IQueryable<Student> GetAllStudentsQueryable();
        public IQueryable<Student> GetAllStudentsbyDepartmentIdQueryable(int id);
        public Task<string> AddAsync(Student student);
        public void IsNameExist(string name);
        public Task<string> IsNameExiestEdite(int id, string name);
        public Task<string> UpdateStudentAsync(Student student);
        public Task<string> DleteStudentAsync(Student student);
        public IQueryable<Student> FilterStudentPaginatedQuerable(StudentOrderEnum studentOrder, string? Search);
    }
}
