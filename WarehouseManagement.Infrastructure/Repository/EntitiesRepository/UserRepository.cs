namespace WarehouseManagement.Infrastructure.Repository.EntitiesRepository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
