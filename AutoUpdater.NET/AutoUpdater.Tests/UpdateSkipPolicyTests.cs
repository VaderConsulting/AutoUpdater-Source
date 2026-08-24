using System;
using AutoUpdaterDotNET;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoUpdater.Tests
{
    [TestClass]
    public class UpdateSkipPolicyTests
    {
        [TestMethod]
        public void ShouldSkipUpdate_ReturnsTrueWhenSkippedVersionMatchesCurrentUpdate()
        {
            bool resetSkip;

            bool shouldSkip = UpdateSkipPolicy.ShouldSkipUpdate("1", "2.0.0.0", new Version(2, 0, 0, 0), out resetSkip);

            Assert.IsTrue(shouldSkip);
            Assert.IsFalse(resetSkip);
        }

        [TestMethod]
        public void ShouldSkipUpdate_ReturnsTrueWhenSkippedVersionIsNewerThanCurrentUpdate()
        {
            bool resetSkip;

            bool shouldSkip = UpdateSkipPolicy.ShouldSkipUpdate("1", "3.0.0.0", new Version(2, 0, 0, 0), out resetSkip);

            Assert.IsTrue(shouldSkip);
            Assert.IsFalse(resetSkip);
        }

        [TestMethod]
        public void ShouldSkipUpdate_RequestsResetWhenCurrentVersionIsNewerThanSkippedVersion()
        {
            bool resetSkip;

            bool shouldSkip = UpdateSkipPolicy.ShouldSkipUpdate("1", "2.0.0.0", new Version(3, 0, 0, 0), out resetSkip);

            Assert.IsFalse(shouldSkip);
            Assert.IsTrue(resetSkip);
        }

        [TestMethod]
        public void ShouldSkipUpdate_DoesNotSkipWhenSkipFlagIsNotSet()
        {
            bool resetSkip;

            bool shouldSkip = UpdateSkipPolicy.ShouldSkipUpdate("0", "2.0.0.0", new Version(2, 0, 0, 0), out resetSkip);

            Assert.IsFalse(shouldSkip);
            Assert.IsFalse(resetSkip);
        }

        [TestMethod]
        public void ShouldSkipUpdate_IgnoresInvalidSkippedVersion()
        {
            bool resetSkip;

            bool shouldSkip = UpdateSkipPolicy.ShouldSkipUpdate("1", "bad-version", new Version(2, 0, 0, 0), out resetSkip);

            Assert.IsFalse(shouldSkip);
            Assert.IsFalse(resetSkip);
        }

        [TestMethod]
        public void ShouldSkipUpdate_IgnoresMissingValues()
        {
            bool resetSkip;

            bool shouldSkip = UpdateSkipPolicy.ShouldSkipUpdate(null, null, new Version(2, 0, 0, 0), out resetSkip);

            Assert.IsFalse(shouldSkip);
            Assert.IsFalse(resetSkip);
        }
    }
}
