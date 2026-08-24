using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AutoUpdaterDotNET
{
    internal static class UpdateDownloadService
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public static void ValidateDownloadUrl(string downloadUrl)
        {
            if (string.IsNullOrWhiteSpace(downloadUrl))
                throw new ArgumentException("Update download URL is empty.", nameof(downloadUrl));

            if (UpdatePath.IsFilePath(downloadUrl))
                return;

            Uri uri;
            if (!Uri.TryCreate(downloadUrl, UriKind.Absolute, out uri))
                throw new ArgumentException("Update download URL is not valid.", nameof(downloadUrl));

            if (uri.Scheme == Uri.UriSchemeHttps)
                return;

            if (uri.Scheme == Uri.UriSchemeHttp && uri.IsLoopback)
                return;

            throw new ArgumentException("Update download URL must use HTTPS, loopback HTTP, or a file path.", nameof(downloadUrl));
        }

        public static string CreateUniqueTempPath(string downloadUrl)
        {
            string sourcePath = UpdatePath.IsFilePath(downloadUrl) ? UpdatePath.GetFilePath(downloadUrl) : new Uri(downloadUrl).LocalPath;
            string filename = Path.GetFileName(sourcePath);

            if (string.IsNullOrWhiteSpace(filename))
                filename = "update.bin";

            string tempDirectory = Path.Combine(Path.GetTempPath(), "AutoUpdater.NET", Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(tempDirectory);

            return Path.Combine(tempDirectory, filename);
        }

        public static async Task DownloadAsync(string downloadUrl, string destinationPath, IProgress<int> progress)
        {
            ValidateDownloadUrl(downloadUrl);

            if (UpdatePath.IsFilePath(downloadUrl))
            {
                await Task.Run(() => File.Copy(UpdatePath.GetFilePath(downloadUrl), destinationPath, true));
                progress?.Report(100);
                return;
            }

            using (HttpResponseMessage response = await HttpClient.GetAsync(new Uri(downloadUrl), HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();

                long? contentLength = response.Content.Headers.ContentLength;
                using (Stream source = await response.Content.ReadAsStreamAsync())
                using (Stream destination = File.Create(destinationPath))
                {
                    var buffer = new byte[81920];
                    long totalRead = 0;
                    int bytesRead;

                    while ((bytesRead = await source.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await destination.WriteAsync(buffer, 0, bytesRead);
                        totalRead += bytesRead;

                        if (contentLength.HasValue && contentLength.Value > 0)
                            progress?.Report(Math.Min(100, (int)(totalRead * 100 / contentLength.Value)));
                    }
                }
            }
        }

        public static bool VerifyChecksum(string path, string expectedSha512, string expectedSha256, bool requireChecksum)
        {
            if (!string.IsNullOrWhiteSpace(expectedSha512))
                return VerifyHash(path, expectedSha512, 128, SHA512.Create);

            if (!string.IsNullOrWhiteSpace(expectedSha256))
                return VerifyHash(path, expectedSha256, 64, SHA256.Create);

            return !requireChecksum;
        }

        public static bool VerifySha512(string path, string expectedChecksum)
        {
            return VerifyHash(path, expectedChecksum, 128, SHA512.Create);
        }

        public static bool VerifySha256(string path, string expectedChecksum)
        {
            if (string.IsNullOrWhiteSpace(expectedChecksum))
                return false;

            return VerifyHash(path, expectedChecksum, 64, SHA256.Create);
        }

        private static bool VerifyHash(string path, string expectedChecksum, int expectedLength, Func<HashAlgorithm> createHashAlgorithm)
        {
            if (string.IsNullOrWhiteSpace(expectedChecksum))
                return false;

            string normalizedExpected = expectedChecksum.Replace(" ", "").Replace("-", "");
            if (normalizedExpected.Length != expectedLength)
                return false;

            using (Stream stream = File.OpenRead(path))
            using (HashAlgorithm hashAlgorithm = createHashAlgorithm())
            {
                byte[] hash = hashAlgorithm.ComputeHash(stream);
                string actual = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                return string.Equals(actual, normalizedExpected.ToLowerInvariant(), StringComparison.Ordinal);
            }
        }

        public static void Launch(string path)
        {
            var processStartInfo = new ProcessStartInfo { FileName = path, UseShellExecute = true };
            Process.Start(processStartInfo);
        }
    }
}
