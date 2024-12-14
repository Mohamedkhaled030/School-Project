using Shcool.Core.Featuers.ApplicationUser.Query.Result;
using Shcool.Data.Entity.Identity;

namespace Shcool.Core.Mapping.ApplicationUser
{
    public partial class UserProfile
    {
        public void GetUserPaginatedMapping()
        {
            CreateMap<User, GetUserListQueryResponse>();
        }
    }
}
