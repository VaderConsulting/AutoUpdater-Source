using AutoUpdaterDotNET;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoUpdater.Tests
{
    [TestClass]
    public class UpdatePathTests
    {
        [TestMethod]
        public void IsFilePath_ReturnsTrueForUncPath()
        {
            Assert.IsTrue(UpdatePath.IsFilePath(@"\\server\share\update.xml"));
        }

        [TestMethod]
        public void IsFilePath_ReturnsTrueForFileUri()
        {
            Assert.IsTrue(UpdatePath.IsFilePath("file:///C:/Updates/update.xml"));
        }

        [TestMethod]
        public void IsFilePath_ReturnsFalseForHttpUri()
        {
            Assert.IsFalse(UpdatePath.IsFilePath("https://example.com/update.xml"));
        }

        [TestMethod]
        public void IsFilePath_ReturnsFalseForBlankValue()
        {
            Assert.IsFalse(UpdatePath.IsFilePath(""));
            Assert.IsFalse(UpdatePath.IsFilePath(null));
        }

        [TestMethod]
        public void GetFilePath_ReturnsLocalPathForFileUri()
        {
            Assert.AreEqual(@"C:\Updates\update.xml", UpdatePath.GetFilePath("file:///C:/Updates/update.xml"));
        }

        [TestMethod]
        public void GetFilePath_ReturnsOriginalPathForUncPath()
        {
            string path = @"\\server\share\update.xml";

            Assert.AreEqual(path, UpdatePath.GetFilePath(path));
        }
    }
}
