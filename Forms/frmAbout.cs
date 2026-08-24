using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Resources;
using System.Threading;

namespace Browser
{
    partial class frmAbout : Form
    {
        frmMain _Parent;
        ResourceManager _ResourceManager = null;
        
        public frmAbout(frmMain Parent)
        {
            InitializeComponent();

            // Init _ResourceManager
            _ResourceManager = new ResourceManager("Browser.Strings", Assembly.GetExecutingAssembly());
            // Init UICulture to CurrentCulture
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            // Init Controls
            UpdateUIControls();

            _Parent = Parent;
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void btnLibraries_Click(object sender, EventArgs e)
        {
            frmLibraries LibrariesForm = new frmLibraries(_Parent);

            LibrariesForm.Show();
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
                case "中文（简体":
                    culture = "zh-CN";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "hrvatski":
                    culture = "hr-BA";
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
                    this.Text = _ResourceManager.GetString("About") + " " + AssemblyTitle;
                    //this.Text = "About" + " " + AssemblyTitle;
                    this.labelProductName.Text = AssemblyProduct;
                    this.labelVersion.Text = _ResourceManager.GetString("Version") + " " + AssemblyVersion;
                    //this.labelVersion.Text = "Version" + " " + AssemblyVersion;
                    this.labelCopyright.Text = AssemblyCopyright;
                    this.labelCompanyName.Text = AssemblyCompany;
                    this.textBoxDescription.Text = AssemblyDescription;

                    this.okButton.Text = _ResourceManager.GetString("OK");
                    this.btnLibraries.Text = _ResourceManager.GetString("Libraries") + "...";
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            this.TopMost = Properties.Settings.Default.AlwaysOnTop;
        }
    }
}
