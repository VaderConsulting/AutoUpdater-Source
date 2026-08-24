using System;
using AutoUpdaterDotNET;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Updater = AutoUpdaterDotNET.AutoUpdater;

namespace AutoUpdater.Tests
{
    [TestClass]
    public class ReminderScheduleTests
    {
        [TestMethod]
        public void GetReminderTime_AddsMinutes()
        {
            DateTime now = new DateTime(2026, 4, 17, 10, 0, 0);

            Assert.AreEqual(now.AddMinutes(30), ReminderSchedule.GetReminderTime(now, 30, Updater.RemindLaterFormat.Minutes));
        }

        [TestMethod]
        public void GetReminderTime_AddsHours()
        {
            DateTime now = new DateTime(2026, 4, 17, 10, 0, 0);

            Assert.AreEqual(now.AddHours(12), ReminderSchedule.GetReminderTime(now, 12, Updater.RemindLaterFormat.Hours));
        }

        [TestMethod]
        public void GetReminderTime_AddsDays()
        {
            DateTime now = new DateTime(2026, 4, 17, 10, 0, 0);

            Assert.AreEqual(now.AddDays(8), ReminderSchedule.GetReminderTime(now, 8, Updater.RemindLaterFormat.Days));
        }

        [TestMethod]
        public void GetTimerIntervalMilliseconds_ReturnsOneForPastTime()
        {
            DateTime now = new DateTime(2026, 4, 17, 10, 0, 0);

            Assert.AreEqual(1, ReminderSchedule.GetTimerIntervalMilliseconds(now, now.AddSeconds(-1)));
        }

        [TestMethod]
        public void GetTimerIntervalMilliseconds_ReturnsMillisecondsForFutureTime()
        {
            DateTime now = new DateTime(2026, 4, 17, 10, 0, 0);

            Assert.AreEqual(5000, ReminderSchedule.GetTimerIntervalMilliseconds(now, now.AddSeconds(5)));
        }

        [TestMethod]
        public void GetTimerIntervalMilliseconds_ClampsVeryLongInterval()
        {
            DateTime now = new DateTime(2026, 4, 17, 10, 0, 0);

            Assert.AreEqual(int.MaxValue, ReminderSchedule.GetTimerIntervalMilliseconds(now, now.AddDays(90)));
        }
    }
}
