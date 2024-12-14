using Shcool.Data.Entity.Procdueres;

namespace Shcool.Infrustructure.Abstruct.Procdueres
{
    public interface IDepartmentStudenCountProcRepository
    {
        public Task<IReadOnlyList<DepartmentStudenCountProc>> GetDepartmentStudenCountProcs(DepartmentStudenCountProcParameters parameter);
    }
}
