using Microsoft.EntityFrameworkCore;
using Shcool.Data.Entity.Identity;
using Shcool.Infrustructure.Abstruct;
using Shcool.Infrustructure.Application_Data;
using Shcool.Infrustructure.InfrustructurBase;

namespace Shcool.Infrustructure.Repository
{
    public class RefreshTokenRepository : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepository
    {
        private DbSet<UserRefreshToken> _userRefreshTokens;

        public RefreshTokenRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _userRefreshTokens = dbContext.Set<UserRefreshToken>();
        }
    }
}
