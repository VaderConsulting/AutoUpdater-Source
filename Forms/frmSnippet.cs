using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Browser
{
    public partial class frmSnippet : Form
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

        ResourceManager _ResourceManager = null;

        public string Snippet = "";
        public string SnippetName = "";
        public string ObjectName = "";
        public string SaveRoot = "";

        #endregion

        #region Properties

        #endregion

        #region Constructors and Destructor

        public frmSnippet()
        {
            InitializeComponent();

            // Init _ResourceManager
            _ResourceManager = new ResourceManager("Browser.Strings", Assembly.GetExecutingAssembly());
            // Init UICulture to CurrentCulture
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            // Init Controls
            UpdateUIControls();
        }

        #endregion

        #region Event Handlers

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSnippet_Shown(object sender, EventArgs e)
        {
            htmlSnippet.AddHTML(Snippet);
            textBoxSnippetLabel.Text = SnippetName;
            txtObject.Text = ObjectName;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string Filename = System.IO.Path.Combine(SaveRoot, textBoxSnippetLabel.Text) + ".xml";
            XmlDocument Document = new XmlDocument();

            XDocument XDoc = XDocument.Parse(htmlSnippet.GetHTML(true, false));

            // Create folder first
            System.IO.Directory.CreateDirectory(SaveRoot);

            XDoc.Save(Filename);

            this.Close();
        }

        private void textBoxSnippetLabel_TextChanged(object sender, EventArgs e)
        {
            bool ValidFilename = !(textBoxSnippetLabel.Text.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) > 0) && textBoxSnippetLabel.Text.Trim().Length > 0;

            if (ValidFilename)
            {
                btnOK.Enabled = true;
            }
            else
            {
                btnOK.Enabled = false;

                foreach (char s in System.IO.Path.GetInvalidFileNameChars())
                {
                    textBoxSnippetLabel.Text = textBoxSnippetLabel.Text.Replace(s, '_');
                }

                btnOK.Enabled = true;
            }
        }

        private void frmSnippet_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Private Methods

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
                    btnCancel.Text = _ResourceManager.GetString("Cancel");
                    btnOK.Text = _ResourceManager.GetString("OK");
                    this.Text = _ResourceManager.GetString("CodeSnippets");
                    lblObject.Text = _ResourceManager.GetString("Object");
                    lblLabel.Text = _ResourceManager.GetString("Label");
                    lblSnippetText.Text = _ResourceManager.GetString("SnippetText");
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
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
