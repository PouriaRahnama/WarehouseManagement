namespace WarehouseManagement.Infrastructure.Repository.EntitiesRepository
{
    public class UserRefreshTokenRepository : Repository<UserRefreshToken>, IUserRefreshTokenRepository
    {
        public UserRefreshTokenRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
