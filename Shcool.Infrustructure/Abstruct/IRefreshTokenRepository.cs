using Shcool.Data.Entity.Identity;
using Shcool.Infrustructure.InfrustructurBase;

namespace Shcool.Infrustructure.Abstruct
{
    public interface IRefreshTokenRepository : IGenericRepositoryAsync<UserRefreshToken>
    {
    }
}
