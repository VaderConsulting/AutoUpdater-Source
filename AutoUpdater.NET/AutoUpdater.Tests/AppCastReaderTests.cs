using System;
using System.IO;
using System.Text;
using AutoUpdaterDotNET;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoUpdater.Tests
{
    [TestClass]
    public class AppCastReaderTests
    {
        [TestMethod]
        public void Read_ParsesSingleItem()
        {
            UpdateInfo update = ReadOne("<item><version>2.0.0.0</version><title>Release</title><changelog>notes.htm</changelog><url>setup.exe</url><sha512>abc512</sha512><sha256>abc256</sha256></item>");

            Assert.AreEqual(new Version(2, 0, 0, 0), update.Version);
            Assert.AreEqual("Release", update.Title);
            Assert.AreEqual("notes.htm", update.ChangeLogUrl);
            Assert.AreEqual("setup.exe", update.DownloadUrl);
            Assert.AreEqual("abc512", update.Sha512);
            Assert.AreEqual("abc256", update.Sha256);
        }

        [TestMethod]
        public void Read_UsesEmptyStringsForOptionalFields()
        {
            UpdateInfo update = ReadOne("<item><version>2.0.0.0</version></item>");

            Assert.AreEqual("", update.Title);
            Assert.AreEqual("", update.ChangeLogUrl);
            Assert.AreEqual("", update.DownloadUrl);
        }

        [TestMethod]
        public void Read_IgnoresItemsWithoutVersion()
        {
            var updates = AppCastReader.Read(ToStream("<item><title>Missing Version</title></item>"));

            Assert.AreEqual(0, updates.Count);
        }

        [TestMethod]
        public void Read_IgnoresItemsWithInvalidVersion()
        {
            var updates = AppCastReader.Read(ToStream("<item><version>not-a-version</version></item>"));

            Assert.AreEqual(0, updates.Count);
        }

        [TestMethod]
        public void Read_ReturnsMultipleItems()
        {
            var updates = AppCastReader.Read(ToStream("<items>" +
                "<item><version>1.0.0.0</version></item>" +
                "<item><version>2.0.0.0</version></item>" +
                "</items>"));

            Assert.AreEqual(2, updates.Count);
            Assert.AreEqual(new Version(1, 0, 0, 0), updates[0].Version);
            Assert.AreEqual(new Version(2, 0, 0, 0), updates[1].Version);
        }

        [TestMethod]
        public void Read_ThrowsForMalformedXml()
        {
            try
            {
                AppCastReader.Read(ToStream("<item>"));
                Assert.Fail("Expected malformed XML to throw.");
            }
            catch (System.Xml.XmlException)
            {
            }
        }

        [TestMethod]
        public void SelectLatestNewerThan_ReturnsNullWhenNoUpdateIsNewer()
        {
            var updates = AppCastReader.Read(ToStream("<items>" +
                "<item><version>1.0.0.0</version></item>" +
                "<item><version>2.0.0.0</version></item>" +
                "</items>"));

            UpdateInfo selected = AppCastReader.SelectLatestNewerThan(updates, new Version(2, 0, 0, 0));

            Assert.IsNull(selected);
        }

        [TestMethod]
        public void SelectLatestNewerThan_ReturnsHighestNewerVersion()
        {
            var updates = AppCastReader.Read(ToStream("<items>" +
                "<item><version>2.0.0.0</version><title>Two</title></item>" +
                "<item><version>3.0.0.0</version><title>Three</title></item>" +
                "<item><version>1.5.0.0</version><title>Old</title></item>" +
                "</items>"));

            UpdateInfo selected = AppCastReader.SelectLatestNewerThan(updates, new Version(1, 0, 0, 0));

            Assert.IsNotNull(selected);
            Assert.AreEqual(new Version(3, 0, 0, 0), selected.Version);
            Assert.AreEqual("Three", selected.Title);
        }

        private static UpdateInfo ReadOne(string xml)
        {
            var updates = AppCastReader.Read(ToStream(xml));
            Assert.AreEqual(1, updates.Count);
            return updates[0];
        }

        private static Stream ToStream(string xml)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(xml));
        }
    }
}
