using System;

namespace AutoUpdaterDotNET
{
    internal sealed class UpdateInfo
    {
        public UpdateInfo(Version version, string title, string changeLogUrl, string downloadUrl, string sha512 = "", string sha256 = "")
        {
            Version = version;
            Title = title;
            ChangeLogUrl = changeLogUrl;
            DownloadUrl = downloadUrl;
            Sha512 = sha512;
            Sha256 = sha256;
        }

        public Version Version { get; }

        public string Title { get; }

        public string ChangeLogUrl { get; }

        public string DownloadUrl { get; }

        public string Sha512 { get; }

        public string Sha256 { get; }
    }
}
