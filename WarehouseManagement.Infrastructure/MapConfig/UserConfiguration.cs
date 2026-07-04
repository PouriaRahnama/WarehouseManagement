using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Infrastructure.MapConfig
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Users");
            //builder.HasQueryFilter(x => !EF.Property<bool>(x, "IsDeleted"));
            builder.HasIndex(x => x.Username);

            // Relations


        }
    }
}
