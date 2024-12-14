using Shcool.Data.Entity;
using Shcool.Infrustructure.InfrustructurBase;

namespace Shcool.Infrustructure.Abstruct
{
    public interface IStudentRepository : IGenericRepositoryAsync<Student>
    {
        public Task<List<Student>> GetStudentsListstAsync();
    }
}
