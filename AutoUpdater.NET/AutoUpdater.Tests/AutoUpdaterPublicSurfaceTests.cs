using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using AutoUpdaterDotNET;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Updater = AutoUpdaterDotNET.AutoUpdater;

namespace AutoUpdater.Tests
{
    [TestClass]
    public class AutoUpdaterPublicSurfaceTests
    {
        [TestMethod]
        public void Start_AcceptsLocalFileAppcastPath()
        {
            string appcastPath = CreateAppcast("0.0.0.1", "Local Path Update", @"\\server\share\Installer.exe");

            Updater.Start(appcastPath);

            Thread.Sleep(250);
        }

        [TestMethod]
        public void BackgroundWorkerDoWork_AcceptsNetworkStyleAppcastPath()
        {
            string appcastPath = CreateAppcast("0.0.0.1", "Network Path Update", @"\\server\share\Installer.exe");
            string networkStylePath = @"\\" + Environment.MachineName + @"\" + appcastPath.TrimStart(Path.DirectorySeparatorChar).Replace(':', '$');

            Updater.BackgroundWorkerDoWork(null, new DoWorkEventArgs(networkStylePath));
        }

        [TestMethod]
        public void DownloadUpdateDialog_ConstructorAcceptsNetworkPath()
        {
            RunInSta(() =>
            {
                using (var dialog = new DownloadUpdateDialog(@"\\server\share\Installer.exe"))
                {
                    Assert.AreEqual("Software Update", dialog.Text);
                }
            });
        }

        [TestMethod]
        public void UpdateForm_MainConstructorInitializesPublicTextProperty()
        {
            RunInSta(() =>
            {
                using (var form = new UpdateForm(
                    "Update Available",
                    @"\\server\share\appcast.xml",
                    "Test App",
                    new Version(2, 0, 0, 0),
                    new Version(1, 0, 0, 0),
                    "about:blank",
                    @"\\server\share\Installer.exe",
                    @"Software\Test App\AutoUpdater",
                    1,
                    Updater.RemindLaterFormat.Days,
                    true))
                {
                    Assert.AreEqual("Update Available", form.Text);

                    form.Text = "Changed";

                    Assert.AreEqual("Changed", form.Text);
                }
            });
        }

        [TestMethod]
        public void UpdateForm_ReminderConstructorCanBeDisposed()
        {
            RunInSta(() =>
            {
                using (new UpdateForm(
                    DateTime.Now.AddDays(1),
                    @"\\server\share\appcast.xml",
                    @"Software\Test App\AutoUpdater",
                    1,
                    Updater.RemindLaterFormat.Days,
                    true))
                {
                }
            });
        }

        [TestMethod]
        public void RemindLaterForm_ConstructorAndPropertiesWork()
        {
            RunInSta(() =>
            {
                using (var form = new RemindLaterForm("Test App"))
                {
                    form.RemindLaterFormat = Updater.RemindLaterFormat.Hours;
                    form.RemindLaterAt = 12;

                    Assert.AreEqual(Updater.RemindLaterFormat.Hours, form.RemindLaterFormat);
                    Assert.AreEqual(12, form.RemindLaterAt);
                }
            });
        }

        private static string CreateAppcast(string version, string title, string downloadUrl)
        {
            string appcastPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".xml");
            File.WriteAllText(appcastPath,
                "<item>" +
                "<version>" + version + "</version>" +
                "<title>" + title + "</title>" +
                "<changelog>about:blank</changelog>" +
                "<url>" + downloadUrl + "</url>" +
                "</item>");

            return appcastPath;
        }

        private static void RunInSta(Action action)
        {
            Exception exception = null;
            var thread = new Thread(() =>
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            if (exception != null)
                throw exception;
        }
    }
}
