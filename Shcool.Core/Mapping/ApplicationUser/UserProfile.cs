using AutoMapper;

namespace Shcool.Core.Mapping.ApplicationUser
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            AddUserMappind();
            GetUserPaginatedMapping();
            GetUserByIdMapping();
            UpdateUserMapping();
        }
    }
}
