using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Infrastructure.Persistence;
using WarehouseManagement.Infrastructure.Repository.InterfacesRepository;

namespace WarehouseManagement.Infrastructure.Repository.EntitiesRepository
{
    public class UserRefreshTokenRepository : Repository<UserRefreshToken>, IUserRefreshTokenRepository
    {
        public UserRefreshTokenRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
