using Microsoft.EntityFrameworkCore;
using Shcool.Data.Entity;
using Shcool.Infrustructure.Abstruct;
using Shcool.Infrustructure.Application_Data;
using Shcool.Infrustructure.InfrustructurBase;

namespace Shcool.Infrustructure.Repository
{
    public class InstractourRepository : GenericRepositoryAsync<Instructor>, IInstractourRepository
    {
        private DbSet<Instructor> instructors;

        public InstractourRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            instructors = dbContext.Set<Instructor>();
        }
    }
}
