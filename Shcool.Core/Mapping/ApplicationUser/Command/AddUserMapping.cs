using Shcool.Core.Featuers.ApplicationUser.Command.Model;
using Shcool.Data.Entity.Identity;

namespace Shcool.Core.Mapping.ApplicationUser
{
    public partial class UserProfile
    {
        public void AddUserMappind()
        {
            CreateMap<AddUserCommand, User>();
        }
    }
}
