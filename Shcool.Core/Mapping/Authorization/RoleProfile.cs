using AutoMapper;

namespace Shcool.Core.Mapping.Authorization
{
    public partial class RoleProfile : Profile
    {
        public RoleProfile()
        {
            GetListRoleMapping();
            GetRoleByIdMapping();
        }
    }
}
