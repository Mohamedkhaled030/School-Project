using Shcool.Core.Featuers.Instructor.Query.Result;
using Shcool.Data.Entity;

namespace Shcool.Core.Mapping.InstractorMapping
{
    public partial class InstractorProfile
    {
        public void GetListInstructorMapping()
        {
            CreateMap<Instructor, GetInstructorListResponse>().
                 ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id)).
                 ForMember(dst => dst.ENameEn, opt => opt.MapFrom(src => src.ENameEn)).
                 ForMember(dst => dst.Address, opt => opt.MapFrom(src => src.Address)).
                 ForMember(dst => dst.Position, opt => opt.MapFrom(src => src.Position)).
                 ForMember(dst => dst.Salary, opt => opt.MapFrom(src => src.Salary));


        }
    }
}
