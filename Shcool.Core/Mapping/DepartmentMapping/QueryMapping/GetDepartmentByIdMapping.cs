using Shcool.Core.Featuers.Department.Query.Result;
using Shcool.Data.Entity;

namespace Shcool.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentByIdMapping()
        {
            CreateMap<Department, GetDepartmentIdResponse>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(x => x.DID))
                .ForMember(dst => dst.MangerName, opt => opt.MapFrom(x => x.Instructor.ENameEn))
                .ForMember(dst => dst.SubjectsList, opt => opt.MapFrom(x => x.DepartmentSubjects))
                .ForMember(dst => dst.InstractoursList, opt => opt.MapFrom(x => x.Instructors));
            //.ForMember(dst => dst.StudentsList, opt => opt.MapFrom(x => x.Students));

            //CreateMap<DepartmetSubject, SubjectResponse>()
            //    .ForMember(dst => dst.Id, opt => opt.MapFrom(x => x.SubID))
            //    .ForMember(dst => dst.Name, opt => opt.MapFrom(x => x.Subjects.SubjectName));

            CreateMap<Instructor, InstractourResponse>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(x => x.ENameEn));


        }
    }
}
