using System;
using System.IO;
using System.Reflection;
using Microsoft.Win32;
using System.ComponentModel;
using System.Net.Http;
using System.Threading;

namespace AutoUpdaterDotNET
{
    //https://autoupdaterdotnet.codeplex.com/
    
    public class AutoUpdater
    {
        public static event EventHandler<AutoUpdaterErrorEventArgs> Error;

        public enum RemindLaterFormat
        {
            Minutes,
            Hours,
            Days
        }

        private static String _title;
        private static String _changeLogUrl;
        private static String _downloadUrl;
        private static String _sha512;
        private static String _sha256;
        private static String _UpdateUrl;
        private static String _appTitle;
        private static Version _currentVersion;
        private static Version _installedVersion;
        private static int _remindLaterAt;
        private static String _appCompany;
        private static String _registryLocation;
        private static Boolean _letUserSelectRemindLater;
        private static RemindLaterFormat _remindLaterFormat;
        private static readonly HttpClient HttpClient = new HttpClient();
        private static System.Timers.Timer _reminderTimer;

        public static void Start(String UpdateURL, bool letUserSelectRemindLater = true, int remindLaterAt = 1, RemindLaterFormat remindLaterFormat = RemindLaterFormat.Days)
        {
            _UpdateUrl = UpdateURL;
            _remindLaterAt = remindLaterAt;
            _remindLaterFormat = remindLaterFormat;
            _letUserSelectRemindLater = letUserSelectRemindLater;
            _currentVersion = null;
            _title = null;
            _changeLogUrl = null;
            _downloadUrl = null;
            _sha512 = null;
            _sha256 = null;
            
            var backgroundWorker = new BackgroundWorker();

            backgroundWorker.DoWork += BackgroundWorkerDoWork;

            backgroundWorker.RunWorkerAsync();
        }

        public static void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            _appTitle = Assembly.GetEntryAssembly().GetName().Name;

            Assembly currentAssembly = typeof(AutoUpdater).Assembly;
            object[] attribs = currentAssembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), true);
            if(attribs.Length > 0)
            {
                _appCompany = ((AssemblyCompanyAttribute)attribs[0]).Company;
            }

            if (string.IsNullOrEmpty(_appCompany))
                _appCompany = _appTitle;

            _registryLocation = "Software\\" + _appCompany + "\\" + _appTitle + "\\AutoUpdater";

            RegistryKey updateKey = UpdateRegistryStore.Open(_registryLocation);

            if (updateKey != null)
            {
                object remindLaterTime = updateKey.GetValue("remindlater");

                if (remindLaterTime != null)
                {
                    DateTime remindLater = DateTime.Parse(remindLaterTime.ToString());

                    int compareResult = DateTime.Compare(DateTime.Now, remindLater);

                    if (compareResult < 0)
                    {
                        ScheduleReminder(remindLater);
                        return;
                    }
                }
            }

            _installedVersion = Assembly.GetEntryAssembly().GetName().Version;

            UpdateInfo update;

            try
            {
                using (Stream UpdateStream = OpenUpdateStream(_UpdateUrl))
                {
                    if (UpdateStream != null && UpdateStream.CanRead == true)
                        update = AppCastReader.SelectLatestNewerThan(AppCastReader.Read(UpdateStream), _installedVersion);
                    else return;
                }
            }
            catch (Exception exception)
            {
                OnError(exception);
                return;
            }

            if (update != null)
            {
                _currentVersion = update.Version;
                _title = update.Title;
                _changeLogUrl = update.ChangeLogUrl;
                _downloadUrl = update.DownloadUrl;
                _sha512 = update.Sha512;
                _sha256 = update.Sha256;
            }

            if (updateKey != null)
            {
                object skip = updateKey.GetValue("skip");
                object applicationVersion = updateKey.GetValue("version");
                if (skip != null && applicationVersion != null)
                {
                    bool resetSkip;
                    if (UpdateSkipPolicy.ShouldSkipUpdate(skip.ToString(), applicationVersion.ToString(), _currentVersion, out resetSkip))
                        return;

                    if (resetSkip)
                    {
                        UpdateRegistryStore.ResetSkip(_registryLocation, _currentVersion);
                    }
                }
                updateKey.Close();
            }

            if (_currentVersion == null)
                return;

            if (_currentVersion > _installedVersion)
            {
                var thread = new Thread(ShowUi);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
        }

        private static void ShowUi()
        {
            var updateForm = new UpdateForm(_title, _UpdateUrl, _appTitle, _currentVersion, _installedVersion, _changeLogUrl, _downloadUrl, _registryLocation, _remindLaterAt, _remindLaterFormat, _letUserSelectRemindLater, _sha512, _sha256);

            updateForm.ShowDialog();
        }

        private static Stream OpenUpdateStream(string updateUrl)
        {
            UpdateUrlPolicy.ValidateAppCastUrl(updateUrl);

            if (UpdatePath.IsFilePath(updateUrl))
            {
                return File.OpenRead(UpdatePath.GetFilePath(updateUrl));
            }

            return HttpClient.GetStreamAsync(updateUrl).GetAwaiter().GetResult();
        }

        private static void ScheduleReminder(DateTime remindLater)
        {
            if (_reminderTimer != null)
            {
                _reminderTimer.Stop();
                _reminderTimer.Dispose();
            }

            _reminderTimer = new System.Timers.Timer(ReminderSchedule.GetTimerIntervalMilliseconds(DateTime.Now, remindLater));
            _reminderTimer.Elapsed += ReminderTimerElapsed;
            _reminderTimer.Start();
        }

        private static void ReminderTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _reminderTimer.Stop();
            Start(_UpdateUrl, _letUserSelectRemindLater, _remindLaterAt, _remindLaterFormat);
        }

        private static void OnError(Exception exception)
        {
            EventHandler<AutoUpdaterErrorEventArgs> handler = Error;
            if (handler != null)
                handler(null, new AutoUpdaterErrorEventArgs(exception));
        }
    }
}
