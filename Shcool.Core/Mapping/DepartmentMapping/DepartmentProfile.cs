using AutoMapper;

namespace Shcool.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            GetDepartmentByIdMapping();
            GetDepartmentStudentCountMapping();
            GetDepartmentStudenCountByIdMapping();
        }
    }
}
