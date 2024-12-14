using AutoMapper;

namespace Shcool.Core.Mapping.InstractorMapping
{
    public partial class InstractorProfile : Profile
    {
        public InstractorProfile()
        {

            GetListInstructorMapping();
            AddInstractorMapping();
        }
    }
}
