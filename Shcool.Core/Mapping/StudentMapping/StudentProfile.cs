using AutoMapper;

namespace Shcool.Core.Mapping.StudentMapping
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentsListMapping();
            GetStudentByIdMapping();
            AddStudentCamandMaping();
            EditeStudentCommandMapping();
        }
    }
}
