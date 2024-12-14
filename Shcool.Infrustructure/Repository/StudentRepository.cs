using Microsoft.EntityFrameworkCore;
using Shcool.Data.Entity;
using Shcool.Infrustructure.Abstruct;
using Shcool.Infrustructure.Application_Data;
using Shcool.Infrustructure.InfrustructurBase;

namespace Shcool.Infrustructure.Repository
{
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
    {
        private readonly DbSet<Student> _StudentRepository;

        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _StudentRepository = dbContext.Set<Student>();
        }
        public async Task<List<Student>> GetStudentsListstAsync()
        {
            return await _StudentRepository.Include(x => x.Department).ToListAsync();
        }
    }
}
