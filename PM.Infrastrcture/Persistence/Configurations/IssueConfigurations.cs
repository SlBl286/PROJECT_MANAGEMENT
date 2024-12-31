using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.Domain.IssueAggregate;
using PM.Domain.IssueAggregate.Entities;
using PM.Domain.IssueAggregate.ValueObjects;
using PM.Domain.ProjectAggregate;
using PM.Domain.ProjectAggregate.Entities;
using PM.Domain.ProjectAggregate.ValueObjects;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Infrastrcture.Persistence.Configurations;

public class IssueConfigurrations : IEntityTypeConfiguration<Issue>
{
    public void Configure(EntityTypeBuilder<Issue> builder)
    {
        ConfigureIssueCommentTable(builder);
        ConfigureIssueAttachTable(builder);
        ConfigureIssueTable(builder);

    }
    private void ConfigureIssueCommentTable(EntityTypeBuilder<Issue> builder)
    {
        builder.OwnsMany(i => i.Comments, sb =>
        {
            sb.ToTable("IssueComments");
            sb.WithOwner().HasForeignKey("IssueId");

            sb.HasKey(nameof(Comment.Id), "IssueId");

            sb.Property(b => b.Id)
                .HasColumnName("CommentId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => CommentId.Create(value)
            );
            sb.Property(b => b.UserId)
                .HasColumnName("UserId")
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value)
            );
            sb.Property(b => b.Content).HasMaxLength(int.MaxValue-2);

        });

        builder.Metadata.FindNavigation(nameof(Issue.Comments))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
    
    private void ConfigureIssueAttachTable(EntityTypeBuilder<Issue> builder)
    {
        builder.OwnsMany(i => i.Attachments, sb =>
        {
            sb.ToTable("IssueAttachments");
            sb.WithOwner().HasForeignKey("IssueId");

            sb.HasKey(nameof(Attachment.Id), "IssueId");

            sb.Property(b => b.Id)
                .HasColumnName("AttachmentId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => AttachmentId.Create(value)
            );
            sb.Property(b => b.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value)
            );
            sb.Property(b => b.FileName).HasMaxLength(100);
            sb.Property(b => b.FilePath).HasMaxLength(255);

        });

        builder.Metadata.FindNavigation(nameof(Issue.Comments))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureIssueTable(EntityTypeBuilder<Issue> builder)
    {
        builder.ToTable("Issues");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => IssueId.Create(value)
            );
        builder.Property(m => m.Code)
            .HasMaxLength(100);
        builder.Property(m => m.Title)
            .HasMaxLength(255);
        builder.Property(m => m.Description)
            .HasMaxLength(int.MaxValue - 2);
        builder.Property(b => b.Status).HasConversion<int>();
        builder.Property(b => b.Priority).HasConversion<int>();
        builder.Property(b => b.Type).HasConversion<int>();
        builder.Property(b => b.AssigneeId)
               .HasColumnName("AssigneeId")
               .HasConversion(
                   id => id.Value,
                   value => UserId.Create(value)
           );
        builder.Property(b => b.ReporterId)
           .HasColumnName("ReporterId")
           .HasConversion(
               id => id.Value,
               value => UserId.Create(value)
       );
        builder.Property(b => b.ProjectId)
     .HasColumnName("ProjectId")
     .HasConversion(
         id => id.Value,
         value => ProjectId.Create(value)
 );
        builder
       .HasIndex(u => u.Code)
       .IsUnique();

        builder.HasGeneratedTsVectorColumn(wh => wh.SearchVector, "vietnamese",
        wh => new { wh.Code, wh.Title, wh.Description, }
       ).HasIndex(ic => ic.SearchVector)
       .HasMethod("GIN");

    }
}