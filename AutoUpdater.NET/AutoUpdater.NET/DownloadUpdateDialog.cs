using System;
using System.Windows.Forms;
using System.IO;

namespace AutoUpdaterDotNET
{
    public partial class DownloadUpdateDialog : Form
    {
        private readonly string _downloadUrl;
        private readonly string _sha512;
        private readonly string _sha256;

        private string _tempPath;

        public DownloadUpdateDialog(string downloadUrl, string sha512 = "", string sha256 = "")
        {
            InitializeComponent();

            _downloadUrl = downloadUrl;
            _sha512 = sha512;
            _sha256 = sha256;
        }

        private async void DownloadUpdateDialogLoad(object sender, EventArgs e)
        {
            try
            {
                _tempPath = UpdateDownloadService.CreateUniqueTempPath(_downloadUrl);
                await UpdateDownloadService.DownloadAsync(_downloadUrl, _tempPath, new Progress<int>(value => progressBar.Value = value));
                if (!UpdateDownloadService.VerifyChecksum(_tempPath, _sha512, _sha256, true))
                    throw new InvalidOperationException("The downloaded update failed checksum verification.");
                LaunchUpdate();
            }
            catch (Exception exception)
            {
                CleanupFailedDownload();
                MessageBox.Show(exception.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void LaunchUpdate()
        {
            UpdateDownloadService.Launch(_tempPath);
            Application.Exit();
        }

        private void CleanupFailedDownload()
        {
            if (!string.IsNullOrEmpty(_tempPath) && File.Exists(_tempPath))
                File.Delete(_tempPath);
        }
    }
}
