using System;

namespace Abp.Timing
{
    /// <summary>
    /// Implements <see cref="IClockProvider"/> to work with local times using <see cref="TimeProvider"/>.
    /// </summary>
    public class TimeProviderClockProvider : IClockProvider
    {
        private readonly TimeProvider _timeProvider;

        public DateTime Now => _timeProvider.GetLocalNow().DateTime;

        public DateTimeKind Kind => DateTimeKind.Local;

        public bool SupportsMultipleTimezone => true;

        public DateTime Normalize(DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Unspecified)
            {
                return DateTime.SpecifyKind(dateTime, DateTimeKind.Local);
            }

            if (dateTime.Kind == DateTimeKind.Utc)
            {
                return dateTime.ToLocalTime();
            }

            return dateTime;
        }

        public TimeProviderClockProvider(TimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }
    }
}
