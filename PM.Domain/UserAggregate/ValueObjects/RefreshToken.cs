using System.Security.Cryptography;
using PM.Domain.Common.Models;

namespace PM.Domain.UserAggregate.ValueObjects;
public sealed class RefreshToken : ValueObject
{
    public string Value { get; private set; }
    public DateTime ExpireTime { get;private set; }

    private RefreshToken(string value, DateTime expireTime)
    {
        Value = value;
        ExpireTime = expireTime;
    }

    public static RefreshToken Create(DateTime expireTime)
    {
        return new(Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),expireTime);
    }
    public static RefreshToken Create(string token, DateTime expireTime)
    {
       return new(token,expireTime);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}