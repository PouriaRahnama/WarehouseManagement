using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Infrastructure.MapConfig
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Warehouses");
            builder.HasQueryFilter(x => !EF.Property<bool>(x, "IsDeleted"));

            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(75);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Location)
                .HasMaxLength(300);

            builder.HasIndex(x => x.Code)
                .IsUnique();

            builder.HasIndex(x => x.Name);

            // Relations
            builder.HasMany(x => x.StockBalances)
                .WithOne(x => x.Warehouse)
                .HasForeignKey(x => x.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.IncomingDocuments)
                .WithOne(x => x.ToWarehouse)
                .HasForeignKey(x => x.ToWarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.OutgoingDocuments)
                .WithOne(x => x.FromWarehouse)
                .HasForeignKey(x => x.FromWarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
