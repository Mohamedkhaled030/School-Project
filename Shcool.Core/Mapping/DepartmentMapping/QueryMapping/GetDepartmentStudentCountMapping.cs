using Shcool.Core.Featuers.Department.Query.Result;
using Shcool.Data.Entity.Views;

namespace Shcool.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentStudentCountMapping()
        {
            CreateMap<ViewDepartment, GetDepartmentListStudentCountResult>().
                 ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.DName)).
             ForMember(dst => dst.StudentCount, opt => opt.MapFrom(src => src.StudentCount));
        }
    }
}
