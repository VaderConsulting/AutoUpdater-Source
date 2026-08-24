using System;
using System.Windows.Forms;
namespace AutoUpdaterDotNET
{
    public partial class UpdateForm : Form
    {
        private readonly string _url;

        private readonly string _downloadUrl;
        private readonly string _sha512;
        private readonly string _sha256;

        private readonly Version _currentVersion;

        private int _remindLaterAt;

        private System.Timers.Timer _timer;

        private readonly String _appCast;

        private readonly String _registryLocation;

        private AutoUpdater.RemindLaterFormat _remindLaterFormat;

        private readonly bool _letUserSelectRemindLater;

        private readonly string _appTitle;

        public UpdateForm(String title, String appCast, String appTitle, Version currentVersion, Version installedVersion, String url, String downloadUrl, String registryLocation, int remindLaterAt, AutoUpdater.RemindLaterFormat remindLaterFormat, bool letUserSelectRemindLater, string sha512 = "", string sha256 = "")
        {
            InitializeComponent();
            Text = title;
            _url = url;
            _appTitle = appTitle;
            _downloadUrl = downloadUrl;
            _sha512 = sha512;
            _sha256 = sha256;
            _currentVersion = currentVersion;
            _remindLaterAt = remindLaterAt;
            _remindLaterFormat = remindLaterFormat;
            _appCast = appCast;
            _registryLocation = registryLocation;
            _letUserSelectRemindLater = letUserSelectRemindLater;
            labelUpdate.Text = string.Format("A new version of {0} is available!", appTitle);
            labelDescription.Text = string.Format("{0} {1} is now available. You have version {2} installed. Would you like to download it now?", appTitle, currentVersion, installedVersion);
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        public UpdateForm(DateTime remindLater, String appCast, String registryLocation, int remindLaterAt, AutoUpdater.RemindLaterFormat remindLaterFormat, bool letUserSelectRemindLater)
        {
            SetTimer(remindLater);
            _appCast = appCast;
            _remindLaterAt = remindLaterAt;
            _remindLaterFormat = remindLaterFormat;
            _registryLocation = registryLocation;
            _letUserSelectRemindLater = letUserSelectRemindLater;
        }

        private void UpdateFormLoad(object sender, EventArgs e)
        {
            webBrowser.Navigate(_url);
        }

        private void ButtonUpdateClick(object sender, EventArgs e)
        {
            var downloadDialog = new DownloadUpdateDialog(_downloadUrl, _sha512, _sha256);

            try
            {
                downloadDialog.ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSkipClick(object sender, EventArgs e)
        {
            UpdateRegistryStore.SaveSkip(_registryLocation, _currentVersion);
        }

        private void ButtonRemindLaterClick(object sender, EventArgs e)
        {
            if(_letUserSelectRemindLater)
            {
                var remindLaterForm = new RemindLaterForm(_appTitle);

                var dialogResult = remindLaterForm.ShowDialog();

                if(dialogResult.Equals(DialogResult.OK))
                {
                    _remindLaterFormat = remindLaterForm.RemindLaterFormat;
                    _remindLaterAt = remindLaterForm.RemindLaterAt;
                }
                else if(dialogResult.Equals(DialogResult.Abort))
                {
                    var downloadDialog = new DownloadUpdateDialog(_downloadUrl, _sha512, _sha256);

                    try
                    {
                        downloadDialog.ShowDialog();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    return;
                }
                else
                {
                    DialogResult = DialogResult.None;
                    return;
                }
            }

            DateTime remindLater = ReminderSchedule.GetReminderTime(DateTime.Now, _remindLaterAt, _remindLaterFormat);
            switch (_remindLaterFormat)
            {
                case AutoUpdater.RemindLaterFormat.Days :
                    UpdateRegistryStore.SaveReminder(_registryLocation, _currentVersion, remindLater);
                    SetTimer(remindLater);
                    break;
                case AutoUpdater.RemindLaterFormat.Hours:
                    UpdateRegistryStore.SaveReminder(_registryLocation, _currentVersion, remindLater);
                    SetTimer(remindLater);
                    break;
                case AutoUpdater.RemindLaterFormat.Minutes:
                    UpdateRegistryStore.SaveReminder(_registryLocation, _currentVersion, remindLater);
                    SetTimer(remindLater);
                    break;
            }
        }

        private void SetTimer(DateTime remindLater)
        {
            _timer = new System.Timers.Timer();
            _timer.Interval = ReminderSchedule.GetTimerIntervalMilliseconds(DateTime.Now, remindLater);
            _timer.Elapsed += TimerElapsed;
            _timer.Start();
        }

        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Stop();
            AutoUpdater.Start(_appCast, _letUserSelectRemindLater,_remindLaterAt, _remindLaterFormat);
        }
    }
}
