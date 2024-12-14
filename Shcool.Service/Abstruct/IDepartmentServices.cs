using Shcool.Data.Entity;
using Shcool.Data.Entity.Procdueres;
using Shcool.Data.Entity.Views;

namespace Shcool.Service.Abstruct
{
    public interface IDepartmentServices
    {
        public Task<Department> GetDepartmentById(int id);
        public Task<List<ViewDepartment>> GetviewDepartmentsDataAsync();
        public Task<IReadOnlyList<DepartmentStudenCountProc>> GetDepartmentStudenCountProcs(DepartmentStudenCountProcParameters parameter);
    }
}
