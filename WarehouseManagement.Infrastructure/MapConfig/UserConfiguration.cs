namespace WarehouseManagement.Infrastructure.MapConfig;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("Users");
        //builder.HasQueryFilter(x => !EF.Property<bool>(x, "IsDeleted"));

        builder.Property(x => x.Username)
          .IsRequired()
          .HasMaxLength(250);

        builder.Property(x => x.Phone)
            .IsRequired()
            .HasMaxLength(11);

        builder.Property(x => x.PasswordHash)
            .IsRequired();

        builder.Property(x => x.PasswordSalt)
            .IsRequired();

        builder.Property(x => x.Role)
          .IsRequired();

        builder.HasIndex(x => x.Username)
            .IsUnique();

        builder.HasIndex(x => x.Phone)
         .IsUnique();

        // Relations
        builder.HasMany(x => x.UserRefreshTokens)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);


    }
}



