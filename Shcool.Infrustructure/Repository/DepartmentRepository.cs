using Microsoft.EntityFrameworkCore;
using Shcool.Data.Entity;
using Shcool.Infrustructure.Abstruct;
using Shcool.Infrustructure.Application_Data;
using Shcool.Infrustructure.InfrustructurBase;

namespace Shcool.Infrustructure.Repository
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        private DbSet<Department> _department;

        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _department = dbContext.Set<Department>();
        }
    }
}
