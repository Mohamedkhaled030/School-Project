using Shcool.Core.Featuers.Students.Commands.Models;
using Shcool.Data.Entity;

namespace Shcool.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void AddStudentCamandMaping()
        {
            CreateMap<AddStudenCommand, Student>().
                ForMember(dst => dst.DID, opt => opt.MapFrom(src => src.DepartmenId));
        }
    }
}
