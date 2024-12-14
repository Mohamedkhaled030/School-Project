using Shcool.Core.Featuers.ApplicationUser.Command.Model;
using Shcool.Data.Entity.Identity;

namespace Shcool.Core.Mapping.ApplicationUser
{
    public partial class UserProfile
    {
        public void UpdateUserMapping()
        {
            CreateMap<UpdateUserComand, User>().ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
