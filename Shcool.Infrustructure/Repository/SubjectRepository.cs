using Microsoft.EntityFrameworkCore;
using Shcool.Data.Entity;
using Shcool.Infrustructure.Abstruct;
using Shcool.Infrustructure.Application_Data;
using Shcool.Infrustructure.InfrustructurBase;

namespace Shcool.Infrustructure.Repository
{
    public class SubjectRepository : GenericRepositoryAsync<Subjects>, ISubjectRepositry
    {
        private DbSet<Subjects> subjects;

        public SubjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            subjects = dbContext.Set<Subjects>();
        }
    }
}

