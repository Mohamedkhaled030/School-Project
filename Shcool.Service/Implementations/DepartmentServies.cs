using Microsoft.EntityFrameworkCore;
using Shcool.Data.Entity;
using Shcool.Data.Entity.Procdueres;
using Shcool.Data.Entity.Views;
using Shcool.Infrustructure.Abstruct;
using Shcool.Infrustructure.Abstruct.Procdueres;
using Shcool.Infrustructure.Abstruct.Views;
using Shcool.Service.Abstruct;

namespace Shcool.Service.Implementations
{
    public class DepartmentServies : IDepartmentServices
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IViewDepartmentRepository<ViewDepartment> _viewDepartment;
        private readonly IDepartmentStudenCountProcRepository _departmentStudenCountProc;

        public DepartmentServies(IDepartmentRepository departmentRepository,
                                 IViewDepartmentRepository<ViewDepartment> viewDepartment,
                                 IDepartmentStudenCountProcRepository departmentStudenCountProc)
        {
            _departmentRepository = departmentRepository;
            _viewDepartment = viewDepartment;
            _departmentStudenCountProc = departmentStudenCountProc;
        }
        #region Function Handel
        public async Task<Department> GetDepartmentById(int id)
        {
            var student = await _departmentRepository.GetTableNoTracking().Where(x => x.DID.Equals(id))
                                                                                         .Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subjects)
                                                                                         .Include(x => x.Instructors)
                                                                                         .Include(x => x.Instructor).FirstOrDefaultAsync();
            return student;
        }


        public async Task<List<ViewDepartment>> GetviewDepartmentsDataAsync()
        {
            var countStudent = await _viewDepartment.GetTableNoTracking().ToListAsync();
            return countStudent;
        }
        public async Task<IReadOnlyList<DepartmentStudenCountProc>> GetDepartmentStudenCountProcs(DepartmentStudenCountProcParameters parameter)
        {
            return await _departmentStudenCountProc.GetDepartmentStudenCountProcs(parameter);
        }
        #endregion
    }
}
