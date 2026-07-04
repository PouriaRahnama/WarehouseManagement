using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Infrastructure.MapConfig
{
    public class StockDocumentItemConfiguration : IEntityTypeConfiguration<StockDocumentItem>
    {
        public void Configure(EntityTypeBuilder<StockDocumentItem> builder)
        {
            builder.HasKey(x => new { x.StockDocumentId, x.ProductId });
            builder.ToTable("StockDocumentItems");
            builder.HasQueryFilter(x => !EF.Property<bool>(x, "IsDeleted"));

            builder.Property(x => x.Quantity)
                 .IsRequired();

            // Relations
            builder.HasOne(x => x.StockDocument)
                .WithMany(x => x.StockDocumentItems)
                .HasForeignKey(x => x.StockDocumentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.StockDocumentItems)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
