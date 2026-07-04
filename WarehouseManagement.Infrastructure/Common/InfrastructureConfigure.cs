using WarehouseManagement.Infrastructure.Repository.EntitiesRepository;
using WarehouseManagement.Infrastructure.Repository.InterfacesRepository;
using WarehouseManagement.Infrastructure.UnitOfWork;

namespace WarehouseManagement.Infrastructure.Common
{
    public static class InfrastructureConfigure
    {
        public static void InfrastructureConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {

            #region DI ( Registeration Services )
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRefreshTokenRepository, UserRefreshTokenRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            #endregion


        }
    }
}
