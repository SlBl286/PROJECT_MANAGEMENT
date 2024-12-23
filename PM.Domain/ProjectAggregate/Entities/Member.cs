using PM.Domain.Common.Models;
using PM.Domain.ProjectAggregate.Enums;
using PM.Domain.ProjectAggregate.ValueObjects;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Domain.ProjectAggregate.Entities;

public sealed class Member : Entity<MemberId>
{
    public UserId UserId { get; private set; }
    public MemerRole Role { get; private set; }
    private Member(MemberId id,UserId userId, MemerRole role) : base(id)
    {
       Role = role;
       UserId = userId;
    }
    public static Member Create(MemberId id,UserId userId, MemerRole role)
    {
        return new Member(id,userId,role);
    }

#pragma warning disable CS0618
    private Member() { }
#pragma warning restore CS0618
}