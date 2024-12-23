using PM.Domain.Common.Models;
using PM.Domain.IssueAggregate.ValueObjects;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Domain.IssueAggregate.Entities;

public sealed class Attachment : Entity<AttachmentId>
{
    public string FileName { get; private set; }
    public string FilePath { get; private set; }

    public UserId CreatedBy { get; private set; }

    private Attachment(AttachmentId id, string fileName,string filePath, UserId createdBy) : base(id)
    {
       FileName = fileName;
       FilePath = filePath;
       CreatedBy = createdBy;
    }
    public static Attachment Create(AttachmentId id, string fileName,string filePath, UserId createdBy)
    {
        return new Attachment(id, fileName, filePath, createdBy);
    }

#pragma warning disable CS0618
    private Attachment() { }
#pragma warning restore CS0618
}