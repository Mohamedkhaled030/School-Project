﻿
using Microsoft.AspNetCore.Identity;
using Shcool.Core.Featuers.Authorization.Query.Result;

namespace Shcool.Core.Mapping.Authorization
{
    public partial class RoleProfile
    {
        public void GetListRoleMapping()
        {
            CreateMap<IdentityRole, GetRoleByIdResult>().ForMember(
                dst => dst.id, opt => opt.MapFrom(src => src.Id)).ForMember(
                dst => dst.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
