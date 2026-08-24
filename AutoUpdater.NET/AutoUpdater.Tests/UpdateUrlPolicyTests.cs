using System;
using AutoUpdaterDotNET;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoUpdater.Tests
{
    [TestClass]
    public class UpdateUrlPolicyTests
    {
        [TestMethod]
        public void ValidateAppCastUrl_AllowsHttpsLoopbackHttpAndFilePaths()
        {
            UpdateUrlPolicy.ValidateAppCastUrl("https://example.com/appcast.xml");
            UpdateUrlPolicy.ValidateAppCastUrl("http://localhost/appcast.xml");
            UpdateUrlPolicy.ValidateAppCastUrl(@"\\server\share\appcast.xml");
            UpdateUrlPolicy.ValidateAppCastUrl("file:///C:/Updates/appcast.xml");
        }

        [TestMethod]
        public void ValidateAppCastUrl_RejectsEmptyUrl()
        {
            AssertThrowsArgumentException(() => UpdateUrlPolicy.ValidateAppCastUrl(""));
        }

        [TestMethod]
        public void ValidateAppCastUrl_RejectsNonLoopbackHttp()
        {
            AssertThrowsArgumentException(() => UpdateUrlPolicy.ValidateAppCastUrl("http://example.com/appcast.xml"));
        }

        [TestMethod]
        public void ValidateAppCastUrl_RejectsUnsupportedScheme()
        {
            AssertThrowsArgumentException(() => UpdateUrlPolicy.ValidateAppCastUrl("ftp://example.com/appcast.xml"));
        }

        private static void AssertThrowsArgumentException(Action action)
        {
            try
            {
                action();
                Assert.Fail("Expected ArgumentException.");
            }
            catch (ArgumentException)
            {
            }
        }
    }
}
