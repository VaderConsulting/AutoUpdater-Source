using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using AutoUpdaterDotNET;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoUpdater.Tests
{
    [TestClass]
    public class UpdateDownloadServiceTests
    {
        [TestMethod]
        public void ValidateDownloadUrl_AllowsHttpsLoopbackHttpAndFilePaths()
        {
            UpdateDownloadService.ValidateDownloadUrl("https://example.com/setup.exe");
            UpdateDownloadService.ValidateDownloadUrl("http://localhost/setup.exe");
            UpdateDownloadService.ValidateDownloadUrl(@"\\server\share\setup.exe");
            UpdateDownloadService.ValidateDownloadUrl("file:///C:/Updates/setup.exe");
        }

        [TestMethod]
        public void ValidateDownloadUrl_RejectsEmptyUrl()
        {
            AssertThrowsArgumentException(() => UpdateDownloadService.ValidateDownloadUrl(""));
        }

        [TestMethod]
        public void ValidateDownloadUrl_RejectsUnsupportedScheme()
        {
            AssertThrowsArgumentException(() => UpdateDownloadService.ValidateDownloadUrl("ftp://example.com/setup.exe"));
        }

        [TestMethod]
        public void ValidateDownloadUrl_RejectsNonLoopbackHttp()
        {
            AssertThrowsArgumentException(() => UpdateDownloadService.ValidateDownloadUrl("http://example.com/setup.exe"));
        }

        [TestMethod]
        public void CreateUniqueTempPath_UsesUniqueDirectoryAndOriginalFilename()
        {
            string first = UpdateDownloadService.CreateUniqueTempPath("https://example.com/setup.exe");
            string second = UpdateDownloadService.CreateUniqueTempPath("https://example.com/setup.exe");

            Assert.AreEqual("setup.exe", Path.GetFileName(first));
            Assert.AreEqual("setup.exe", Path.GetFileName(second));
            Assert.AreNotEqual(Path.GetDirectoryName(first), Path.GetDirectoryName(second));
        }

        [TestMethod]
        public void CreateUniqueTempPath_UsesFallbackFilenameWhenUrlHasNoFilename()
        {
            string path = UpdateDownloadService.CreateUniqueTempPath("https://example.com/");

            Assert.AreEqual("update.bin", Path.GetFileName(path));
        }

        [TestMethod]
        public void VerifyChecksum_ReturnsFalseForMissingChecksumWhenRequired()
        {
            string path = CreateTempFile("hello");

            Assert.IsFalse(UpdateDownloadService.VerifyChecksum(path, "", "", true));
        }

        [TestMethod]
        public void VerifyChecksum_ReturnsTrueForMissingChecksumWhenNotRequired()
        {
            string path = CreateTempFile("hello");

            Assert.IsTrue(UpdateDownloadService.VerifyChecksum(path, "", "", false));
        }

        [TestMethod]
        public void VerifyChecksum_ReturnsTrueForMatchingSha512()
        {
            string path = CreateTempFile("hello");

            Assert.IsTrue(UpdateDownloadService.VerifyChecksum(path, ComputeSha512("hello"), "", true));
        }

        [TestMethod]
        public void VerifyChecksum_ReturnsFalseForMismatchedSha512()
        {
            string path = CreateTempFile("hello");

            Assert.IsFalse(UpdateDownloadService.VerifyChecksum(path, ComputeSha512("goodbye"), "", true));
        }

        [TestMethod]
        public void VerifyChecksum_FallsBackToSha256WhenSha512IsMissing()
        {
            string path = CreateTempFile("hello");

            Assert.IsTrue(UpdateDownloadService.VerifyChecksum(path, "", ComputeSha256("hello"), true));
        }

        [TestMethod]
        public void VerifyChecksum_PrefersSha512OverSha256()
        {
            string path = CreateTempFile("hello");

            Assert.IsFalse(UpdateDownloadService.VerifyChecksum(path, ComputeSha512("goodbye"), ComputeSha256("hello"), true));
        }

        [TestMethod]
        public void VerifySha512_ReturnsFalseForInvalidChecksum()
        {
            string path = CreateTempFile("hello");

            Assert.IsFalse(UpdateDownloadService.VerifySha512(path, "not-a-sha"));
        }

        [TestMethod]
        public void DownloadAsync_CopiesFilePathToDestination()
        {
            string source = CreateTempFile("payload");
            string destination = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".txt");
            var progress = new TestProgress();

            UpdateDownloadService.DownloadAsync(source, destination, progress).GetAwaiter().GetResult();

            Assert.AreEqual("payload", File.ReadAllText(destination));
            Assert.AreEqual(100, progress.Value);
        }

        private static string CreateTempFile(string text)
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".txt");
            File.WriteAllText(path, text);
            return path;
        }

        private static string ComputeSha256(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }

        private static string ComputeSha512(string text)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
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

        private sealed class TestProgress : IProgress<int>
        {
            public int Value { get; private set; }

            public void Report(int value)
            {
                Value = value;
            }
        }
    }
}
