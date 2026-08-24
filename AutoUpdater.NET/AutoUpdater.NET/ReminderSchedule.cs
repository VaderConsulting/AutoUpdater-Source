using System;

namespace AutoUpdaterDotNET
{
    internal static class ReminderSchedule
    {
        public static DateTime GetReminderTime(DateTime now, int remindLaterAt, AutoUpdater.RemindLaterFormat format)
        {
            switch (format)
            {
                case AutoUpdater.RemindLaterFormat.Minutes:
                    return now + TimeSpan.FromMinutes(remindLaterAt);
                case AutoUpdater.RemindLaterFormat.Hours:
                    return now + TimeSpan.FromHours(remindLaterAt);
                case AutoUpdater.RemindLaterFormat.Days:
                    return now + TimeSpan.FromDays(remindLaterAt);
                default:
                    throw new ArgumentOutOfRangeException(nameof(format));
            }
        }

        public static double GetTimerIntervalMilliseconds(DateTime now, DateTime remindLater)
        {
            TimeSpan timeSpan = remindLater - now;
            if (timeSpan.TotalMilliseconds <= 0)
                return 1;

            return Math.Min(timeSpan.TotalMilliseconds, int.MaxValue);
        }
    }
}
