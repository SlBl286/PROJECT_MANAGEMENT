namespace PM.Application.Common.Interfaces.Services;

public interface IDatetimeProvider
{
    DateTime UtcNow { get; }
}