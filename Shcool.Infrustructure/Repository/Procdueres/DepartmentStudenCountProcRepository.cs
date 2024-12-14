using Shcool.Data.Entity.Procdueres;
using Shcool.Infrustructure.Abstruct.Procdueres;
using Shcool.Infrustructure.Application_Data;
using StoredProcedureEFCore;

namespace Shcool.Infrustructure.Repository.Procdueres
{
    public class DepartmentStudenCountProcRepository : IDepartmentStudenCountProcRepository
    {
        private readonly ApplicationDbContext dbContext;

        public DepartmentStudenCountProcRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IReadOnlyList<DepartmentStudenCountProc>> GetDepartmentStudenCountProcs(DepartmentStudenCountProcParameters parameter)
        {
            var rows = new List<DepartmentStudenCountProc>();
            await dbContext.LoadStoredProc(nameof(DepartmentStudenCountProc))
                  .AddParam(nameof(DepartmentStudenCountProcParameters.DiD), parameter.DiD)
                  .ExecAsync(async r => rows = await r.ToListAsync<DepartmentStudenCountProc>());
            return rows;
        }
    }
}
