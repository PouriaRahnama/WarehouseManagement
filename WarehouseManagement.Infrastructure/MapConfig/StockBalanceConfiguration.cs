using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Infrastructure.MapConfig
{
    public class StockBalanceConfiguration : IEntityTypeConfiguration<StockBalance>
    {
        public void Configure(EntityTypeBuilder<StockBalance> builder)
        {
            builder.HasKey(x => new { x.WarehouseId, x.ProductId });
            builder.ToTable("StockBalances");
            //builder.HasQueryFilter(x => !EF.Property<bool>(x, "IsDeleted"));

            builder.Property(x => x.Quantity)
                 .IsRequired();

            // Relations
            builder.HasOne(x => x.Product)
                .WithMany(x => x.StockBalances)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Warehouse)
                .WithMany(x => x.StockBalances)
                .HasForeignKey(x => x.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
