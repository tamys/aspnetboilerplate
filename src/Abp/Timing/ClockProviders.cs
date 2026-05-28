using System;

namespace Abp.Timing
{
    public static class ClockProviders
    {
        public static UnspecifiedClockProvider Unspecified { get; } = new UnspecifiedClockProvider();

        public static LocalClockProvider Local { get; } = new LocalClockProvider();

        public static UtcClockProvider Utc { get; } = new UtcClockProvider();

        public static TimeProviderClockProvider TimeProviderLocal { get; } = new TimeProviderClockProvider(TimeProvider.System);

        public static UtcTimeProviderClockProvider TimeProviderUtc { get; } = new UtcTimeProviderClockProvider(TimeProvider.System);
    }
}