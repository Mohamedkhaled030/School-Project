using Shcool.Core.Featuers.Instructor.Commands.Model;
using Shcool.Data.Entity;


namespace Shcool.Core.Mapping.InstractorMapping
{
    public partial class InstractorProfile
    {
        public void AddInstractorMapping()
        {
            CreateMap<AddInstructorCommand, Instructor>().

                ForMember(dst => dst.ENameEn, opt => opt.MapFrom(src => src.NameEn)).

                ForMember(dst => dst.Image, opt => opt.Ignore());

        }
    }
}
