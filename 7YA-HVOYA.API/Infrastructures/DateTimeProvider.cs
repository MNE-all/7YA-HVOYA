using _7YA_HVOYA.Common;

namespace _7YA_HVOYA.API.Infrastructures
{
    public class DateTimeProvider : IDateTimeProvider
    {
        DateTimeOffset IDateTimeProvider.UtcNow => DateTimeOffset.UtcNow;
    }
}
