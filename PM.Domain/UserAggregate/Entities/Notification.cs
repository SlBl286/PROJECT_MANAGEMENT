using PM.Domain.Common.Models;
using PM.Domain.ProjectAggregate.Enums;
using PM.Domain.ProjectAggregate.ValueObjects;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Domain.UserAggregate.Entities;

public sealed class Notification : Entity<NotificationId>
{
    public string Message { get; private set; }
    public bool IsRead { get; private set; }
    private Notification(NotificationId id, string message,bool isRead) : base(id)
    {
      Message = message;
      IsRead = isRead;
    }
    public static Notification Create(NotificationId id, string message,bool isRead)
    {
        return new Notification(id, message, isRead);
    }

#pragma warning disable CS0618
    private Notification() { }
#pragma warning restore CS0618
}