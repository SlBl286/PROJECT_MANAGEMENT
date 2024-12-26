using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.Domain.ProjectAggregate;
using PM.Domain.ProjectAggregate.Entities;
using PM.Domain.ProjectAggregate.ValueObjects;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Infrastrcture.Persistence.Configurations;

public class ProjectConfigurrations : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        ConfigureProjectTable(builder);
        ConfigureProjectMemberTable(builder);

    }
    private void ConfigureProjectMemberTable(EntityTypeBuilder<Project> builder)
    {
        builder.OwnsMany(i => i.Members, sb =>
        {
            sb.ToTable("ProjectMembers");
            sb.WithOwner().HasForeignKey("ProjectId");

            sb.HasKey(nameof(Member.Id), "ProjectId");

            sb.Property(b => b.Id)
                .HasColumnName("MemberId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MemberId.Create(value)
            );
            sb.Property(b => b.UserId)
                .HasColumnName("UserId")
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value)
            );
            sb.Property(b => b.Role).HasConversion<int>();

        });

        builder.Metadata.FindNavigation(nameof(Project.Members))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureProjectTable(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Projects");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ProjectId.Create(value)
            );
    
        builder.Property(m => m.Code)
            .HasMaxLength(100);
        builder.Property(m => m.Name)
            .HasMaxLength(255);
        builder.Property(m => m.Description).IsRequired(false);
        builder.Property(b => b.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value)
            );
        builder
       .HasIndex(u => u.Code)
       .IsUnique();

        builder.HasGeneratedTsVectorColumn(wh => wh.SearchVector, "vietnamese",
        wh => new { wh.Code, wh.Name, wh.Description }
       ).HasIndex(ic => ic.SearchVector)
       .HasMethod("GIN");

    }
}