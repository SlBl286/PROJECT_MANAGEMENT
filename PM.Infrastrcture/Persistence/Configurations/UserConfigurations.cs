using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.Domain.UserAggregate;
using PM.Domain.UserAggregate.Entities;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Infrastrcture.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUserTable(builder);
        ConfigureNotificationTable(builder);

    }
     private void ConfigureNotificationTable(EntityTypeBuilder<User> builder)
    {
        builder.OwnsMany(i => i.Notifications, sb =>
        {
            sb.ToTable("Notifications");
            sb.WithOwner().HasForeignKey("UserId");

            sb.HasKey(nameof(Notification.Id), "UserId");

            sb.Property(b => b.Id)
                .HasColumnName("NotificationId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => NotificationId.Create(value)
            );
            sb.Property(b => b.Message);
            sb.Property(b => b.IsRead);

        });

        builder.Metadata.FindNavigation(nameof(User.Notifications))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
    private void ConfigureUserTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value)
            );
        builder.Property(m => m.Name)
            .HasMaxLength(100);
        builder.Property(m => m.Avatar)
            .HasMaxLength(100);
        builder.Property(m => m.Username)
            .HasMaxLength(100);
        builder.Property(m => m.Email)
            .HasMaxLength(100);
        builder.Property(m => m.PhoneNumber)
            .HasMaxLength(100);
        builder.Property(m => m.Salt)
            .HasMaxLength(255);
        builder.Property(m => m.HashedPassword)
            .HasMaxLength(255);
        builder.Property(m => m.Role)
            .HasConversion<int>();
        builder.OwnsOne(u => u.RefreshToken);
        builder
       .HasIndex(u => u.Username)
       .IsUnique();

        builder.HasGeneratedTsVectorColumn(u => u.SearchVector, "vietnamese",
       u => new { u.Username, u.Name, u.PhoneNumber }
      ).HasIndex(ic => ic.SearchVector)
      .HasMethod("GIN");
    }
}