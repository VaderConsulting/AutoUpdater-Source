using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Browser
{
    public partial class frmOptions : Form
    {
        #region Constants

        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Enums

        #endregion

        #region DLL Imports

        #endregion

        #region Fields

        private string _LastSharedSelectedDirectory = "";
        private string _LastB4aSelectedDirectory = "";
        private string _LastB4iSelectedDirectory = "";
        private string _LastB4jSelectedDirectory = "";
        private string _LastB4rSelectedDirectory = "";
        ResourceManager _ResourceManager = null;
        bool _UpdatingGUI = false;
        public bool ChangeInOptions = false;

        #endregion

        #region Properties

        #endregion

        #region Constructors and Destructor

        public frmOptions(float FontSize)
        {
            InitializeComponent();

            // Init _ResourceManager
            _ResourceManager = new ResourceManager("Browser.Strings", Assembly.GetExecutingAssembly());
            // Init UICulture to CurrentCulture
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            this.Font = new Font(this.Font.FontFamily, FontSize);

            // Init Controls
            UpdateUIControls();
        }

        #endregion

        #region Event Handlers

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ChangeInOptions = false;
            this.Close();
        }

        private void btnClearSearchHistory_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AutoCompleteSelection != null)
            {
                Properties.Settings.Default.AutoCompleteSelection.Clear();
                Properties.Settings.Default.Save();
            }
        }

        private void btnCredits_Click(object sender, EventArgs e)
        {
            frmCredits CreditsForm = new frmCredits();

            CreditsForm.ShowDialog();

            CreditsForm = null;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportSettings();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportSettings();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            System.Collections.Specialized.StringCollection SharedList = new System.Collections.Specialized.StringCollection();
            System.Collections.Specialized.StringCollection B4aList = new System.Collections.Specialized.StringCollection();
            System.Collections.Specialized.StringCollection B4iList = new System.Collections.Specialized.StringCollection();
            System.Collections.Specialized.StringCollection B4jList = new System.Collections.Specialized.StringCollection();
            System.Collections.Specialized.StringCollection B4rList = new System.Collections.Specialized.StringCollection();

            // Additional Library paths
            for (int Counter = 0; Counter <= lstPathsShared.Items.Count - 1; Counter++)
            {
                SharedList.Add((lstPathsShared.Items[Counter].ToString()));
            }

            Properties.Settings.Default.AdditionalSharedLibraryPaths = SharedList;

            /////////////////////////////////////////////////////////////////////////////////////////////////
            for (int Counter = 0; Counter <= lstPathsB4a.Items.Count - 1; Counter++)
            {
                B4aList.Add((lstPathsB4a.Items[Counter].ToString()));
            }

            Properties.Settings.Default.AdditionalB4aLibraryPaths = B4aList;

            /////////////////////////////////////////////////////////////////////////////////////////////////

            for (int Counter = 0; Counter <= lstPathsB4i.Items.Count - 1; Counter++)
            {
                B4iList.Add((lstPathsB4i.Items[Counter].ToString()));
            }

            Properties.Settings.Default.AdditionalB4iLibraryPaths = B4iList;

            /////////////////////////////////////////////////////////////////////////////////////////////////

            for (int Counter = 0; Counter <= lstPathsB4j.Items.Count - 1; Counter++)
            {
                B4jList.Add((lstPathsB4j.Items[Counter].ToString()));
            }

            Properties.Settings.Default.AdditionalB4jLibraryPaths = B4jList;

            /////////////////////////////////////////////////////////////////////////////////////////////////

            for (int Counter = 0; Counter <= lstPathsB4r.Items.Count - 1; Counter++)
            {
                B4rList.Add((lstPathsB4r.Items[Counter].ToString()));
            }

            Properties.Settings.Default.AdditionalB4rLibraryPaths = B4rList;

            /////////////////////////////////////////////////////////////////////////////////////////////////

            Properties.Settings.Default.SharedHelpURL = txtHelpURLShared.Text;
            Properties.Settings.Default.B4aHelpURL = txtHelpURLB4a.Text;
            Properties.Settings.Default.B4iHelpURL = txtHelpURLB4i.Text;
            Properties.Settings.Default.B4jHelpURL = txtHelpURLB4j.Text;
            Properties.Settings.Default.B4rHelpURL = txtHelpURLB4r.Text;

            // Save
            Properties.Settings.Default.Save();

            // Export
            //ExportSettings();

            this.Close();
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string culture = "";

            if (!_UpdatingGUI)  // Prevents a recursion problem where changing the desired language causes this event to be raised
            {
                switch (cmbLanguage.Text)
                {
                    case "English":
                        culture = "en-US";
                        DoCultureCheckNo();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        break;
                    case "Afrikaans":
                        culture = "af-ZA";
                        DoCultureCheckNo();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        break;
                    case "العربية":
                        culture = "ar-SA";
                        DoCultureCheckYes();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                        break;
                    case "български":
                        culture = "bg-BG";
                        DoCultureCheckNo();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        break;
                    case "中文（简体":
                        culture = "zh-CN";
                        DoCultureCheckNo();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        break;
                    case "Deutsch":
                        culture = "de-DE";
                        DoCultureCheckNo();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        break;
                    case "español":
                        culture = "es-ES";
                        DoCultureCheckNo();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        break;
                    case "français":
                        culture = "fr-FR";
                        DoCultureCheckNo();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        break;
                    case "עברית":
                        culture = "he-IL";
                        DoCultureCheckYes();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                        break;
                    case "Bahasa Indonesia":
                        culture = "id-ID";
                        DoCultureCheckNo();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        break;
                    case "italiano":
                        culture = "it-IT";
                        DoCultureCheckNo();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        break;
                    case "日本語":
                        culture = "ja-JP";
                        DoCultureCheckNo();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        break;
                    case "Nederlands":
                        culture = "nl-NL";
                        DoCultureCheckNo();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        break;
                    case "norsk":
                        culture = "nn-NO";
                        DoCultureCheckNo();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        break;
                    case "polski":
                        culture = "pl-PL";
                        DoCultureCheckNo();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        break;
                    case "português":
                        culture = "pt-PT";
                        DoCultureCheckNo();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        break;
                    case "român":
                        culture = "ro-RO";
                        DoCultureCheckNo();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        break;
                    case "русский":
                        culture = "ru-RU";
                        DoCultureCheckNo();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        break;
                    case "svenska":
                        culture = "sv-SE";
                        DoCultureCheckNo();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        break;
                    case "ภาษาไทย":
                        culture = "th-TH";
                        DoCultureCheckNo();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        break;
                    case "Український":
                        culture = "uk-UA";
                        DoCultureCheckNo();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        break;
                    case "Việt":
                        culture = "vi-VN";
                        DoCultureCheckNo();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        break;
                    case "فارسی":
                        culture = "fa-IR";
                        DoCultureCheckYes();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                        break;
                    case "České":
                        culture = "cs-CZ";
                        DoCultureCheckNo();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        break;
                    case "Dansk":
                        culture = "da-DK";
                        DoCultureCheckNo();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        break;
                    case "Filipino":
                        culture = "fil-PH";
                        DoCultureCheckNo();
                        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        break;
                }

                // This is used for the language of the user interface
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
                // This is used with formatting and sort options (e.g. number and date formats)
                // e.g. a float value 2.352 will be 2,3.52 if CurrentCulture is set to de-DE
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);

                Properties.Settings.Default.Language = cmbLanguage.Text;
                Properties.Settings.Default.Save();

                Globals.SetPCLanguage(Properties.Settings.Default.Language);

                UpdateUIControls();
            }
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            int Counter = 0;

            this.TopMost = Properties.Settings.Default.AlwaysOnTop;

            if (System.IO.File.Exists(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "ExportedSettings.xml")))
            {
                btnImport.Enabled = true;
            }

            txtHelpURLShared.Text = Properties.Settings.Default.SharedHelpURL;
            txtHelpURLB4a.Text = Properties.Settings.Default.B4aHelpURL;
            txtHelpURLB4i.Text = Properties.Settings.Default.B4iHelpURL;
            txtHelpURLB4j.Text = Properties.Settings.Default.B4jHelpURL;
            txtHelpURLB4r.Text = Properties.Settings.Default.B4rHelpURL;


            // Paths
            if (Properties.Settings.Default.AdditionalSharedLibraryPaths != null)
            {
                // Additional Library paths
                for (Counter = 0; Counter < Properties.Settings.Default.AdditionalSharedLibraryPaths.Count; Counter++)
                {
                    lstPathsShared.Items.Add(Properties.Settings.Default.AdditionalSharedLibraryPaths[Counter]);
                }
            }

            if (Properties.Settings.Default.AdditionalB4aLibraryPaths != null)
            {
                // Additional Library paths
                for (Counter = 0; Counter < Properties.Settings.Default.AdditionalB4aLibraryPaths.Count; Counter++)
                {
                    lstPathsB4a.Items.Add(Properties.Settings.Default.AdditionalB4aLibraryPaths[Counter]);
                }
            }

            if (Properties.Settings.Default.AdditionalB4iLibraryPaths != null)
            {
                // Additional Library paths
                for (Counter = 0; Counter < Properties.Settings.Default.AdditionalB4iLibraryPaths.Count; Counter++)
                {
                    lstPathsB4i.Items.Add(Properties.Settings.Default.AdditionalB4iLibraryPaths[Counter]);
                }
            }

            if (Properties.Settings.Default.AdditionalB4jLibraryPaths != null)
            {
                // Additional Library paths
                for (Counter = 0; Counter < Properties.Settings.Default.AdditionalB4jLibraryPaths.Count; Counter++)
                {
                    lstPathsB4j.Items.Add(Properties.Settings.Default.AdditionalB4jLibraryPaths[Counter]);
                }
            }

            if (Properties.Settings.Default.AdditionalB4rLibraryPaths != null)
            {
                // Additional Library paths
                for (Counter = 0; Counter < Properties.Settings.Default.AdditionalB4rLibraryPaths.Count; Counter++)
                {
                    lstPathsB4r.Items.Add(Properties.Settings.Default.AdditionalB4rLibraryPaths[Counter]);
                }
            }
        }

        private void linkLabelBuyMeABeer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDonate DonateForm = new frmDonate();

            DonateForm.Show();

            //OpenSite("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=windows_mcp%40hotmail%2ecom&lc=AU&item_name=B4a%20Object%20Browser&no_note=0&currency_code=AUD&bn=PP%2dDonationsBF%3abtn_donateCC_LG%2egif%3aNonHostedGuest");
        }

        #region Shared

        private void btnAddShared_Click(object sender, EventArgs e)
        {
            lstPathsShared.Items.Add(txtLibraryPathShared.Text.Trim());
            txtLibraryPathShared.Text = "";
            ChangeInOptions = true;
        }
        
        private void btnBrowseShared_Click(object sender, EventArgs e)
        {
            ShowSharedOpenFolderDialog();
        }

        private void btnDeleteShared_Click(object sender, EventArgs e)
        {
            txtLibraryPathShared.Text = lstPathsShared.SelectedItem.ToString();
            lstPathsShared.Items.RemoveAt(lstPathsShared.SelectedIndex);
            ChangeInOptions = true;
        }

        private void txtHelpURLShared_Enter(object sender, EventArgs e)
        {
            txtHelpURLShared.SelectAll();
        }

        private void txtLibraryPathShared_TextChanged(object sender, EventArgs e)
        {
            btnAddShared.Enabled = txtLibraryPathShared.Text.Trim().Length > 0;
        }

        private void lstPathsShared_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPathsShared.SelectedItem != null)
            {
                btnDeleteShared.Enabled = lstPathsShared.SelectedItem.ToString().Trim().Length > 0;
            }
        }

        #endregion

        #region B4a

        private void btnAddB4a_Click(object sender, EventArgs e)
        {
            lstPathsB4a.Items.Add(txtLibraryPathB4a.Text.Trim());
            txtLibraryPathB4a.Text = "";
            ChangeInOptions = true;
        }

        private void btnBrowseB4a_Click(object sender, EventArgs e)
        {
            ShowB4aOpenFolderDialog();
        }

        private void btnDeleteB4a_Click(object sender, EventArgs e)
        {
            if (lstPathsB4a.SelectedItem != null)
            {
                txtLibraryPathB4a.Text = lstPathsB4a.SelectedItem.ToString();
                lstPathsB4a.Items.RemoveAt(lstPathsB4a.SelectedIndex);
                ChangeInOptions = true;
            }
        }

        private void txtHelpURLB4a_Enter(object sender, EventArgs e)
        {
            txtHelpURLB4a.SelectAll();
        }

        private void txtLibraryPathB4a_TextChanged(object sender, EventArgs e)
        {
            btnAddB4a.Enabled = txtLibraryPathB4a.Text.Trim().Length > 0;
        }

        private void lstPathsB4a_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPathsB4a.SelectedItem != null)
                btnDeleteB4a.Enabled = lstPathsB4a.SelectedItem.ToString().Trim().Length > 0;
        }

        #endregion

        #region B4i

        private void btnAddB4i_Click(object sender, EventArgs e)
        {
            lstPathsB4i.Items.Add(txtLibraryPathB4i.Text.Trim());
            txtLibraryPathB4i.Text = "";
            ChangeInOptions = true;
        }

        private void btnBrowseB4i_Click(object sender, EventArgs e)
        {
            ShowB4iOpenFolderDialog();
        }

        private void btnDeleteB4i_Click(object sender, EventArgs e)
        {
            txtLibraryPathB4i.Text = lstPathsB4i.SelectedItem.ToString();
            lstPathsB4i.Items.RemoveAt(lstPathsB4i.SelectedIndex);
            ChangeInOptions = true;
        }

        private void txtHelpURLB4i_Enter(object sender, EventArgs e)
        {
            txtHelpURLB4i.SelectAll();
        }

        private void txtLibraryPathB4i_TextChanged(object sender, EventArgs e)
        {
            btnAddB4i.Enabled = txtLibraryPathB4i.Text.Trim().Length > 0;
        }

        private void lstPathsB4i_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPathsB4i.SelectedItem != null)
            {
                btnDeleteB4i.Enabled = lstPathsB4i.SelectedItem.ToString().Trim().Length > 0;
            }
        }

        #endregion

        #region B4j

        private void btnAddB4j_Click(object sender, EventArgs e)
        {
            lstPathsB4j.Items.Add(txtLibraryPathB4j.Text.Trim());
            txtLibraryPathB4j.Text = "";
            ChangeInOptions = true;
        }

        private void btnBrowseB4j_Click(object sender, EventArgs e)
        {
            ShowB4jOpenFolderDialog();
        }

        private void btnDeleteB4j_Click(object sender, EventArgs e)
        {
            txtLibraryPathB4j.Text = lstPathsB4j.SelectedItem.ToString();
            lstPathsB4j.Items.RemoveAt(lstPathsB4j.SelectedIndex);
            ChangeInOptions = true;
        }

        private void txtHelpURLB4j_Enter(object sender, EventArgs e)
        {
            txtHelpURLB4j.SelectAll();
        }

        private void txtLibraryPathB4j_TextChanged(object sender, EventArgs e)
        {
            btnAddB4j.Enabled = txtLibraryPathB4j.Text.Trim().Length > 0;
        }

        private void lstPathsB4j_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPathsB4j.SelectedItem != null)
                btnDeleteB4j.Enabled = lstPathsB4j.SelectedItem.ToString().Trim().Length > 0;
        }

        #endregion

        #region B4r

        private void btnAddB4r_Click(object sender, EventArgs e)
        {
            lstPathsB4r.Items.Add(txtLibraryPathB4r.Text.Trim());
            txtLibraryPathB4r.Text = "";
            ChangeInOptions = true;
        }

        private void btnBrowseB4r_Click(object sender, EventArgs e)
        {
            ShowB4rOpenFolderDialog();
        }

        private void btnDeleteB4r_Click(object sender, EventArgs e)
        {
            txtLibraryPathB4r.Text = lstPathsB4r.SelectedItem.ToString();
            lstPathsB4r.Items.RemoveAt(lstPathsB4r.SelectedIndex);
            ChangeInOptions = true;
        }

        private void txtHelpURLB4r_Enter(object sender, EventArgs e)
        {
            txtHelpURLB4r.SelectAll();
        }

        private void txtLibraryPathB4r_TextChanged(object sender, EventArgs e)
        {
            btnAddB4r.Enabled = txtLibraryPathB4r.Text.Trim().Length > 0;
        }

        private void lstPathsB4r_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPathsB4r.SelectedItem != null)
            {
                btnDeleteB4r.Enabled = lstPathsB4r.SelectedItem.ToString().Trim().Length > 0;
            }
        }

        #endregion

        #endregion

        #region Private Methods

        private void DoCultureCheckNo()
        {
            if (this.RightToLeft != System.Windows.Forms.RightToLeft.No)
            {
                DoRestart();
            }
        }

        private void DoCultureCheckYes()
        {
            if (this.RightToLeft != System.Windows.Forms.RightToLeft.Yes)
            {
                DoRestart();
            }
        }

        private void DoRestart()
        {
            MessageBox.Show(_ResourceManager.GetString("ChangeSettingRestart"));

            Properties.Settings.Default.Language = cmbLanguage.Text;
            Properties.Settings.Default.Save();

            // wait a little to let the setting save
            System.Threading.Thread.Sleep(1000);

            Process.Start(Application.ExecutablePath);
            Environment.Exit(0);
        }

        private void ExportSettings()
        {
            try
            {
                FolderBrowserDialog Dialog = new FolderBrowserDialog();

                Dialog.RootFolder = Environment.SpecialFolder.MyDocuments; // = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                Dialog.ShowNewFolderButton = true;
                Dialog.Description = _ResourceManager.GetString("PleaseChooseAFolder");

                DialogResult Result = Dialog.ShowDialog();

                if (Result != System.Windows.Forms.DialogResult.Cancel)
                {
                    SettingsIO.Export(System.IO.Path.Combine(Dialog.SelectedPath, "ExportedSettings.xml"));
                }
            }
            catch
            {
                MessageBox.Show(_ResourceManager.GetString("CouldNotExportSettings"), _ResourceManager.GetString("Error"));
            }
        }

        private void ImportSettings()
        {
            OpenFileDialog Dialog = new OpenFileDialog();

            Dialog.Filter = "XML files (*.xml)|*.xml";
            Dialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            Dialog.AutoUpgradeEnabled = true;
            Dialog.CheckFileExists = true;
            Dialog.DefaultExt = ".xml";
            Dialog.Multiselect = false;
            Dialog.Title = _ResourceManager.GetString("PleaseSelectFileToImport");

            DialogResult Result = Dialog.ShowDialog();

            if (Result != System.Windows.Forms.DialogResult.Cancel)
            {
                SettingsIO.Import(Dialog.SafeFileName);
            }
        }

        private void OpenSite(string URL)
        {
            ProcessStartInfo ProcessInfo = new ProcessStartInfo();

            ProcessInfo.FileName = URL;
            ProcessInfo.UseShellExecute = true;

            System.Diagnostics.Process.Start(ProcessInfo);
        }

        private void UpdateUIControls()
        {
            string culture = "en-US";

            switch (Globals.PCLanguageSetting)
            {
                case "English":
                    culture = "en-US";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "Afrikaans":
                    culture = "af-ZA";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "العربية":
                    culture = "ar-SA";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    break;
                case "български":
                    culture = "bg-BG";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "Catalan":
                    culture = "ca-ES";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "hrvatski":
                    culture = "hr-BA";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "中文（简体":
                    culture = "zh-CN";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "Croatian":
                    culture = "hr-HR";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "Deutsch":
                    culture = "de-DE";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "español":
                    culture = "es-ES";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "français":
                    culture = "fr-FR";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "ελληνικός":
                    culture = "el-GR";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "עברית":
                    culture = "he-IL";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    break;
                case "Bahasa Indonesia":
                    culture = "id-ID";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "italiano":
                    culture = "it-IT";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "日本語":
                    culture = "ja-JP";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "Nederlands":
                    culture = "nl-NL";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "norsk":
                    culture = "nn-NO";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "polski":
                    culture = "pl-PL";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "português":
                    culture = "pt-PT";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "român":
                    culture = "ro-RO";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "русский":
                    culture = "ru-RU";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "svenska":
                    culture = "sv-SE";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "ภาษาไทย":
                    culture = "th-TH";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "Український":
                    culture = "uk-UA";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "Việt":
                    culture = "vi-VN";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "فارسی":
                    culture = "fa-IR";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    break;
                case "České":
                    culture = "cs-CZ";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "Dansk":
                    culture = "da-DK";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "Filipino":
                    culture = "fil-PH";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
            }

            // This is used for the language of the user interface
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
            //
            // http://msdn.microsoft.com/en-us/goglobal/bb896001.aspx
            //
            // This is used with formatting and sort options (e.g. number and date formats)
            // e.g. a float value 2.352 will be 2,3.52 if CurrentCulture is set to de-DE
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);

            try
            {
                if (_ResourceManager != null)
                {
                    this.Text = _ResourceManager.GetString("Options");

                    // Shared
                    grpHelpShared.Text = _ResourceManager.GetString("Help");
                    lblHelpURLShared.Text = _ResourceManager.GetString("URL");
                    grpLibraryPathsShared.Text = _ResourceManager.GetString("LibraryPaths");
                    btnAddShared.Text = _ResourceManager.GetString("Add");
                    btnDeleteShared.Text = _ResourceManager.GetString("Remove");

                    // B4a
                    grpHelpB4a.Text = _ResourceManager.GetString("Help");
                    lblHelpURLB4a.Text = _ResourceManager.GetString("URL");
                    grpLibraryPathsB4a.Text = _ResourceManager.GetString("LibraryPaths");
                    btnAddB4a.Text = _ResourceManager.GetString("Add");
                    btnDeleteB4a.Text = _ResourceManager.GetString("Remove");

                    // B4i
                    grpHelpB4i.Text = _ResourceManager.GetString("Help");
                    lblHelpURLB4i.Text = _ResourceManager.GetString("URL");
                    grpLibraryPathsB4i.Text = _ResourceManager.GetString("LibraryPaths");
                    btnAddB4i.Text = _ResourceManager.GetString("Add");
                    btnDeleteB4i.Text = _ResourceManager.GetString("Remove");

                    //B4j
                    grpHelpB4j.Text = _ResourceManager.GetString("Help");
                    lblHelpURLB4j.Text = _ResourceManager.GetString("URL");
                    grpLibraryPathsB4j.Text = _ResourceManager.GetString("LibraryPaths");
                    btnAddB4j.Text = _ResourceManager.GetString("Add");
                    btnDeleteB4j.Text = _ResourceManager.GetString("Remove");

                    //B4r
                    grpHelpB4r.Text = _ResourceManager.GetString("Help");
                    lblHelpURLB4r.Text = _ResourceManager.GetString("URL");
                    grpLibraryPathsB4r.Text = _ResourceManager.GetString("LibraryPaths");
                    btnAddB4r.Text = _ResourceManager.GetString("Add");
                    btnDeleteB4r.Text = _ResourceManager.GetString("Remove");

                    btnExport.Text = _ResourceManager.GetString("Export");
                    btnImport.Text = _ResourceManager.GetString("Import");
                    linkLabelBuyMeABeer.Text = _ResourceManager.GetString("BuymeaBeer");
                    btnOK.Text = _ResourceManager.GetString("OK");
                    btnCancel.Text = _ResourceManager.GetString("Cancel");

                    lblGUILanguage.Text = _ResourceManager.GetString("GUILanguage");

                    btnCredits.Text = _ResourceManager.GetString("Credits");

                    grpSearchHistory.Text = _ResourceManager.GetString("SearchHistory");
                    btnClearSearchHistory.Text = _ResourceManager.GetString("Clear");

                    cmbLanguage.Items.Clear();

                    cmbLanguage.Items.Add("English");
                    cmbLanguage.Items.Add("Afrikaans");
                    cmbLanguage.Items.Add("العربية");    // Arabic
                    cmbLanguage.Items.Add("български");   // Bulgarian
                    cmbLanguage.Items.Add("Catalan");
                    cmbLanguage.Items.Add("中文（简体");   // Chinese
                    cmbLanguage.Items.Add("hrvatski");    // Croatian
                    cmbLanguage.Items.Add("České");       // Czech
                    cmbLanguage.Items.Add("Dansk");       // Danish
                    cmbLanguage.Items.Add("Deutsch");
                    cmbLanguage.Items.Add("español");
                    cmbLanguage.Items.Add("français");
                    cmbLanguage.Items.Add("فارسی");      // Persian
                    cmbLanguage.Items.Add("ελληνικός");   // Greek
                    cmbLanguage.Items.Add("עברית");
                    cmbLanguage.Items.Add("Bahasa Indonesia");
                    cmbLanguage.Items.Add("italiano");
                    cmbLanguage.Items.Add("日本語");       // Japanese
                    cmbLanguage.Items.Add("Nederlands");
                    cmbLanguage.Items.Add("norsk");
                    //cmbLanguage.Items.Add("Filipino");
                    cmbLanguage.Items.Add("polski");
                    cmbLanguage.Items.Add("português");
                    cmbLanguage.Items.Add("român");
                    cmbLanguage.Items.Add("русский");     // Russian
                    cmbLanguage.Items.Add("svenska");
                    cmbLanguage.Items.Add("ภาษาไทย");      // Thai
                    cmbLanguage.Items.Add("Український"); // Ukranian
                    cmbLanguage.Items.Add("Việt");        // Vietnamese 

                    CultureInfo currentUserCulture = null;

                    currentUserCulture = Thread.CurrentThread.CurrentUICulture;

                    //                  http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.twoletterisolanguagename(v=vs.110).aspx
                    //                  http://msdn.microsoft.com/en-us/library/ee825488(v=cs.20).aspx
                    // Language codes:  http://mail.lingoes.net/en/translator/langcode.htm

                    switch (currentUserCulture.TwoLetterISOLanguageName)
                    {
                        case "en":
                            culture = "English";
                            break;
                        case "af":
                            culture = "Afrikaans";
                            break;
                        case "ar":
                            culture = "العربية";
                            break;
                        case "bg":
                            culture = "български";
                            break;
                        case "ca":
                            culture = "Catalan";
                            break;
                        case "hr":
                            culture = "hrvatski";
                            break;
                        case "zh":
                            culture = "中文（简体";
                            break;
                        case "de":
                            culture = "Deutsch";
                            break;
                        case "es":
                            culture = "español";
                            break;
                        case "fa":
                            culture = "فارسی";
                            break;
                        case "fr":
                            culture = "français";
                            break;
                        case "el":
                            culture = "ελληνικός";
                            break;
                        case "he":
                            culture = "עברית";
                            break;
                        case "id":
                            culture = "Bahasa Indonesia";
                            break;
                        case "it":
                            culture = "italiano";
                            break;
                        case "ja":
                            culture = "日本語";
                            break;
                        case "nl":
                            culture = "Nederlands";
                            break;
                        case "nn":
                            culture = "norsk";
                            break;
                        case "pl":
                            culture = "polski";
                            break;
                        case "pt":
                            culture = "português";
                            break;
                        case "ro":
                            culture = "român";
                            break;
                        case "ru":
                            culture = "русский";
                            break;
                        case "sv":
                            culture = "svenska";
                            break;
                        case "th":
                            culture = "ภาษาไทย";
                            break;
                        case "uk":
                            culture = "Український";
                            break;
                        case "vi":
                            culture = "Việt";
                            break;
                        case "cs":
                            culture = "České";
                            break;
                        case "da":
                            culture = "Dansk";
                            break;
                        case "fil":
                            culture = "Filipino";
                            break;
                    }

                    _UpdatingGUI = true;

                    cmbLanguage.SelectedItem = culture;

                    _UpdatingGUI = false;

                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ShowSharedOpenFolderDialog()
        {
            FolderBrowserDialog Folder = new FolderBrowserDialog();

            Folder.SelectedPath = _LastSharedSelectedDirectory;
            Folder.ShowNewFolderButton = false;
            DialogResult Result = Folder.ShowDialog();

            if (Result != System.Windows.Forms.DialogResult.Cancel)
            {
                txtLibraryPathShared.Text = Folder.SelectedPath;
                _LastSharedSelectedDirectory = Folder.SelectedPath;  // Remember last selected path
            }
        }

        private void ShowB4aOpenFolderDialog()
        {
            FolderBrowserDialog Folder = new FolderBrowserDialog();

            Folder.SelectedPath = _LastB4aSelectedDirectory;
            Folder.ShowNewFolderButton = false;
            DialogResult Result = Folder.ShowDialog();

            if (Result != System.Windows.Forms.DialogResult.Cancel)
            {
                txtLibraryPathB4a.Text = Folder.SelectedPath;
                _LastB4aSelectedDirectory = Folder.SelectedPath;  // Remember last selected path
            }
        }

        private void ShowB4iOpenFolderDialog()
        {
            FolderBrowserDialog Folder = new FolderBrowserDialog();

            Folder.SelectedPath = _LastB4iSelectedDirectory;
            Folder.ShowNewFolderButton = false;
            DialogResult Result = Folder.ShowDialog();

            if (Result != System.Windows.Forms.DialogResult.Cancel)
            {
                txtLibraryPathB4i.Text = Folder.SelectedPath;
                _LastB4iSelectedDirectory = Folder.SelectedPath;  // Remember last selected path
            }
        }

        private void ShowB4jOpenFolderDialog()
        {
            FolderBrowserDialog Folder = new FolderBrowserDialog();

            Folder.SelectedPath = _LastB4jSelectedDirectory;
            Folder.ShowNewFolderButton = false;
            DialogResult Result = Folder.ShowDialog();

            if (Result != System.Windows.Forms.DialogResult.Cancel)
            {
                txtLibraryPathB4j.Text = Folder.SelectedPath;
                _LastB4jSelectedDirectory = Folder.SelectedPath;  // Remember last selected path
            }
        }

        private void ShowB4rOpenFolderDialog()
        {
            FolderBrowserDialog Folder = new FolderBrowserDialog();

            Folder.SelectedPath = _LastB4rSelectedDirectory;
            Folder.ShowNewFolderButton = false;
            DialogResult Result = Folder.ShowDialog();

            if (Result != System.Windows.Forms.DialogResult.Cancel)
            {
                txtLibraryPathB4r.Text = Folder.SelectedPath;
                _LastB4rSelectedDirectory = Folder.SelectedPath;  // Remember last selected path
            }
        }


        #endregion

        #region Public Methods

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

        
    }
}
