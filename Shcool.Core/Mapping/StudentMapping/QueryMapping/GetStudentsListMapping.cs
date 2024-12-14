using Shcool.Core.Featuers.Students.Queries.Results;
using Shcool.Data.Entity;

namespace Shcool.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void GetStudentsListMapping()
        {
            CreateMap<Student, GetStudentListResponse>().
               ForMember(dst => dst.DepartmentName, opt => opt.MapFrom(src => src.Department.DName));
        }
    }
}
