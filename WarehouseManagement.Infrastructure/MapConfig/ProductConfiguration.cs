using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Infrastructure.MapConfig
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Products");
            // builder.HasQueryFilter(x => !EF.Property<bool>(x, "IsDeleted"));

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(350);

            builder.Property(x => x.Code)
                 .IsRequired()
                 .HasMaxLength(75);

            builder.HasIndex(x => x.Code)
                 .IsUnique();

            builder.HasIndex(x => x.Name);

            // Relations
            builder.HasMany(x => x.StockBalances)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);

            builder.HasMany(x => x.StockDocumentItems)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
