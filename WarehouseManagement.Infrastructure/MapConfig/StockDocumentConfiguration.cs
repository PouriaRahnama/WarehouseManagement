namespace WarehouseManagement.Infrastructure.MapConfig;

public class StockDocumentConfiguration : IEntityTypeConfiguration<StockDocument>
{
    public void Configure(EntityTypeBuilder<StockDocument> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("StockDocuments");
       // builder.HasQueryFilter(x => !EF.Property<bool>(x, "IsDeleted"));

        builder.HasIndex(x => x.Number)
            .IsUnique();

        builder.Property(x => x.Status)
            .IsRequired();

        builder.Property(x => x.Type)
            .IsRequired();

        // Relations

        builder.HasOne(x => x.FromWarehouse)
            .WithMany(x => x.OutgoingDocuments)
            .HasForeignKey(x => x.FromWarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ToWarehouse)
            .WithMany(x => x.IncomingDocuments)
            .HasForeignKey(x => x.ToWarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.StockDocumentItems)
            .WithOne(x => x.StockDocument)
            .HasForeignKey(x => x.StockDocumentId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}

