using Shcool.Core.Featuers.Department.Query.Model;
using Shcool.Core.Featuers.Department.Query.Result;
using Shcool.Data.Entity.Procdueres;

namespace Shcool.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentStudenCountByIdMapping()
        {
            CreateMap<GetDepartmentStudenCountByIdQuery, DepartmentStudenCountProcParameters>().
              ForMember(dst => dst.DiD, opt => opt.MapFrom(src => src.DiD));

            CreateMap<DepartmentStudenCountProc, GetDepartmentStudenCountByIdResult>().
            ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.DName)).
            ForMember(dst => dst.StudentCount, opt => opt.MapFrom(src => src.StudentCount));

        }

    }
}
