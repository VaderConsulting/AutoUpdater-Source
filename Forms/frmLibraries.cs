using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace Browser
{
    public partial class frmLibraries : Form
    {
        frmMain _Parent = null;
        ResourceManager _ResourceManager = null;
        
        public frmLibraries(frmMain Parent)
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

        private void frmLibraries_Load(object sender, EventArgs e)
        {
            ListViewItem ListItem = null;

            this.TopMost = Properties.Settings.Default.AlwaysOnTop;
            
            foreach (Library SelectedLibrary in _Parent._Libraries)
            {
                ListItem = new ListViewItem(SelectedLibrary.Name.InnerText);

                ListItem.SubItems.Add(SelectedLibrary.Author.InnerText);
                ListItem.SubItems.Add(SelectedLibrary.Version.InnerText);

                lvwLibraries.Items.Add(ListItem);

                //foreach (Class SelectedClass in SelectedLibrary.Classes)
                //{
                //    //ListViewItem.ListViewSubItem ShortName = new ListViewItem.ListViewSubItem();
                //    //ListViewItem.ListViewSubItem Name = new ListViewItem.ListViewSubItem();
                //    //ListViewItem.ListViewSubItem Version = new ListViewItem.ListViewSubItem();

                //    //ShortName.Text = SelectedClass.ShortName;
                //    //Name.Text = SelectedClass.ShortName;
                //    //Version.Text = SelectedClass.ShortName;

                //    ListItem = new ListViewItem(SelectedLibrary.Name);

                //    ListItem.SubItems.Add(SelectedLibrary.Author);
                //    ListItem.SubItems.Add(SelectedClass.Name);
                //    ListItem.SubItems.Add(SelectedClass.ShortName);
                //    ListItem.SubItems.Add(SelectedLibrary.Version);

                //    lvwLibraries.Items.Add(ListItem);
                //}

                
            }

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
                    this.Text = _ResourceManager.GetString("Libraries");
                    lvwLibraries.Columns[0].Text = _ResourceManager.GetString("Library");
                    lvwLibraries.Columns[1].Text = _ResourceManager.GetString("Author");
                    //lvwLibraries.Columns[2].Text = _ResourceManager.GetString("ClassName");
                    //lvwLibraries.Columns[3].Text = _ResourceManager.GetString("ClassShortName");
                    lvwLibraries.Columns[2].Text = _ResourceManager.GetString("Version");
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
