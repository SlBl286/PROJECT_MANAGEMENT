using PM.Application.Common.Interfaces.Services;

namespace PM.Infrastrcture.Services;

public class DatetimeProvider : IDatetimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}