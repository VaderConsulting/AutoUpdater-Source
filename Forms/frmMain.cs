using AutoUpdaterDotNET;

using HtmlRichText;

using mshtml;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Browser
{
    // TODO:::   Whilst searching, the search must include and go down to the comments

    public partial class frmMain : Form
    {
        #region Fields

        public List<Class> Classes = new List<Class>();
        private bool _EditMode = false;
        public List<Library> _Libraries = new List<Library>();
        private bool _LoadComplete = false;
        private string _MyDocuments = System.Environment.SpecialFolder.MyDocuments.ToString();

        //private int _PermissionsListHoverIndex = -1;
        private ResourceManager _ResourceManager = null;
        private string _SaveRoot = "";
        private bool _SearchMode = false;
        private Structs.Language _SelectedLanguage = Structs.Language.Android;
        private string _SelectedObjectName = "";
        private string _CurrentCultureName = "";

        private Color SelectedClassColor = Color.Black;

        #endregion

        #region Event Handlers

        #region Form

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DoExit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string B4aPath = "";
            string B4iPath = "";
            string B4jPath = "";
            string B4rPath = "";
            string B4aLibraryPath = "";
            string B4iLibraryPath = "";
            string B4jLibraryPath = "";
            string B4rLibraryPath = "";

            // Create snippet folder structure
            _MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _SaveRoot = System.IO.Path.Combine(_MyDocuments, "B4x_Snippets");

            if (!System.IO.Directory.Exists(_SaveRoot))
            {
                System.IO.Directory.CreateDirectory(_SaveRoot);
            }

            _SaveRoot = System.IO.Path.Combine(_MyDocuments + @"\B4x_Snippets", "B4a");
            if (!System.IO.Directory.Exists(_SaveRoot))
            {
                System.IO.Directory.CreateDirectory(_SaveRoot);
            }

            _SaveRoot = System.IO.Path.Combine(_MyDocuments + @"\B4x_Snippets", "B4i");
            if (!System.IO.Directory.Exists(_SaveRoot))
            {
                System.IO.Directory.CreateDirectory(_SaveRoot);
            }

            _SaveRoot = System.IO.Path.Combine(_MyDocuments + @"\B4x_Snippets", "B4j");
            if (!System.IO.Directory.Exists(_SaveRoot))
            {
                System.IO.Directory.CreateDirectory(_SaveRoot);
            }

            _SaveRoot = System.IO.Path.Combine(_MyDocuments + @"\B4r_Snippets", "B4r");
            if (!System.IO.Directory.Exists(_SaveRoot))
            {
                System.IO.Directory.CreateDirectory(_SaveRoot);
            }

            ////////////////////////////////////////////////////////////////////////////////////////

            AutoUpdate();

            LoadScreenLayout();

            this.Show();
            this.Refresh();

            // Determine application paths
            // b4a
            B4aPath = Globals.AssocQueryString(Globals.AssocStr.ASSOCSTR_EXECUTABLE, ".b4a");

            if (B4aPath.Length > 0)
            {
                toolStripButtonB4a.Visible = true;

                B4aPath = System.IO.Path.GetDirectoryName(B4aPath);
                B4aLibraryPath = System.IO.Path.Combine(B4aPath, "Libraries");
                if (!Properties.Settings.Default.AdditionalB4aLibraryPaths.Contains(B4aLibraryPath))
                {
                    // For some reason the default library path resolves to:
                    // C:\WINDOWS\system32\Libraries
                    // Don't allow this through
                    if (B4aLibraryPath.ToLower() != @"c:\windows\system32\libraries")
                    {
                        Properties.Settings.Default.AdditionalB4aLibraryPaths.Add(B4aLibraryPath);
                        Properties.Settings.Default.Save();
                    }
                }
            }
            else
            {
                toolStripButtonB4a.Visible = false;
            }

            // b4i
            B4iPath = Globals.AssocQueryString(Globals.AssocStr.ASSOCSTR_EXECUTABLE, ".b4i");

            if (B4iPath.Length > 0)
            {
                toolStripButtonB4i.Visible = true;

                B4iPath = System.IO.Path.GetDirectoryName(B4iPath);
                B4iLibraryPath = System.IO.Path.Combine(B4iPath, "Libraries");
                if (!Properties.Settings.Default.AdditionalB4iLibraryPaths.Contains(B4iLibraryPath))
                {
                    // For some reason the default library path resolves to:
                    // C:\WINDOWS\system32\Libraries
                    // Don't allow this through
                    if (B4iLibraryPath.ToLower() != @"c:\windows\system32\libraries")
                    {
                        Properties.Settings.Default.AdditionalB4iLibraryPaths.Add(B4iLibraryPath);
                        Properties.Settings.Default.Save();
                    }
                }
            }
            else
            {
                toolStripButtonB4i.Visible = false;
            }

            // b4j
            B4jPath = Globals.AssocQueryString(Globals.AssocStr.ASSOCSTR_EXECUTABLE, ".b4j");

            if (B4jPath.Length > 0)
            {
                toolStripButtonB4j.Visible = true;

                B4jPath = System.IO.Path.GetDirectoryName(B4jPath);
                B4jLibraryPath = System.IO.Path.Combine(B4jPath, "Libraries");
                if (!Properties.Settings.Default.AdditionalB4jLibraryPaths.Contains(B4jLibraryPath))
                {
                    // For some reason the default library path resolves to:
                    // C:\WINDOWS\system32\Libraries
                    // Don't allow this through
                    if (B4jLibraryPath.ToLower() != @"c:\windows\system32\libraries")
                    {
                        Properties.Settings.Default.AdditionalB4jLibraryPaths.Add(B4jLibraryPath);
                        Properties.Settings.Default.Save();
                    }
                }
            }
            else
            {
                toolStripButtonB4j.Visible = false;
            }

            // b4r
            B4rPath = Globals.AssocQueryString(Globals.AssocStr.ASSOCSTR_EXECUTABLE, ".b4r");

            if (B4rPath.Length > 0)
            {
                toolStripButtonB4r.Visible = true;

                B4rPath = System.IO.Path.GetDirectoryName(B4rPath);
                B4rLibraryPath = System.IO.Path.Combine(B4rPath, "Libraries");
                if (!Properties.Settings.Default.AdditionalB4rLibraryPaths.Contains(B4rLibraryPath))
                {
                    // For some reason the default library path resolves to:
                    // C:\WINDOWS\system32\Libraries
                    // Don't allow this through
                    if (B4rLibraryPath.ToLower() != @"c:\windows\system32\libraries")
                    {
                        Properties.Settings.Default.AdditionalB4rLibraryPaths.Add(B4rLibraryPath);
                        Properties.Settings.Default.Save();
                    }
                }
            }
            else
            {
                toolStripButtonB4r.Visible = false;
            }

            switch (Properties.Settings.Default.LastLanguage)
            {
                case 0:  // B4a
                    {
                        toolStripButtonB4a.Checked = true;
                        toolStripButtonB4i.Checked = false;
                        toolStripButtonB4j.Checked = false;
                        toolStripButtonB4r.Checked = false;
                        lvwPermissions.Enabled = true;
                        _SelectedLanguage = Structs.Language.Android;
                        LanguageAPI.ToolTipText = _ResourceManager.GetString("AndroidPackages");
                        B4xHelp.ToolTipText = _ResourceManager.GetString("B4aHelp");
                        _SaveRoot = System.IO.Path.Combine(_MyDocuments + @"\B4x_Snippets", "B4a");

                        if (Properties.Settings.Default.AdditionalB4aLibraryPaths != null)
                        {
                            if (Properties.Settings.Default.AdditionalB4aLibraryPaths.Count > 0)
                            {
                                LoadXMLFiles();
                            }
                        }
                        else
                        {
                            LoadExportedSettings();
                        }
                        break;
                    }
                case 1:  // B4i
                    {
                        toolStripButtonB4a.Checked = false;
                        toolStripButtonB4i.Checked = true;
                        toolStripButtonB4j.Checked = false;
                        toolStripButtonB4r.Checked = false;
                        lvwPermissions.Enabled = false;
                        _SelectedLanguage = Structs.Language.IOS;
                        LanguageAPI.ToolTipText = _ResourceManager.GetString("iosAPI");
                        B4xHelp.ToolTipText = _ResourceManager.GetString("B4iHelp");
                        _SaveRoot = System.IO.Path.Combine(_MyDocuments + @"\B4x_Snippets", "B4i");

                        if (Properties.Settings.Default.AdditionalB4iLibraryPaths != null)
                        {
                            if (Properties.Settings.Default.AdditionalB4iLibraryPaths.Count > 0)
                            {
                                LoadXMLFiles();
                            }
                        }
                        else
                        {
                            LoadExportedSettings();
                        }
                        break;
                    }
                case 2:  // B4j
                    {
                        toolStripButtonB4a.Checked = false;
                        toolStripButtonB4i.Checked = false;
                        toolStripButtonB4j.Checked = true;
                        toolStripButtonB4r.Checked = false;
                        lvwPermissions.Enabled = false;
                        _SelectedLanguage = Structs.Language.Java;
                        LanguageAPI.ToolTipText = _ResourceManager.GetString("JavaAPI");
                        B4xHelp.ToolTipText = _ResourceManager.GetString("B4jHelp");
                        _SaveRoot = System.IO.Path.Combine(_MyDocuments + @"\B4x_Snippets", "B4j");

                        if (Properties.Settings.Default.AdditionalB4jLibraryPaths != null)
                        {
                            if (Properties.Settings.Default.AdditionalB4jLibraryPaths.Count > 0)
                            {
                                LoadXMLFiles();
                            }
                        }
                        else
                        {
                            LoadExportedSettings();
                        }
                        break;
                    }
                case 3:  // B4r
                    {
                        toolStripButtonB4a.Checked = false;
                        toolStripButtonB4i.Checked = false;
                        toolStripButtonB4j.Checked = false;
                        toolStripButtonB4r.Checked = true;
                        lvwPermissions.Enabled = false;
                        _SelectedLanguage = Structs.Language.Arduino;
                        LanguageAPI.ToolTipText = _ResourceManager.GetString("Arduino");
                        B4xHelp.ToolTipText = _ResourceManager.GetString("B4RHelp");
                        _SaveRoot = System.IO.Path.Combine(_MyDocuments + @"\B4x_Snippets", "B4r");

                        if (Properties.Settings.Default.AdditionalB4rLibraryPaths != null)
                        {
                            if (Properties.Settings.Default.AdditionalB4rLibraryPaths.Count > 0)
                            {
                                LoadXMLFiles();
                            }
                        }
                        else
                        {
                            LoadExportedSettings();
                        }
                        break;
                    }
            }

            if (Properties.Settings.Default.InstallDate.Date <= new DateTime(2013, 12, 15))
            {
                Properties.Settings.Default.InstallDate = DateTime.Now;
                Properties.Settings.Default.Save();
            }

            // This is necessary due to the different culture types (Right-To-Left vs. Left-To-Right)
            ////////
            DateTime ComparisonDate;
            CultureInfo CurrentCulture = CultureInfo.CurrentCulture;
            DateTimeStyles styles = DateTimeStyles.None;
            DateTime.TryParse("01/01/1900", CurrentCulture, styles, out ComparisonDate);
            ////////


            if (Properties.Settings.Default.DonateDate == ComparisonDate)
            {
                int DaysSinceInstall = DateTime.Now.Subtract(Properties.Settings.Default.InstallDate).Days;

                Console.WriteLine("Days since install:  " + DaysSinceInstall);

                if (DaysSinceInstall > 30)
                {
                    frmDonate DonateForm = new frmDonate();

                    DonateForm.Show();
                }
            }

            //lvwDetails.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            //lvwDetails.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.None);

            _LoadComplete = true;
        }

        #endregion

        #region Menu and Context Menu

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAbout();
        }

        private void classDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowClassDetails(classDetailsToolStripMenuItem.Checked);
        }

        private void CopyDetails_Click(object sender, EventArgs e)
        {
            Status.Text = _ResourceManager.GetString("TextCopied");
        }

        private void copyFullPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Fullname = "";

            if (tvwMethodsPropertiesFields.Nodes.Count > 0 && tvwMethodsPropertiesFields.SelectedNode != null)
            {
                TreeNode Node = tvwMethodsPropertiesFields.SelectedNode;

                Fullname = SelectedNodeFullname(Node);

                Clipboard.SetText(Fullname);

                Status.Text = _ResourceManager.GetString("TextCopied");
            }
        }

        private void copyNameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (tvwMethodsPropertiesFields.Nodes.Count > 0 && tvwMethodsPropertiesFields.SelectedNode != null)
            {
                Clipboard.SetText(tvwMethodsPropertiesFields.SelectedNode.Text);

                Status.Text = _ResourceManager.GetString("TextCopied");
            }
        }

        private void copyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvwClasses.Nodes.Count > 0 && tvwClasses.SelectedNode != null)
            {
                Clipboard.SetText(tvwClasses.SelectedNode.Text);

                Status.Text = _ResourceManager.GetString("TextCopied");
            }
        }

        private void copyRTFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Status.Text = _ResourceManager.GetString("RTFcopied");
        }

        private void copyRTFToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Clipboard.SetData(System.Windows.Forms.DataFormats.Rtf, rtbClassComment.Rtf.Replace("\n", "\r\n"));

            Status.Text = _ResourceManager.GetString("RTFCopied");
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string CopyText = "";

            if (tvwMethodsPropertiesFields.Nodes.Count > 0)
            {
                foreach (TreeNode node in tvwMethodsPropertiesFields.Nodes)
                {
                    Console.WriteLine(node.Text);
                    CopyText += node.Text + Environment.NewLine;
                }

                Clipboard.SetText(CopyText.Trim());

                Status.Text = _ResourceManager.GetString("MethodsPropertiesFieldsCopied");
            }
        }

        private void DesignerPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowDesignerProperties = DesignerPropertiesToolStripMenuItem.Checked;

            Properties.Settings.Default.Save();

            SelectLibraryOrClassTreeNode();

            UpdateLabel();
        }

        private void DocumentAll_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show(_ResourceManager.GetString("AreYouSureLongTimeOperation"), _ResourceManager.GetString("PleaseConfirm"), MessageBoxButtons.YesNo);

            if (Result == System.Windows.Forms.DialogResult.Yes)
            {

                Properties.Settings.Default.LoadXMLOnDemand = false;
                LoadXMLFiles();

                Class SelectedClass = new Class();

                foreach (TreeNode ParentNode in tvwClasses.Nodes)
                {
                    if (ParentNode.Level == 0)
                    {
                        tvwClasses.SelectedNode = ParentNode;
                        foreach (TreeNode Node in tvwClasses.SelectedNode.Nodes)
                        {
                            SelectedClass = (Class)Node.Tag;

                            DocumentClass(SelectedClass, rtbDocumentation, true);
                        }
                    }
                }

                Clipboard.SetData(System.Windows.Forms.DataFormats.Rtf, rtbDocumentation.Rtf.Replace("\n", "\r\n"));

                Status.Text = _ResourceManager.GetString("AllDocumentationCopied");
            }
        }

        private void DocumentSelectedClass_Click(object sender, EventArgs e)
        {
            Class SelectedClass = new Class();

            rtbDocumentation.Clear();

            switch (tvwClasses.SelectedNode.Level)
            {
                case 0:  // Library/File
                    foreach (TreeNode Node in tvwClasses.SelectedNode.Nodes)
                    {
                        SelectedClass = (Class)Node.Tag;

                        DocumentClass(SelectedClass, rtbDocumentation, true);
                    }

                    break;
                case 1:  // Class
                    SelectedClass = (Class)tvwClasses.SelectedNode.Tag;

                    DocumentClass(SelectedClass, rtbDocumentation, true);
                    break;
            }

            Clipboard.SetData(System.Windows.Forms.DataFormats.Rtf, rtbDocumentation.Rtf.Replace("\n", "\r\n"));

            Status.Text = _ResourceManager.GetString("ClassDocumentationCopied");
        }

        private void DocumentSelectedLibrary_Click(object sender, EventArgs e)
        {
            rtbDocumentation.Clear();

            switch (tvwClasses.SelectedNode.Level)
            {
                case 0:  // Library
                    foreach (TreeNode Node in tvwClasses.SelectedNode.Nodes)
                    {
                        DocumentClass((Class)Node.Tag, rtbDocumentation, true);
                    }
                    break;
                case 1:  // Class
                    DocumentClass((Class)tvwClasses.SelectedNode.Tag, rtbDocumentation, true);
                    break;
            }

            Clipboard.SetData(System.Windows.Forms.DataFormats.Rtf, rtbDocumentation.Rtf.Replace("\n", "\r\n"));

            Status.Text = _ResourceManager.GetString("LibraryDocumentationCopied");
        }

        private void editXMLFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Path = "";

            if (tvwClasses.Nodes.Count > 0 && tvwClasses.SelectedNode != null)
            {
                TreeNode Node = tvwClasses.SelectedNode;

                // ========================================================


                //Console.WriteLine("NodeIndex: " + Node.ImageIndex);

                if (Node != null)
                {

                    switch (Node.ImageIndex)
                    {
                        case 0:  // Class
                        case 18:
                        case 19:
                            Class SelectedClass = (Class)Node.Tag;

                            Path = SelectedClass.Parent.FilePath;

                            break;
                        case 1:  // Field
                        case 20:
                            Field SelectedField = (Field)Node.Tag;

                            Path = SelectedField.Parent.Parent.FilePath;

                            break;
                        case 2:  // Method
                        case 21:
                        case 24:
                            Method SelectedMethod = (Method)Node.Tag;

                            Path = SelectedMethod.Parent.Parent.FilePath;

                            break;
                        case 3:  // Library
                            Library SelectedLibrary = (Library)Node.Tag;

                            Path = SelectedLibrary.FilePath;

                            break;
                        case 4:  // Property
                        case 23:
                            Property SelectedProperty = (Property)Node.Tag;

                            Path = SelectedProperty.Parent.Parent.FilePath;

                            break;
                        case 12:  // DesignerProperty
                            DesignerProperty SelectedDesignerProperty = (DesignerProperty)Node.Tag;

                            Path = SelectedDesignerProperty.Parent.Parent.FilePath;

                            break;
                    }
                }

                // ========================================================
            }

            if (Path != "")
            {
                OpenApplication(Path);
            }
        }

        private void enableEditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _EditMode = enableEditsToolStripMenuItem.Checked;
            editToolStripMenuItem2.Visible = enableEditsToolStripMenuItem.Checked;
            editToolStripMenuItem3.Visible = enableEditsToolStripMenuItem.Checked;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoExit();
        }

        private void FieldsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowFields = FieldsToolStripMenuItem.Checked;

            Properties.Settings.Default.Save();

            SelectLibraryOrClassTreeNode();

            UpdateLabel();
        }

        private void FontSize8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Font = new Font(this.Font.FontFamily, 8);

            Properties.Settings.Default.UIFontSize = 8;
            Properties.Settings.Default.Save();

            FontSize8ToolStripMenuItem.Checked = true;
            FontSize9ToolStripMenuItem.Checked = false;
            FontSize10ToolStripMenuItem.Checked = false;
            FontSize12ToolStripMenuItem.Checked = false;
            FontSize14ToolStripMenuItem.Checked = false;
            FontSize16ToolStripMenuItem.Checked = false;


            Refresh();
        }

        private void FontSize9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Font = new Font(this.Font.FontFamily, 9);

            Properties.Settings.Default.UIFontSize = 9;
            Properties.Settings.Default.Save();

            FontSize8ToolStripMenuItem.Checked = false;
            FontSize9ToolStripMenuItem.Checked = true;
            FontSize10ToolStripMenuItem.Checked = false;
            FontSize12ToolStripMenuItem.Checked = false;
            FontSize14ToolStripMenuItem.Checked = false;
            FontSize16ToolStripMenuItem.Checked = false;

            Refresh();
        }

        private void FontSize10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Font = new Font(this.Font.FontFamily, 10);

            Properties.Settings.Default.UIFontSize = 10;
            Properties.Settings.Default.Save();

            FontSize8ToolStripMenuItem.Checked = false;
            FontSize9ToolStripMenuItem.Checked = false;
            FontSize10ToolStripMenuItem.Checked = true;
            FontSize12ToolStripMenuItem.Checked = false;
            FontSize14ToolStripMenuItem.Checked = false;
            FontSize16ToolStripMenuItem.Checked = false;

            Refresh();
        }

        private void FontSize12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Font = new Font(this.Font.FontFamily, 12);

            Properties.Settings.Default.UIFontSize = 12;
            Properties.Settings.Default.Save();

            FontSize8ToolStripMenuItem.Checked = false;
            FontSize9ToolStripMenuItem.Checked = false;
            FontSize10ToolStripMenuItem.Checked = false;
            FontSize12ToolStripMenuItem.Checked = true;
            FontSize14ToolStripMenuItem.Checked = false;
            FontSize16ToolStripMenuItem.Checked = false;

            Refresh();
        }

        private void FontSize14ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Font = new Font(this.Font.FontFamily, 14);

            Properties.Settings.Default.UIFontSize = 14;
            Properties.Settings.Default.Save();

            FontSize8ToolStripMenuItem.Checked = false;
            FontSize9ToolStripMenuItem.Checked = false;
            FontSize10ToolStripMenuItem.Checked = false;
            FontSize12ToolStripMenuItem.Checked = false;
            FontSize14ToolStripMenuItem.Checked = true;
            FontSize16ToolStripMenuItem.Checked = false;

            Refresh();
        }

        private void FontSize16ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Font = new Font(this.Font.FontFamily, 16);

            Properties.Settings.Default.UIFontSize = 16;
            Properties.Settings.Default.Save();

            FontSize8ToolStripMenuItem.Checked = false;
            FontSize9ToolStripMenuItem.Checked = false;
            FontSize10ToolStripMenuItem.Checked = false;
            FontSize12ToolStripMenuItem.Checked = false;
            FontSize14ToolStripMenuItem.Checked = false;
            FontSize16ToolStripMenuItem.Checked = true;

            Refresh();
        }

        private void HideB4xObjectIfFirstParameterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.HideBAObjectIfFirstParameter = HideBAObjectIfFirstParameterToolStripMenuItem.Checked;

            Properties.Settings.Default.Save();

            SelectLibraryOrClassTreeNode();
        }

        private void LoadXMLOnDemandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.LoadXMLOnDemand = LoadXMLOnDemandToolStripMenuItem.Checked;

            Properties.Settings.Default.Save();

            if (_SearchMode)
            {
                DoSearch();
            }
            else
            {
                LoadXMLFiles();
            }
        }

        private void MethodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowMethods = MethodsToolStripMenuItem.Checked;

            Properties.Settings.Default.Save();

            SelectLibraryOrClassTreeNode();

            UpdateLabel();
        }

        private void OpenFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Path = "";

            if (tvwClasses.Nodes.Count > 0 && tvwClasses.SelectedNode != null)
            {
                TreeNode Node = tvwClasses.SelectedNode;

                // ========================================================


                //Console.WriteLine("NodeIndex: " + Node.ImageIndex);

                if (Node != null)
                {

                    switch (Node.ImageIndex)
                    {
                        case 0:  // Class
                        case 18:
                        case 19:
                            Class SelectedClass = (Class)Node.Tag;

                            Path = SelectedClass.Parent.FilePath;

                            break;
                        case 1:  // Field
                        case 20:
                            Field SelectedField = (Field)Node.Tag;

                            Path = SelectedField.Parent.Parent.FilePath;

                            break;
                        case 2:  // Method
                        case 21:
                        case 24:
                            Method SelectedMethod = (Method)Node.Tag;

                            Path = SelectedMethod.Parent.Parent.FilePath;

                            break;
                        case 3:  // Library
                            Library SelectedLibrary = (Library)Node.Tag;

                            Path = SelectedLibrary.FilePath;

                            break;
                        case 4:  // Property
                        case 23:
                            Property SelectedProperty = (Property)Node.Tag;

                            Path = SelectedProperty.Parent.Parent.FilePath;

                            break;
                        case 12:  // DesignerProperty
                            DesignerProperty SelectedDesignerProperty = (DesignerProperty)Node.Tag;

                            Path = SelectedDesignerProperty.Parent.Parent.FilePath;

                            break;
                    }
                }

                // ========================================================
            }

            if (Path != "")
            {
                // Path is actually the full path to the file.  We need the folder only
                OpenFolder(System.IO.Path.GetDirectoryName(Path));
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveScreenLayout();
            DoOptions();
        }

        private void PropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowProperties = PropertiesToolStripMenuItem.Checked;

            Properties.Settings.Default.Save();

            SelectLibraryOrClassTreeNode();

            UpdateLabel();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReloadSettings();
        }

        private void ShowClassGlobalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowClass_Global = ShowClassGlobalToolStripMenuItem.Checked;

            Properties.Settings.Default.Save();

            SelectLibraryOrClassTreeNode();
        }

        private void ShowDesignerCreateViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowDesignerCreateView = ShowDesignerCreateViewToolStripMenuItem.Checked;

            Properties.Settings.Default.Save();

            SelectLibraryOrClassTreeNode();
        }

        private void ShowEmptyParenthesesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowEmptyParentheses = ShowEmptyParenthesesToolStripMenuItem.Checked;

            Properties.Settings.Default.Save();

            SelectLibraryOrClassTreeNode();
        }

        private void ShowFullTypenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowFullTypeName = ShowFullTypenameToolStripMenuItem.Checked;

            Properties.Settings.Default.Save();

            SelectLibraryOrClassTreeNode();
        }

        private void ShowLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowLabels = ShowLabelsToolStripMenuItem.Checked;

            Properties.Settings.Default.Save();

            SetLabelVisibility();
        }

        private void ShowPropertyGetAndSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowPropertyGetAndSet = ShowPropertyGetAndSetToolStripMenuItem.Checked;

            Properties.Settings.Default.Save();

            SelectLibraryOrClassTreeNode();
        }

        private void ShowSearchResultsInClassAndLibraryTreeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowSearchResultsInLibraryClassTreeView = ShowSearchResultsInClassAndLibraryTreeViewToolStripMenuItem.Checked;

            Properties.Settings.Default.Save();

            SelectLibraryOrClassTreeNode();
        }

        private void ShowVoidInUsageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowVoidInUsage = ShowVoidInUsageToolStripMenuItem.Checked;

            Properties.Settings.Default.Save();

            SelectLibraryOrClassTreeNode();
        }


        #endregion

        #region Toolstrip

        private void AndroidPackages_Click(object sender, EventArgs e)
        {
            switch (_SelectedLanguage)
            {
                case Browser.Structs.Language.Android:
                    {
                        OpenSite("http://developer.android.com/reference/packages.html");
                        break;
                    }
                case Browser.Structs.Language.IOS:
                    {
                        OpenSite("https://developer.apple.com/library/ios/navigation/");
                        break;
                    }
                case Browser.Structs.Language.Java:
                    {
                        OpenSite("http://docs.oracle.com/javase/7/docs/api/");
                        break;
                    }
            }
        }

        private void B4xForum_Click(object sender, EventArgs e)
        {
            switch (_SelectedLanguage)
            {
                case Browser.Structs.Language.Android:
                    {
                        OpenSite("http://www.b4x.com/android/forum/");
                        break;
                    }
                case Browser.Structs.Language.IOS:
                    {
                        OpenSite("http://www.b4x.com/android/forum/");
                        break;
                    }
                case Browser.Structs.Language.Java:
                    {
                        OpenSite("http://www.b4x.com/android/forum/");
                        break;
                    }
            }
        }

        private void B4xHelp_Click(object sender, EventArgs e)
        {
            switch (_SelectedLanguage)
            {
                case Structs.Language.Android:
                    OpenSite(Properties.Settings.Default.B4aHelpURL);
                    break;
                case Structs.Language.IOS:
                    OpenSite(Properties.Settings.Default.B4iHelpURL);
                    break;
                case Structs.Language.Java:
                    OpenSite(Properties.Settings.Default.B4jHelpURL);
                    break;
            }

        }

        private void CheckForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoUpdate();
        }

        private void DonateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDonate DonateForm = new frmDonate();

            DonateForm.Show();
        }

        private void searchB4xSiteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (tvwMethodsPropertiesFields.Nodes.Count > 0 && tvwMethodsPropertiesFields.SelectedNode != null)
            {
                PerformSiteSearch(tvwMethodsPropertiesFields.SelectedNode.Text);
            }
        }

        private void searchB4xSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerformSiteSearch(tvwClasses.SelectedNode.Text);
        }

        private void SiteSearch_Click(object sender, EventArgs e)
        {
            string SearchTerm = "";
            DialogResult Result = InputBox("", _ResourceManager.GetString("EnterSearchTerm"), ref SearchTerm);

            if (Result == System.Windows.Forms.DialogResult.OK)
            {
                PerformSiteSearch(SearchTerm);
            }
        }

        private void StayOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = StayOnTopToolStripMenuItem.Checked;
            Properties.Settings.Default.AlwaysOnTop = StayOnTopToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void ToolstripAbout_Click(object sender, EventArgs e)
        {
            ShowAbout();
        }

        private void toolStripButtonB4a_Click(object sender, EventArgs e)
        {
            bool WasChecked = (toolStripButtonB4a.Checked == true);

            _SelectedLanguage = Structs.Language.Android;
            Properties.Settings.Default.LastLanguage = 0;

            _SaveRoot = System.IO.Path.Combine(_MyDocuments + @"\B4x_Snippets", "B4a");

            toolStripButtonB4a.Checked = true;
            toolStripButtonB4i.Checked = false;
            toolStripButtonB4j.Checked = false;
            toolStripButtonB4r.Checked = false;

            lvwPermissions.Enabled = true;
            LanguageAPI.ToolTipText = _ResourceManager.GetString("AndroidPackages");
            B4xHelp.ToolTipText = _ResourceManager.GetString("B4aHelp");

            if (!WasChecked) ReloadSettings();
        }

        private void toolStripButtonB4i_Click(object sender, EventArgs e)
        {
            bool WasChecked = (toolStripButtonB4i.Checked == true);

            _SelectedLanguage = Structs.Language.IOS;
            Properties.Settings.Default.LastLanguage = 1;

            _SaveRoot = System.IO.Path.Combine(_MyDocuments + @"\B4x_Snippets", "B4i");

            toolStripButtonB4a.Checked = false;
            toolStripButtonB4i.Checked = true;
            toolStripButtonB4j.Checked = false;
            toolStripButtonB4r.Checked = false;

            lvwPermissions.Enabled = false;
            LanguageAPI.ToolTipText = _ResourceManager.GetString("iosAPI");
            B4xHelp.ToolTipText = _ResourceManager.GetString("B4iHelp");

            if (!WasChecked) ReloadSettings();
        }

        private void toolStripButtonB4j_Click(object sender, EventArgs e)
        {
            bool WasChecked = (toolStripButtonB4j.Checked == true);

            _SelectedLanguage = Structs.Language.Java;
            Properties.Settings.Default.LastLanguage = 2;

            _SaveRoot = System.IO.Path.Combine(_MyDocuments + @"\B4x_Snippets", "B4j");

            toolStripButtonB4a.Checked = false;
            toolStripButtonB4i.Checked = false;
            toolStripButtonB4j.Checked = true;
            toolStripButtonB4r.Checked = false;

            lvwPermissions.Enabled = false;
            LanguageAPI.ToolTipText = _ResourceManager.GetString("JavaAPI");
            B4xHelp.ToolTipText = _ResourceManager.GetString("B4jHelp");

            if (!WasChecked) ReloadSettings();
        }

        private void toolStripButtonB4r_Click(object sender, EventArgs e)
        {
            bool WasChecked = (toolStripButtonB4r.Checked == true);

            _SelectedLanguage = Structs.Language.Arduino;
            Properties.Settings.Default.LastLanguage = 3;

            _SaveRoot = System.IO.Path.Combine(_MyDocuments + @"\B4x_Snippets", "B4r");

            toolStripButtonB4a.Checked = false;
            toolStripButtonB4i.Checked = false;
            toolStripButtonB4j.Checked = false;
            toolStripButtonB4r.Checked = true;

            lvwPermissions.Enabled = false;
            LanguageAPI.ToolTipText = _ResourceManager.GetString("ArduinoAPI");
            B4xHelp.ToolTipText = _ResourceManager.GetString("B4RHelp");

            if (!WasChecked) ReloadSettings();
        }

        private void ToolstripExit_Click(object sender, EventArgs e)
        {
            DoExit();
        }

        private void ToolstripOptions_Click(object sender, EventArgs e)
        {
            SaveScreenLayout();
            DoOptions();
        }

        private void ToolstripReload_Click(object sender, EventArgs e)
        {
            ReloadSettings();
        }

        #endregion

        #region Buttons

        private void btnAddSnippet_DragEnter(object sender, DragEventArgs e)
        {
            DoSnippetDragEnter(sender, e);
        }

        private void btnEditSnippet_Click(object sender, EventArgs e)
        {
            ComboBoxItem Item = (ComboBoxItem)cmbSnippets.SelectedItem;

            if (Item.EnglishText != "Comment")
            {
                string FileRoot = System.IO.Path.Combine(_SaveRoot, _SelectedObjectName).Replace(".", @"\");
                string Filename = System.IO.Path.Combine(FileRoot, Item.EnglishText + ".xml");

                XmlDocument Document = new XmlDocument();
                XDocument XDoc = XDocument.Load(Filename);

                string StringToReplace = "size=" + (char)34 + "1" + (char)34 + ">";
                string ReplacementString = "size=" + (char)34 + "2" + (char)34 + ">";

                string CommentContent = XDoc.Document.ToString().Replace(StringToReplace, ReplacementString);

                frmSnippet SnippetForm = new frmSnippet();

                SnippetForm.Snippet = CommentContent;
                SnippetForm.SnippetName = Item.EnglishText.ToString();
                SnippetForm.ObjectName = _SelectedObjectName;
                SnippetForm.SaveRoot = System.IO.Path.GetDirectoryName(Filename);

                SnippetForm.ShowDialog();
            }
        }

        private void btnRemoveSnippet_Click(object sender, EventArgs e)
        {
            ComboBoxItem Item = (ComboBoxItem)cmbSnippets.SelectedItem;
            string FileRoot = System.IO.Path.Combine(_SaveRoot, _SelectedObjectName).Replace(".", @"\");
            string FilePath = System.IO.Path.Combine(FileRoot, Item.EnglishText + ".xml");

            if (System.IO.File.Exists(FilePath))
            {
                System.IO.File.Delete(FilePath);

                cmbSnippets.Items.Clear();

                ComboBoxItem NewItem = new ComboBoxItem();
                NewItem.Text = _ResourceManager.GetString("Comment");
                NewItem.EnglishText = "Comment";

                cmbSnippets.Items.Add(NewItem);
                cmbSnippets.SelectedIndex = 0;

                GetCodeSnippets();
            }
        }

        private void btnRemoveSnippet_DragEnter(object sender, DragEventArgs e)
        {
            DoSnippetDragEnter(sender, e);
        }

        private void btnAddSnippet_Click(object sender, EventArgs e)
        {
            DoDropSnippet(null, null);
        }

        private void btnAddSnippet_DragDrop(object sender, DragEventArgs e)
        {
            DoDropSnippet(sender, e);
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            DoClearSearch();
        }

        private void btnRemoveSnippet_DragDrop(object sender, DragEventArgs e)
        {
            DoDropSnippet(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DoSearch();
        }

        #endregion

        private void cmbSnippets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSnippets.SelectedIndex > 0)
            {
                ComboBoxItem Item = (ComboBoxItem)cmbSnippets.SelectedItem;
                btnRemoveSnippet.Enabled = true;

                rtbClassComment.BeginUpdate();
                rtbClassComment.Clear();

                string FileRoot = System.IO.Path.Combine(_SaveRoot, _SelectedObjectName).Replace(".", @"\");
                string Filename = System.IO.Path.Combine(FileRoot, Item.EnglishText + ".xml");

                XmlDocument Document = new XmlDocument();
                XDocument XDoc = XDocument.Load(Filename);

                string StringToReplace = "size=" + (char)34 + "1" + (char)34 + ">";
                string ReplacementString = "size=" + (char)34 + "2" + (char)34 + ">";

                string CommentContent = XDoc.Document.ToString().Replace(StringToReplace, ReplacementString);

                rtbClassComment.AddHTML(CommentContent);
                rtbClassComment.SelectionStart = 0;
                rtbClassComment.SelectionLength = 0;
                rtbClassComment.ScrollToCaret();
                rtbClassComment.EndUpdate();

                btnRemoveSnippet.Enabled = true;
            }
            else
            {
                if (_LoadComplete) // required because events get fired off when you start up the app
                {
                    //btnRemoveSnippet.Enabled = false;
                    //SelectMethodPropertyFieldTreeNode();
                }
            }
        }

        private void CommentCopyText_Click(object sender, EventArgs e)
        {
            if (rtbClassComment.TextLength > 0)
            {
                if (rtbClassComment.SelectedText.Length > 0)
                {
                    Clipboard.SetText(rtbClassComment.SelectedText.Replace("\n", "\r\n"));
                }
                else
                {
                    Clipboard.SetText(rtbClassComment.Text.Replace("\n", "\r\n"));
                }
                Status.Text = _ResourceManager.GetString("TextCopied");
            }
        }

        private void CommentSearchB4xSite_Click(object sender, EventArgs e)
        {
            if (rtbClassComment.TextLength > 0 && rtbClassComment.SelectedText.Length > 0)
            {
                PerformSiteSearch(rtbClassComment.SelectedText);
            }
        }

        private void DoSnippetDragEnter(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & DragDropEffects.All) != 0 && e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void enableSnippetDragDropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.EnableSnippetDragDrop = enableSnippetDragDropToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void EventCopyText_Click(object sender, EventArgs e)
        {
            if (lvwEvents.Items.Count > 0)
            {
                Clipboard.SetText(lvwEvents.SelectedItems[0].Text);

                Status.Text = _ResourceManager.GetString("TextCopied");
            }
        }

        private void EventSearch_Click(object sender, EventArgs e)
        {
            if (lvwEvents.Items.Count > 0 && lvwEvents.SelectedItems.Count > 0)
            {
                PerformSiteSearch(lvwEvents.SelectedItems[0].Text);
            }
        }

        #region ListViews

        private void lvwPermissions_MouseMove(object sender, MouseEventArgs e)
        {
            //int newHoveredIndex = lstPermissions.IndexFromPoint(e.Location);
            return;
            //string HoveredText = lvwPermissions.GetItemAt(e.Location.X, e.Location.Y).ToString();
            //string NewTooltip = "";

            ////if (_PermissionsListHoverIndex != newHoveredIndex)
            ////{
            ////_PermissionsListHoverIndex = newHoveredIndex;
            //if (_PermissionsListHoverIndex > -1)
            //{
            //    // Get the text of the hovered item
            //    //string HoveredText = lvwPermissions.Items[newHoveredIndex].ToString();

            //    switch (HoveredText)
            //    {
            //        case "ACCESS_CHECKIN_PROPERTIES":
            //            NewTooltip = _ResourceManager.GetString("ACCESS_CHECKIN_PROPERTIES");
            //            break;
            //        case "ACCESS_COARSE_LOCATION":
            //            NewTooltip = _ResourceManager.GetString("ACCESS_COARSE_LOCATION");
            //            break;
            //        case "ACCESS_FINE_LOCATION":
            //            NewTooltip = _ResourceManager.GetString("ACCESS_FINE_LOCATION");
            //            break;
            //        case "ACCESS_LOCATION_EXTRA_COMMANDS":
            //            NewTooltip = _ResourceManager.GetString("ACCESS_LOCATION_EXTRA_COMMANDS");
            //            break;
            //        case "ACCESS_MOCK_LOCATION":
            //            NewTooltip = _ResourceManager.GetString("ACCESS_MOCK_LOCATION");
            //            break;
            //        case "ACCESS_NETWORK_STATE":
            //            NewTooltip = _ResourceManager.GetString("ACCESS_NETWORK_STATE");
            //            break;
            //        case "ACCESS_SURFACE_FLINGER":
            //            NewTooltip = _ResourceManager.GetString("ACCESS_SURFACE_FLINGER");
            //            break;
            //        case "ACCESS_WIFI_STATE":
            //            NewTooltip = _ResourceManager.GetString("ACCESS_WIFI_STATE");
            //            break;
            //        case "ACCOUNT_MANAGER":
            //            NewTooltip = _ResourceManager.GetString("ACCOUNT_MANAGER");
            //            break;
            //        case "ADD_VOICEMAIL":
            //            NewTooltip = _ResourceManager.GetString("ADD_VOICEMAIL");
            //            break;
            //        case "AUTHENTICATE_ACCOUNTS":
            //            NewTooltip = _ResourceManager.GetString("AUTHENTICATE_ACCOUNTS");
            //            break;
            //        case "BATTERY_STATS":
            //            NewTooltip = _ResourceManager.GetString("BATTERY_STATS");
            //            break;
            //        case "BIND_ACCESSIBILITY_SERVICE":
            //            NewTooltip = _ResourceManager.GetString("BIND_ACCESSIBILITY_SERVICE");
            //            break;
            //        case "BIND_APPWIDGET":
            //            NewTooltip = _ResourceManager.GetString("BIND_APPWIDGET");
            //            break;
            //        case "BIND_DEVICE_ADMIN":
            //            NewTooltip = _ResourceManager.GetString("BIND_DEVICE_ADMIN");
            //            break;
            //        case "BIND_INPUT_METHOD":
            //            NewTooltip = _ResourceManager.GetString("BIND_INPUT_METHOD");
            //            break;
            //        case "BIND_REMOTEVIEWS":
            //            NewTooltip = _ResourceManager.GetString("BIND_REMOTEVIEWS");
            //            break;
            //        case "BIND_TEXT_SERVICE":
            //            NewTooltip = _ResourceManager.GetString("BIND_TEXT_SERVICE");
            //            break;
            //        case "BIND_VPN_SERVICE":
            //            NewTooltip = _ResourceManager.GetString("BIND_VPN_SERVICE");
            //            break;
            //        case "BIND_WALLPAPER":
            //            NewTooltip = _ResourceManager.GetString("BIND_WALLPAPER");
            //            break;
            //        case "BLUETOOTH":
            //            NewTooltip = _ResourceManager.GetString("BLUETOOTH");
            //            break;
            //        case "BLUETOOTH_ADMIN":
            //            NewTooltip = _ResourceManager.GetString("BLUETOOTH_ADMIN");
            //            break;
            //        case "BRICK":
            //            NewTooltip = _ResourceManager.GetString("BRICK");
            //            break;
            //        case "BROADCAST_PACKAGE_REMOVED":
            //            NewTooltip = _ResourceManager.GetString("BROADCAST_PACKAGE_REMOVED");
            //            break;
            //        case "BROADCAST_SMS":
            //            NewTooltip = _ResourceManager.GetString("BROADCAST_SMS");
            //            break;
            //        case "BROADCAST_STICKY":
            //            NewTooltip = _ResourceManager.GetString("BROADCAST_STICKY");
            //            break;
            //        case "BROADCAST_WAP_PUSH":
            //            NewTooltip = _ResourceManager.GetString("BROADCAST_WAP_PUSH");
            //            break;
            //        case "CALL_PHONE":
            //            NewTooltip = _ResourceManager.GetString("CALL_PHONE");
            //            break;
            //        case "CALL_PRIVILEGED":
            //            NewTooltip = _ResourceManager.GetString("CALL_PRIVILEGED");
            //            break;
            //        case "CAMERA":
            //            NewTooltip = _ResourceManager.GetString("CAMERA");
            //            break;
            //        case "CHANGE_COMPONENT_ENABLED_STATE":
            //            NewTooltip = _ResourceManager.GetString("CHANGE_COMPONENT_ENABLED_STATE");
            //            break;
            //        case "CHANGE_CONFIGURATION":
            //            NewTooltip = _ResourceManager.GetString("CHANGE_CONFIGURATION");
            //            break;
            //        case "CHANGE_NETWORK_STATE":
            //            NewTooltip = _ResourceManager.GetString("CHANGE_NETWORK_STATE");
            //            break;
            //        case "CHANGE_WIFI_MULTICAST_STATE":
            //            NewTooltip = _ResourceManager.GetString("CHANGE_WIFI_MULTICAST_STATE");
            //            break;
            //        case "CHANGE_WIFI_STATE":
            //            NewTooltip = _ResourceManager.GetString("CHANGE_WIFI_STATE");
            //            break;
            //        case "CLEAR_APP_CACHE":
            //            NewTooltip = _ResourceManager.GetString("CLEAR_APP_CACHE");
            //            break;
            //        case "CLEAR_APP_USER_DATA":
            //            NewTooltip = _ResourceManager.GetString("CLEAR_APP_USER_DATA");
            //            break;
            //        case "CONTROL_LOCATION_UPDATES":
            //            NewTooltip = _ResourceManager.GetString("CONTROL_LOCATION_UPDATES");
            //            break;
            //        case "DELETE_CACHE_FILES":
            //            NewTooltip = _ResourceManager.GetString("DELETE_CACHE_FILES");
            //            break;
            //        case "DELETE_PACKAGES":
            //            NewTooltip = _ResourceManager.GetString("DELETE_PACKAGES");
            //            break;
            //        case "DEVICE_POWER":
            //            NewTooltip = _ResourceManager.GetString("DEVICE_POWER");
            //            break;
            //        case "DIAGNOSTIC":
            //            NewTooltip = _ResourceManager.GetString("DIAGNOSTIC");
            //            break;
            //        case "DISABLE_KEYGUARD":
            //            NewTooltip = _ResourceManager.GetString("DISABLE_KEYGUARD");
            //            break;
            //        case "DUMP":
            //            NewTooltip = _ResourceManager.GetString("DUMP");
            //            break;
            //        case "EXPAND_STATUS_BAR":
            //            NewTooltip = _ResourceManager.GetString("EXPAND_STATUS_BAR");
            //            break;
            //        case "FACTORY_TEST":
            //            NewTooltip = _ResourceManager.GetString("FACTORY_TEST");
            //            break;
            //        case "FLASHLIGHT":
            //            NewTooltip = _ResourceManager.GetString("FLASHLIGHT");
            //            break;
            //        case "FORCE_BACK":
            //            NewTooltip = _ResourceManager.GetString("FORCE_BACK");
            //            break;
            //        case "GET_ACCOUNTS":
            //            NewTooltip = _ResourceManager.GetString("GET_ACCOUNTS");
            //            break;
            //        case "GET_PACKAGE_SIZE":
            //            NewTooltip = _ResourceManager.GetString("GET_PACKAGE_SIZE");
            //            break;
            //        case "GET_TASKS":
            //            NewTooltip = _ResourceManager.GetString("GET_TASKS");
            //            break;
            //        case "GLOBAL_SEARCH":
            //            NewTooltip = _ResourceManager.GetString("GLOBAL_SEARCH");
            //            break;
            //        case "HARDWARE_TEST":
            //            NewTooltip = _ResourceManager.GetString("HARDWARE_TEST");
            //            break;
            //        case "INJECT_EVENTS":
            //            NewTooltip = _ResourceManager.GetString("INJECT_EVENTS");
            //            break;
            //        case "INSTALL_LOCATION_PROVIDER":
            //            NewTooltip = _ResourceManager.GetString("INSTALL_LOCATION_PROVIDER");
            //            break;
            //        case "INSTALL_PACKAGES":
            //            NewTooltip = _ResourceManager.GetString("INSTALL_PACKAGES");
            //            break;
            //        case "INTERNAL_SYSTEM_WINDOW":
            //            NewTooltip = _ResourceManager.GetString("INTERNAL_SYSTEM_WINDOW");
            //            break;
            //        case "INTERNET":
            //            NewTooltip = _ResourceManager.GetString("INTERNET");
            //            break;
            //        case "KILL_BACKGROUND_PROCESSES":
            //            NewTooltip = _ResourceManager.GetString("KILL_BACKGROUND_PROCESSES");
            //            break;
            //        case "MANAGE_ACCOUNTS":
            //            NewTooltip = _ResourceManager.GetString("MANAGE_ACCOUNTS");
            //            break;
            //        case "MANAGE_APP_TOKENS":
            //            NewTooltip = _ResourceManager.GetString("MANAGE_APP_TOKENS");
            //            break;
            //        case "MASTER_CLEAR":
            //            NewTooltip = "";
            //            break;
            //        case "MODIFY_AUDIO_SETTINGS":
            //            NewTooltip = _ResourceManager.GetString("MODIFY_AUDIO_SETTINGS");
            //            break;
            //        case "MODIFY_PHONE_STATE":
            //            NewTooltip = _ResourceManager.GetString("MODIFY_PHONE_STATE");
            //            break;
            //        case "MOUNT_FORMAT_FILESYSTEMS":
            //            NewTooltip = _ResourceManager.GetString("MOUNT_FORMAT_FILESYSTEMS");
            //            break;
            //        case "MOUNT_UNMOUNT_FILESYSTEMS":
            //            NewTooltip = _ResourceManager.GetString("MOUNT_UNMOUNT_FILESYSTEMS");
            //            break;
            //        case "NFC":
            //            NewTooltip = _ResourceManager.GetString("NFC");
            //            break;
            //        case "PERSISTENT_ACTIVITY":
            //            NewTooltip = _ResourceManager.GetString("PERSISTENT_ACTIVITY");
            //            break;
            //        case "PROCESS_OUTGOING_CALLS":
            //            NewTooltip = _ResourceManager.GetString("PROCESS_OUTGOING_CALLS");
            //            break;
            //        case "READ_CALENDAR":
            //            NewTooltip = _ResourceManager.GetString("READ_CALENDAR");
            //            break;
            //        case "READ_CALL_LOG":
            //            NewTooltip = _ResourceManager.GetString("READ_CALL_LOG");
            //            break;
            //        case "READ_CONTACTS":
            //            NewTooltip = _ResourceManager.GetString("READ_CONTACTS");
            //            break;
            //        case "READ_EXTERNAL_STORAGE":
            //            NewTooltip = _ResourceManager.GetString("READ_EXTERNAL_STORAGE");
            //            break;
            //        case "READ_FRAME_BUFFER":
            //            NewTooltip = _ResourceManager.GetString("READ_FRAME_BUFFER");
            //            break;
            //        case "READ_HISTORY_BOOKMARKS":
            //            NewTooltip = _ResourceManager.GetString("READ_HISTORY_BOOKMARKS");
            //            break;
            //        case "READ_INPUT_STATE":
            //            NewTooltip = _ResourceManager.GetString("READ_INPUT_STATE");
            //            break;
            //        case "READ_LOGS":
            //            NewTooltip = _ResourceManager.GetString("READ_LOGS");
            //            break;
            //        case "READ_PHONE_STATE":
            //            NewTooltip = _ResourceManager.GetString("READ_PHONE_STATE");
            //            break;
            //        case "READ_PROFILE":
            //            NewTooltip = _ResourceManager.GetString("READ_PROFILE");
            //            break;
            //        case "READ_SMS":
            //            NewTooltip = _ResourceManager.GetString("READ_SMS");
            //            break;
            //        case "READ_SOCIAL_STREAM":
            //            NewTooltip = _ResourceManager.GetString("READ_SOCIAL_STREAM");
            //            break;
            //        case "READ_SYNC_SETTINGS":
            //            NewTooltip = _ResourceManager.GetString("READ_SYNC_SETTINGS");
            //            break;
            //        case "READ_SYNC_STATS":
            //            NewTooltip = _ResourceManager.GetString("READ_SYNC_STATS");
            //            break;
            //        case "READ_USER_DICTIONARY":
            //            NewTooltip = _ResourceManager.GetString("READ_USER_DICTIONARY");
            //            break;
            //        case "REBOOT":
            //            NewTooltip = _ResourceManager.GetString("REBOOT");
            //            break;
            //        case "RECEIVE_BOOT_COMPLETED":
            //            NewTooltip = _ResourceManager.GetString("RECEIVE_BOOT_COMPLETED");
            //            break;
            //        case "RECEIVE_MMS":
            //            NewTooltip = _ResourceManager.GetString("RECEIVE_MMS");
            //            break;
            //        case "RECEIVE_SMS":
            //            NewTooltip = _ResourceManager.GetString("RECEIVE_SMS");
            //            break;
            //        case "RECEIVE_WAP_PUSH":
            //            NewTooltip = _ResourceManager.GetString("RECEIVE_WAP_PUSH");
            //            break;
            //        case "RECORD_AUDIO":
            //            NewTooltip = _ResourceManager.GetString("RECORD_AUDIO");
            //            break;
            //        case "REORDER_TASKS":
            //            NewTooltip = _ResourceManager.GetString("REORDER_TASKS");
            //            break;
            //        case "RESTART_PACKAGES":
            //            NewTooltip = _ResourceManager.GetString("RESTART_PACKAGES");
            //            break;
            //        case "SEND_SMS":
            //            NewTooltip = _ResourceManager.GetString("SEND_SMS");
            //            break;
            //        case "SET_ACTIVITY_WATCHER":
            //            NewTooltip = _ResourceManager.GetString("SET_ACTIVITY_WATCHER");
            //            break;
            //        case "SET_ALARM":
            //            NewTooltip = _ResourceManager.GetString("SET_ALARM");
            //            break;
            //        case "SET_ALWAYS_FINISH":
            //            NewTooltip = _ResourceManager.GetString("SET_ALWAYS_FINISH");
            //            break;
            //        case "SET_ANIMATION_SCALE":
            //            NewTooltip = _ResourceManager.GetString("SET_ANIMATION_SCALE");
            //            break;
            //        case "SET_DEBUG_APP":
            //            NewTooltip = _ResourceManager.GetString("SET_DEBUG_APP");
            //            break;
            //        case "SET_ORIENTATION":
            //            NewTooltip = _ResourceManager.GetString("SET_ORIENTATION");
            //            break;
            //        case "SET_POINTER_SPEED":
            //            NewTooltip = _ResourceManager.GetString("SET_POINTER_SPEED");
            //            break;
            //        case "SET_PREFERRED_APPLICATIONS":
            //            NewTooltip = _ResourceManager.GetString("SET_PREFERRED_APPLICATIONS");
            //            break;
            //        case "SET_PROCESS_LIMIT":
            //            NewTooltip = _ResourceManager.GetString("SET_PROCESS_LIMIT");
            //            break;
            //        case "SET_TIME":
            //            NewTooltip = _ResourceManager.GetString("SET_TIME");
            //            break;
            //        case "SET_TIME_ZONE":
            //            NewTooltip = _ResourceManager.GetString("SET_TIME_ZONE");
            //            break;
            //        case "SET_WALLPAPER":
            //            NewTooltip = _ResourceManager.GetString("SET_WALLPAPER");
            //            break;
            //        case "SET_WALLPAPER_HINTS":
            //            NewTooltip = _ResourceManager.GetString("SET_WALLPAPER_HINTS");
            //            break;
            //        case "SIGNAL_PERSISTENT_PROCESSES":
            //            NewTooltip = _ResourceManager.GetString("SIGNAL_PERSISTENT_PROCESSES");
            //            break;
            //        case "STATUS_BAR":
            //            NewTooltip = _ResourceManager.GetString("STATUS_BAR");
            //            break;
            //        case "SUBSCRIBED_FEEDS_READ":
            //            NewTooltip = _ResourceManager.GetString("SUBSCRIBED_FEEDS_READ");
            //            break;
            //        case "SUBSCRIBED_FEEDS_WRITE":
            //            NewTooltip = "";
            //            break;
            //        case "SYSTEM_ALERT_WINDOW":
            //            NewTooltip = _ResourceManager.GetString("SYSTEM_ALERT_WINDOW");
            //            break;
            //        case "UPDATE_DEVICE_STATS":
            //            NewTooltip = _ResourceManager.GetString("UPDATE_DEVICE_STATS");
            //            break;
            //        case "USE_CREDENTIALS":
            //            NewTooltip = _ResourceManager.GetString("USE_CREDENTIALS");
            //            break;
            //        case "USE_SIP":
            //            NewTooltip = _ResourceManager.GetString("USE_SIP");
            //            break;
            //        case "VIBRATE":
            //            NewTooltip = _ResourceManager.GetString("VIBRATE");
            //            break;
            //        case "WAKE_LOCK":
            //            NewTooltip = _ResourceManager.GetString("WAKE_LOCK");
            //            break;
            //        case "WRITE_APN_SETTINGS":
            //            NewTooltip = _ResourceManager.GetString("WRITE_APN_SETTINGS");
            //            break;
            //        case "WRITE_CALENDAR":
            //            NewTooltip = _ResourceManager.GetString("WRITE_CALENDAR");
            //            break;
            //        case "WRITE_CALL_LOG":
            //            NewTooltip = _ResourceManager.GetString("WRITE_CALL_LOG");
            //            break;
            //        case "WRITE_CONTACTS":
            //            NewTooltip = _ResourceManager.GetString("WRITE_CONTACTS");
            //            break;
            //        case "WRITE_EXTERNAL_STORAGE":
            //            NewTooltip = _ResourceManager.GetString("WRITE_EXTERNAL_STORAGE");
            //            break;
            //        case "WRITE_GSERVICES":
            //            NewTooltip = _ResourceManager.GetString("WRITE_GSERVICES");
            //            break;
            //        case "WRITE_HISTORY_BOOKMARKS":
            //            NewTooltip = _ResourceManager.GetString("WRITE_HISTORY_BOOKMARKS");
            //            break;
            //        case "WRITE_PROFILE":
            //            NewTooltip = _ResourceManager.GetString("WRITE_PROFILE");
            //            break;
            //        case "WRITE_SECURE_SETTINGS":
            //            NewTooltip = _ResourceManager.GetString("WRITE_SECURE_SETTINGS");
            //            break;
            //        case "WRITE_SETTINGS":
            //            NewTooltip = _ResourceManager.GetString("WRITE_SETTINGS");
            //            break;
            //        case "WRITE_SMS":
            //            NewTooltip = _ResourceManager.GetString("WRITE_SMS");
            //            break;
            //        case "WRITE_SOCIAL_STREAM":
            //            NewTooltip = _ResourceManager.GetString("WRITE_SOCIAL_STREAM");
            //            break;
            //        case "WRITE_SYNC_SETTINGS":
            //            NewTooltip = _ResourceManager.GetString("WRITE_SYNC_SETTINGS");
            //            break;
            //        case "WRITE_USER_DICTIONARY":
            //            NewTooltip = _ResourceManager.GetString("WRITE_USER_DICTIONARY");
            //            break;
            //    }

            //    PermissionsTips.Active = false;
            //    PermissionsTips.SetToolTip(lvwPermissions, NewTooltip);
            //    PermissionsTips.Active = true;
            //}
            //}
        }

        private void lvwDetails_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            if (_LoadComplete)
            {
                if (e.ColumnIndex == 0)
                {
                    lvwDetails.Columns[1].Width = lvwDetails.ClientRectangle.Width - lvwDetails.Columns[0].Width;
                }
            }
        }

        private void lvwDetails_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            //if (_LoadComplete)
            //{
            //    if (e.ColumnIndex == 0)
            //    {
            //        lvwDetails.Columns[1].Width = lvwDetails.ClientRectangle.Width - lvwDetails.Columns[0].Width;
            //    }
            //}
        }

        private void lvwDetails_SizeChanged(object sender, EventArgs e)
        {
            //lvwDetails.Columns[1].Width = lvwDetails.ClientRectangle.Width - lvwDetails.Columns[0].Width;
            ResizeDetailsColumns();
        }

        private void lvwEvents_SizeChanged(object sender, EventArgs e)
        {
            lvwEvents.Columns[0].Width = lvwEvents.ClientRectangle.Width;
        }

        private void lvwPermissions_SizeChanged(object sender, EventArgs e)
        {
            lvwPermissions.Columns[0].Width = lvwPermissions.ClientRectangle.Width;
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == System.Windows.Forms.MouseButtons.Left)
            //{
            //    frmSnippet SnippetForm = new frmSnippet();

            //    SnippetForm.Show();

            //    notifyIcon.Visible = false;
            //}
        }

        private void picExtraComments_Click(object sender, EventArgs e)
        {
            ComboBoxItem Item = (ComboBoxItem)cmbSnippets.SelectedItem;

            if (Item.EnglishText != "Comment")
            {
                string FileRoot = System.IO.Path.Combine(_SaveRoot, _SelectedObjectName).Replace(".", @"\");
                string Filename = System.IO.Path.Combine(FileRoot, Item.EnglishText + ".xml");

                XmlDocument Document = new XmlDocument();
                XDocument XDoc = XDocument.Load(Filename);

                string StringToReplace = "size=" + (char)34 + "1" + (char)34 + ">";
                string ReplacementString = "size=" + (char)34 + "2" + (char)34 + ">";

                string CommentContent = XDoc.Document.ToString().Replace(StringToReplace, ReplacementString);

                frmSnippet SnippetForm = new frmSnippet();

                SnippetForm.Snippet = CommentContent;
                SnippetForm.SnippetName = Item.EnglishText.ToString();
                SnippetForm.ObjectName = _SelectedObjectName;
                SnippetForm.SaveRoot = System.IO.Path.GetDirectoryName(Filename);

                SnippetForm.ShowDialog();
            }
        }

        #endregion

        #region Rich Text boxes

        private void rtbClassComment_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {

        }

        private void rtbClassComment_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string text = string.Empty;
            if (e.Data.GetDataPresent("HTML Format"))
            {
                text = (string)e.Data.GetData("HTML Format");
                e.Effect = DragDropEffects.Copy;
                Console.WriteLine("Effect on");
            }
            else if (e.Data.GetDataPresent(DataFormats.Text))
            {
                // URL
                text = (string)e.Data.GetData(DataFormats.Text);
                e.Effect = DragDropEffects.Copy;
                Console.WriteLine("Effect on");
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                //foreach (string file in files)
                //{
                //    // .url for Chrome and FF, .website for IE
                //    if (file.EndsWith(".url") || file.EndsWith(".website"))
                //    {
                //        //IniFile ini = new IniFile(file);
                //        //text += ini.IniReadValue("InternetShortcut", "URL") + Environment.NewLine;
                //    }
                //    else
                //    {
                //        MessageBox.Show("Unsupported file format for file: " + file);
                //    }
                //}
            }

            Cursor.Current = Cursors.Default;
        }

        private void rtbClassComment_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void rtbClassComment_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            OpenSite(e.LinkText);
        }

        private void rtbComment_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            OpenSite(e.LinkText);
        }

        private void rtbMain_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            OpenSite(e.LinkText);
        }

        #endregion

        private void tlpCommentSnippets_DragDrop(object sender, DragEventArgs e)
        {
            DoDropSnippet(sender, e);
        }

        private void tlpCommentSnippets_DragEnter(object sender, DragEventArgs e)
        {
            DoSnippetDragEnter(sender, e);
        }

        #region TreeViews

        private void tvwClasses_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectLibraryOrClassTreeNode();
        }

        private void tvwClasses_Click(object sender, EventArgs e)
        {
            if (tvwClasses.SelectedNode != null)
            {
                if (tvwClasses.SelectedNode.Level < 2)
                {
                    //SelectLibraryOrClassTreeNode();
                }
            }
        }

        private void tvwMethodsPropertiesFields_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_LoadComplete) // required because events get fired off when you start up the app
            {
                //rtbClassComment.BeginUpdate();
                SelectMethodPropertyFieldTreeNode();
                //rtbClassComment.EndUpdate();

                //cmbSnippets.Items.Clear();

                //ComboBoxItem Item = new ComboBoxItem();
                //Item.Text = _ResourceManager.GetString("Comment");
                //Item.EnglishText = "Comment";

                //cmbSnippets.Items.Add(Item);
                //cmbSnippets.SelectedIndex = 0;

                //GetCodeSnippets();
            }
        }

        #endregion

        #region Textboxes

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == _ResourceManager.GetString("SearchText")) txtSearch.Clear();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = true;

                if (txtSearch.Text.Trim() == "")
                {
                    DoClearSearch();
                }
                else
                {
                    DoSearch();
                }
            }

            if (e.KeyData == Keys.Escape)
            {
                e.Handled = true;

                DoClearSearch();
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "") txtSearch.Text = _ResourceManager.GetString("SearchText");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #endregion

        #region Constructors

        public frmMain()
        {
            InitializeComponent();

            // Init _ResourceManager
            _ResourceManager = new ResourceManager("Browser.Strings", Assembly.GetExecutingAssembly());
            // Init UICulture to CurrentCulture
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            Globals.GetPCLanguageSetting();

            // Init Controls
            UpdateUIControls();

        }

        #endregion

        #region Private Methods

        #region Search

        private TreeNode AddToTreeview(Annotation SelectedAnnotation, bool IsParentNode)
        {
            TreeNode AnnotationNode = null;
            TreeNode LibraryNode = null;

            if (
                SelectedAnnotation.Name.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                SelectedAnnotation.Value.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                !_SearchMode ||
                IsParentNode
                )
            {
                TreeNode[] SearchResults;
                if (SelectedAnnotation.ParentLibrary != null)
                    LibraryNode = AddToTreeview(SelectedAnnotation.ParentLibrary, true);  // Adds or finds the Library node

                if (SelectedAnnotation.ParentClass != null)
                    LibraryNode = AddToTreeview(SelectedAnnotation.ParentClass, true);  // Adds or finds the Library node

                if (Properties.Settings.Default.ShowSearchResultsInLibraryClassTreeView)
                {
                    if (LibraryNode != null)
                    {
                        SearchResults = LibraryNode.Nodes.Find(TypeName(SelectedAnnotation.Name), false);

                        if (SearchResults.Count() > 0)
                        {
                            AnnotationNode = SearchResults[0];
                        }
                        else
                        {
                            AnnotationNode = new TreeNode();
                            AnnotationNode.ImageIndex = 14;
                            AnnotationNode.SelectedImageIndex = 14;
                            AnnotationNode.Text = TypeName(SelectedAnnotation.Name);
                            AnnotationNode.Name = TypeName(SelectedAnnotation.Name);
                            AnnotationNode.Tag = SelectedAnnotation;

                            LibraryNode.Nodes.Add(AnnotationNode);
                        }
                    }
                }
            }
            return AnnotationNode;
        }

        private TreeNode AddToTreeview(Class SelectedClass, bool IsParentNode)
        {
            TreeNode ClassNode = null;
            bool AddClass = false;

            foreach (Event SelectedEvent in SelectedClass.Events)
            {
                if (SelectedEvent.Name.ToLower().Contains(txtSearch.Text.Trim().ToLower()))
                    AddClass = true;
            }

            if (
                SelectedClass.Name.InnerText.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                SelectedClass.Author.InnerText.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                SelectedClass.ObjectWrapper.InnerText.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                SelectedClass.Owner.InnerText.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                SelectedClass.ShortName.InnerText.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                SelectedClass.Version.InnerText.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                AddClass ||
                !_SearchMode ||
                IsParentNode
                )
            {
                TreeNode[] SearchResults = { };
                TreeNode LibraryNode = AddToTreeview(SelectedClass.Parent, true);  // Adds or finds the Library node

                if (LibraryNode != null)
                {
                    SearchResults = LibraryNode.Nodes.Find(TypeName(SelectedClass.Name.InnerText), false);

                    if (SearchResults.Count() > 0)
                    {
                        ClassNode = SearchResults[0];
                    }
                    else
                    {
                        ClassNode = new TreeNode();
                        ClassNode.ImageIndex = 0;
                        ClassNode.SelectedImageIndex = 0;
                        ClassNode.Text = TypeName(SelectedClass.Name.InnerText);
                        ClassNode.Name = TypeName(SelectedClass.Name.InnerText);
                        ClassNode.Tag = SelectedClass;

                        LibraryNode.Nodes.Add(ClassNode);
                    }
                }
            }
            return ClassNode;
        }

        private TreeNode AddToTreeview(Comment SelectedComment, bool IsParentNode)
        {
            TreeNode[] SearchResults = null;
            //TreeNode LibraryNode = AddToTreeview(SelectedComment.Parent.Parent.Parent);  // Adds or finds the Library node
            //TreeNode ParameterNode = null;

            //TreeNode ClassNode = AddToTreeview(SelectedComment.Parent.Parent);           // Adds or finds the Class node
            //TreeNode MethodNode = AddToTreeview(SelectedComment.Parent);                 // Adds or finds the Method node

            //SearchResults = MethodNode.Nodes.Find(TypeName(SelectedComment.Parent.Name), false);  // Methodname

            if (SearchResults.Count() > 0)
            {
                //ParameterNode = SearchResults[0];
            }
            else
            {
                //ParameterNode = new TreeNode();
                //ParameterNode.ImageIndex = 5;
                //ParameterNode.SelectedImageIndex = 5;
                //ParameterNode.Text = TypeName(SelectedComment.Name);
                //ParameterNode.Name = TypeName(SelectedComment.Name);
                //ParameterNode.Tag = SelectedComment;

                //MethodNode.Nodes.Add(ParameterNode);
            }

            return null; //ParameterNode;
        }

        private TreeNode AddToTreeview(Event SelectedEvent, bool IsParentNode)
        {
            TreeNode EventNode = null;

            if (
                SelectedEvent.Name.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                !_SearchMode ||
                IsParentNode
                )
            {
                TreeNode[] SearchResults;
                TreeNode LibraryNode = AddToTreeview(SelectedEvent.Parent, true);  // Adds or finds the Library node

                if (Properties.Settings.Default.ShowSearchResultsInLibraryClassTreeView)
                {
                    if (LibraryNode != null)
                    {
                        SearchResults = LibraryNode.Nodes.Find(TypeName(SelectedEvent.Name), false);

                        if (SearchResults.Count() > 0)
                        {
                            EventNode = SearchResults[0];
                        }
                        else
                        {
                            EventNode = new TreeNode();
                            EventNode.ImageIndex = 15;
                            EventNode.SelectedImageIndex = 15;
                            EventNode.Text = TypeName(SelectedEvent.Name);
                            EventNode.Name = TypeName(SelectedEvent.Name);
                            EventNode.Tag = SelectedEvent;

                            LibraryNode.Nodes.Add(EventNode);
                        }
                    }
                }
            }
            return EventNode;
        }

        private TreeNode AddToTreeview(Field SelectedField, bool IsParentNode)
        {
            TreeNode FieldNode = null;
            if (
                SelectedField.Name.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                SelectedField.DesignerName.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                !_SearchMode ||
                IsParentNode
                )
            {
                TreeNode[] SearchResults = { };
                TreeNode LibraryNode = AddToTreeview(SelectedField.Parent, true);  // Adds or finds the Library node

                if (Properties.Settings.Default.ShowSearchResultsInLibraryClassTreeView)
                {
                    if (LibraryNode != null)
                    {
                        SearchResults = LibraryNode.Nodes.Find(TypeName(SelectedField.Name), false);

                        if (SearchResults.Count() > 0)
                        {
                            FieldNode = SearchResults[0];
                        }
                        else
                        {
                            FieldNode = new TreeNode();
                            FieldNode.ImageIndex = 1;
                            FieldNode.SelectedImageIndex = 1;
                            FieldNode.Text = TypeName(SelectedField.Name);
                            if (SelectedField.DesignerName != "")
                            {
                                FieldNode.Name = TypeName(SelectedField.DesignerName);
                            }
                            else
                            {
                                FieldNode.Name = TypeName(SelectedField.Name);
                            }

                            FieldNode.Tag = SelectedField;

                            LibraryNode.Nodes.Add(FieldNode);
                        }
                    }
                }
            }
            return FieldNode;
        }

        private TreeNode AddToTreeview(Library SelectedLibrary, bool IsParentNode)
        {
            TreeNode LibraryNode = null;
            Annotation AuthorAnnotation = new Browser.Annotation("Author", txtSearch.Text.Trim().ToLower());

            if (
                SelectedLibrary.Name.InnerText.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                SelectedLibrary.Path.InnerText.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                SelectedLibrary.Annotations.Contains(AuthorAnnotation) ||
                !_SearchMode ||
                IsParentNode
                )
            {
                TreeNode[] SearchResults; // = new TreeNode();

                SearchResults = tvwClasses.Nodes.Find(TypeName(SelectedLibrary.Name.InnerText), false);

                if (SearchResults.Count() > 0)
                {
                    LibraryNode = SearchResults[0];
                }
                else
                {
                    LibraryNode = new TreeNode();
                    LibraryNode.ImageIndex = 3;
                    LibraryNode.SelectedImageIndex = 3;
                    LibraryNode.Text = TypeName(SelectedLibrary.Name.InnerText);
                    LibraryNode.Name = TypeName(SelectedLibrary.Name.InnerText);
                    LibraryNode.Tag = SelectedLibrary;

                    tvwClasses.Nodes.Add(LibraryNode);
                }
            }
            return LibraryNode;
        }

        private TreeNode AddToTreeview(Method SelectedMethod, bool IsParentNode)
        {
            TreeNode MethodNode = null;

            if (
                SelectedMethod.Name.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                SelectedMethod.DesignerName.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                !_SearchMode ||
                IsParentNode
                )
            {
                TreeNode[] SearchResults = { };
                TreeNode LibraryNode = AddToTreeview(SelectedMethod.Parent, true);  // Adds or finds the Library node

                if (Properties.Settings.Default.ShowSearchResultsInLibraryClassTreeView)
                {
                    if (LibraryNode != null)
                    {
                        SearchResults = LibraryNode.Nodes.Find(TypeName(SelectedMethod.Name), false);

                        if (SearchResults.Count() > 0)
                        {
                            MethodNode = SearchResults[0];
                        }
                        else
                        {
                            MethodNode = new TreeNode();
                            MethodNode.ImageIndex = 2;
                            MethodNode.SelectedImageIndex = 2;
                            MethodNode.Text = TypeName(SelectedMethod.Name);
                            if (SelectedMethod.DesignerName != "")
                            {
                                MethodNode.Name = TypeName(SelectedMethod.DesignerName);
                            }
                            else
                            {
                                MethodNode.Name = TypeName(SelectedMethod.Name);
                            }

                            MethodNode.Tag = SelectedMethod;

                            LibraryNode.Nodes.Add(MethodNode);
                        }
                    }
                }
            }
            return MethodNode;
        }

        private TreeNode AddToTreeview(Parameter SelectedParameter, bool IsParentNode)
        {
            TreeNode ParameterNode = null;

            if (
                SelectedParameter.Name.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                !_SearchMode |
                IsParentNode
                )
            {
                TreeNode[] SearchResults = { };
                TreeNode LibraryNode = AddToTreeview(SelectedParameter.Parent.Parent.Parent, true);  // Adds or finds the Library node

                if (LibraryNode != null)
                {
                    TreeNode SearchNode = null;
                    TreeNode ClassNode = AddToTreeview(SelectedParameter.Parent.Parent, true);           // Adds or finds the Class node

                    if (Properties.Settings.Default.ShowSearchResultsInLibraryClassTreeView)
                    {
                        if (ClassNode != null)
                        {
                            // Attempt to find the Method.  There may not be one (it could be a Property)
                            try
                            {
                                SearchNode = AddToTreeview(SelectedParameter.Parent, true);                                   // Adds or finds the Method node
                                if (SearchNode != null)
                                {
                                    SearchResults = SearchNode.Nodes.Find(TypeName(SelectedParameter.Parent.Name), false);  // Methodname
                                }
                            }
                            catch
                            {
                                SearchNode = AddToTreeview(SelectedParameter.Parent, true);                                   // Adds or finds the Property node
                                if (SearchNode != null)
                                {
                                    SearchResults = SearchNode.Nodes.Find(TypeName(SelectedParameter.Parent.Name), false);  // Propertyname
                                }
                            }

                            if (SearchResults != null)
                            {
                                if (SearchResults.Count() > 0)
                                {
                                    ParameterNode = SearchResults[0];
                                }
                                else
                                {
                                    ParameterNode = new TreeNode();
                                    ParameterNode.ImageIndex = 13;
                                    ParameterNode.SelectedImageIndex = 13;
                                    ParameterNode.Text = TypeName(SelectedParameter.Name);
                                    ParameterNode.Name = TypeName(SelectedParameter.Name);
                                    ParameterNode.Tag = SelectedParameter;

                                    SearchNode.Nodes.Add(ParameterNode);
                                }
                            }
                        }
                    }
                }
            }
            return ParameterNode;
        }

        private TreeNode AddToTreeview(Permission SelectedPermission, bool IsParentNode)
        {
            TreeNode PermissionNode = null;

            if (
                SelectedPermission.Name.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                !_SearchMode ||
                IsParentNode
                )
            {
                TreeNode[] SearchResults;
                TreeNode LibraryNode = AddToTreeview(SelectedPermission.Parent, true);  // Adds or finds the Library node

                if (Properties.Settings.Default.ShowSearchResultsInLibraryClassTreeView)
                {
                    if (LibraryNode != null)
                    {
                        SearchResults = LibraryNode.Nodes.Find(TypeName(SelectedPermission.Name), false);

                        if (SearchResults.Count() > 0)
                        {
                            PermissionNode = SearchResults[0];
                        }
                        else
                        {
                            PermissionNode = new TreeNode();
                            PermissionNode.ImageIndex = 16;
                            PermissionNode.SelectedImageIndex = 16;
                            PermissionNode.Text = TypeName(SelectedPermission.Name);
                            PermissionNode.Name = TypeName(SelectedPermission.Name);
                            PermissionNode.Tag = SelectedPermission;

                            LibraryNode.Nodes.Add(PermissionNode);
                        }
                    }
                }
            }
            return PermissionNode;
        }

        private TreeNode AddToTreeview(Property SelectedProperty, bool IsParentNode)
        {
            TreeNode PropertyNode = null;

            if (
                SelectedProperty.Name.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                SelectedProperty.DesignerName.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                !_SearchMode |
                IsParentNode
                )
            {
                TreeNode[] SearchResults = { };
                TreeNode LibraryNode = AddToTreeview(SelectedProperty.Parent, true);  // Adds or finds the Library node

                if (Properties.Settings.Default.ShowSearchResultsInLibraryClassTreeView)
                {
                    if (LibraryNode != null)
                    {
                        SearchResults = LibraryNode.Nodes.Find(TypeName(SelectedProperty.Name), false);

                        if (SearchResults.Count() > 0)
                        {
                            PropertyNode = SearchResults[0];
                        }
                        else
                        {
                            PropertyNode = new TreeNode();
                            PropertyNode.ImageIndex = 4;
                            PropertyNode.SelectedImageIndex = 4;
                            PropertyNode.Text = TypeName(SelectedProperty.Name);
                            if (SelectedProperty.DesignerName != "")
                            {
                                PropertyNode.Name = TypeName(SelectedProperty.DesignerName);
                            }
                            else
                            {
                                PropertyNode.Name = TypeName(SelectedProperty.Name);
                            }

                            PropertyNode.Tag = SelectedProperty;

                            LibraryNode.Nodes.Add(PropertyNode);
                        }
                    }
                }
            }
            return PropertyNode;
        }

        private TreeNode AddToTreeview(DesignerProperty SelectedProperty, bool IsParentNode)
        {
            TreeNode PropertyNode = null;

            if (
                SelectedProperty.Key.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                SelectedProperty.DisplayName.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                !_SearchMode |
                IsParentNode
                )
            {
                TreeNode[] SearchResults = { };
                TreeNode LibraryNode = AddToTreeview(SelectedProperty.Parent, true);  // Adds or finds the Library node

                if (Properties.Settings.Default.ShowSearchResultsInLibraryClassTreeView)
                {
                    if (LibraryNode != null)
                    {
                        SearchResults = LibraryNode.Nodes.Find(TypeName(SelectedProperty.Key), false);

                        if (SearchResults.Count() > 0)
                        {
                            PropertyNode = SearchResults[0];
                        }
                        else
                        {
                            PropertyNode = new TreeNode();
                            PropertyNode.ImageIndex = 4;
                            PropertyNode.SelectedImageIndex = 4;
                            PropertyNode.Text = TypeName(SelectedProperty.Key);
                            if (SelectedProperty.DisplayName != "")
                            {
                                PropertyNode.Name = TypeName(SelectedProperty.DisplayName);
                            }
                            else
                            {
                                PropertyNode.Name = TypeName(SelectedProperty.Key);
                            }

                            PropertyNode.Tag = SelectedProperty;

                            LibraryNode.Nodes.Add(PropertyNode);
                        }
                    }
                }
            }
            return PropertyNode;
        }

        #endregion

        private void AppendHTML(HtmlRichTextBox rtbInstance, Color color, Font NewFont, string HTML)
        {
            rtbInstance.AddHTML(HTML);
        }

        private void AppendText(RichTextBox rtbInstance, Color color, Font NewFont, string text)
        {
            int StartPosition = 0;
            int EndPosition = 0;

            StartPosition = rtbInstance.TextLength;                          // Get the current length
            rtbInstance.AppendText(text + "");                               // Add the text
            EndPosition = rtbInstance.TextLength;                            // Get the new length

            rtbInstance.Select(StartPosition, EndPosition - StartPosition);  // Select the newly added text only
            rtbInstance.SelectionColor = color;                              // Set the new colour
            rtbInstance.SelectionFont = NewFont;                             // Set the new font
            rtbInstance.SelectionLength = 0;                                 // Finish
        }

        private void AutoUpdate()
        {
            /* AutoUpdater.Start function takes the following Arguments
             * 1. url of the appcast xml file that specifies download url, changelog url, application Version and title
             * 2. If you want user to select remind later interval then set lateUserSelectRemindLater as true. If you select true third and fourth arguments will be ignored.
             * 3. reminderLaterTime is a remind later timespan value if user choose Remind Later.
             * 4. reminderLaterTimeFormat is a time format enum that specifies if you want to take remind later time span value as minutes, hours or days.
             * AutoUpdater.Start(string appcastURL, bool lateUserSelectRemindLater, int reminderLaterTime, int reminderLaterTimeFormat)
            */

            AutoUpdater.Start("http://logonengine.com/autoupdate/B4xBrowser.xml");
        }

        private string Decode(string UnicodeString)
        {
            Regex DECODING_REGEX = new Regex(@"\\u(?<Value>[a-fA-F0-9]{4})", RegexOptions.Compiled);
            string PLACEHOLDER = @"#!#";

            return DECODING_REGEX.Replace(UnicodeString.Replace(@"\\", PLACEHOLDER),
            m =>
            {
                return ((char)int.Parse(m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString();
            })
            .Replace(PLACEHOLDER, @"\\");

        }

        private void DoClearSearch()
        {
            if (txtSearch.Text.Trim() != _ResourceManager.GetString("SearchText"))
            {
                txtSearch.Text = _ResourceManager.GetString("SearchText");
                _SearchMode = false;
                btnClearSearch.Focus();
                ReloadSettings();
            }
        }

        private void DocumentClass(Class SelectedClass, HtmlRichTextBox TargetRTB, bool ForPrint)
        {
            int SelectedComment = 0;

            TargetRTB.BeginUpdate();

            if (ForPrint) Status.Text = _ResourceManager.GetString("Documenting") + " " + SelectedClass.ShortName.InnerText;
            //Progress.Style = ProgressBarStyle.Marquee;
            StatusBar.Refresh();
            //Application.DoEvents();

            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, 12, FontStyle.Regular), SelectedClass.ShortName.Value);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, 10, FontStyle.Regular), Environment.NewLine + _ResourceManager.GetString("Overview"));
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendHTML(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedClass.Comments[SelectedComment].Text);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            if (SelectedClass.ObjectWrapper.InnerText.Length > 0)
            {
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + _ResourceManager.GetString("ThisClassWraps") + " " + SelectedClass.ObjectWrapper);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            }
            if (SelectedClass.DependsOn.Count > 0)
            {
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), _ResourceManager.GetString("ThisClassDependsOn") + ":");
                foreach (XmlElement Dependancy in SelectedClass.DependsOn)
                {
                    AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + Dependancy.InnerText);
                }
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            }
            else
            {
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), _ResourceManager.GetString("ZeroDependencies"));
            }

            if (SelectedClass.Methods.Count > 1)
            {
                // Methods ------------------------------------------------------------------------------------------------------------------------------------------------------------
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, 10, FontStyle.Regular), Environment.NewLine + _ResourceManager.GetString("Methods"));
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + _ResourceManager.GetString("Name") + "\t" + _ResourceManager.GetString("Description"));

                foreach (Method SelectedMethod in SelectedClass.Methods)
                {
                    AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + SelectedMethod.Name + "\t");
                    AppendHTML(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedMethod.Comments[SelectedComment].Text);
                }

                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);

                foreach (Method SelectedMethod in SelectedClass.Methods)
                {
                    DocumentMethod(SelectedClass, SelectedMethod, rtbDocumentation, ForPrint);
                    AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                    AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                }
            }

            if (SelectedClass.Properties.Count > 0)
            {
                // Properties --------------------------------------------------------------------------------------------------------------------------------------------------------
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, 10, FontStyle.Regular), Environment.NewLine + _ResourceManager.GetString("Properties"));
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + _ResourceManager.GetString("Name") + "\t" + _ResourceManager.GetString("Description"));

                foreach (Property SelectedProperty in SelectedClass.Properties)
                {
                    AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + SelectedProperty.Name + "\t");
                    AppendHTML(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedProperty.Comments[SelectedComment].Text);
                }

                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);

                foreach (Property SelectedProperty in SelectedClass.Properties)
                {
                    DocumentProperty(SelectedClass, SelectedProperty, rtbDocumentation, ForPrint);
                    AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                    AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                }
            }

            if (SelectedClass.DesignerProperties.Count > 0)
            {
                // Properties --------------------------------------------------------------------------------------------------------------------------------------------------------
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, 10, FontStyle.Regular), Environment.NewLine + "DesignerProperties");
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + _ResourceManager.GetString("Name") + "\t" + _ResourceManager.GetString("Description"));

                foreach (DesignerProperty SelectedProperty in SelectedClass.DesignerProperties)
                {
                    AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + SelectedProperty.Key + "\t");
                    AppendHTML(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedProperty.List[SelectedComment]);
                }

                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);

                foreach (DesignerProperty SelectedProperty in SelectedClass.DesignerProperties)
                {
                    DocumentDesignerProperty(SelectedClass, SelectedProperty, rtbDocumentation, ForPrint);
                    AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                    AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                }
            }

            if (SelectedClass.Fields.Count > 0)
            {
                // Fields ------------------------------------------------------------------------------------------------------------------------------------------------------------
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, 10, FontStyle.Regular), Environment.NewLine + _ResourceManager.GetString("Fields"));
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + _ResourceManager.GetString("Name") + "\t" + _ResourceManager.GetString("Description"));
                foreach (Field SelectedField in SelectedClass.Fields)
                {
                    AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + SelectedField.Name + "\t");
                    AppendHTML(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedField.Comments[SelectedComment].Text);
                }
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);

                foreach (Field SelectedField in SelectedClass.Fields)
                {
                    DocumentField(SelectedClass, SelectedField, rtbDocumentation, ForPrint);
                    AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                    AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                }
            }

            if (SelectedClass.Events.Count > 0)
            {
                // Fields ------------------------------------------------------------------------------------------------------------------------------------------------------------
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, 10, FontStyle.Regular), Environment.NewLine + _ResourceManager.GetString("Events"));
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + _ResourceManager.GetString("Name"));
                foreach (Event SelectedEvent in SelectedClass.Events)
                {
                    AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + SelectedEvent.Name);
                }
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            }

            if (SelectedClass.Permissions.Count > 0)
            {
                // Fields ------------------------------------------------------------------------------------------------------------------------------------------------------------
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, 10, FontStyle.Regular), Environment.NewLine + _ResourceManager.GetString("Permissions"));
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + _ResourceManager.GetString("Name"));
                foreach (Permission SelectedPermission in SelectedClass.Permissions)
                {
                    AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + SelectedPermission.Name);
                }
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            }

            TargetRTB.SelectionStart = 0;
            TargetRTB.SelectionLength = 0;
            TargetRTB.ScrollToCaret();
            TargetRTB.EndUpdate();
            TargetRTB.Refresh();

            Status.Text = _ResourceManager.GetString("Idle");
        }

        private void DocumentField(Class SelectedClass, Field SelectedField, HtmlRichTextBox TargetRTB, bool ForPrint)
        {
            int SelectedComment = 0;

            TargetRTB.BeginUpdate();

            if (ForPrint) Status.Text = _ResourceManager.GetString("Documenting") + " " + SelectedClass.ShortName.InnerText + "." + SelectedField.Name;
            StatusBar.Refresh();

            if (Properties.Settings.Default.ShowFullTypeName)
                AppendText(TargetRTB, Color.FromArgb(43, 145, 175), new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedClass.ShortName.InnerText + ".");

            AppendText(TargetRTB, Color.FromArgb(43, 145, 175), new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedField.Name);
            if (SelectedField.DesignerName != "")
            {
                AppendText(TargetRTB, Color.FromArgb(43, 145, 175), new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), " (DesignerName: " + SelectedField.DesignerName + ")");
            }
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("Type"));
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + _ResourceManager.GetString("Field"));
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("Description"));
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendHTML(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + SelectedField.Comments[SelectedComment].Text);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("Syntax"));
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);

            if (SelectedField.DesignerName != "")
            {
                AppendText(TargetRTB, Color.FromArgb(43, 145, 175), new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedField.DesignerName);
            }
            else
            {
                AppendText(TargetRTB, Color.FromArgb(43, 145, 175), new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedField.Name);
            }

            if (Properties.Settings.Default.ShowEmptyParentheses)
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), "()");

            if ((SelectedField.ReturnType.EndsWith("void") & Properties.Settings.Default.ShowVoidInUsage) | !SelectedField.ReturnType.EndsWith("void"))
            {
                AppendText(TargetRTB, Color.Blue, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), " As ");
                AppendText(TargetRTB, Color.FromArgb(43, 145, 175), new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), TypeName(SelectedField.ReturnType));
            }

            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("ReturnValue"));
            AppendText(TargetRTB, Color.FromArgb(43, 145, 175), new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + TypeName(SelectedField.ReturnType));
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);

            if (ForPrint)
            {
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("Remarks"));
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("Example"));
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("VersionApplicability"));
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("SeeAlso"));
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            }

            TargetRTB.SelectionStart = 0;
            TargetRTB.SelectionLength = 0;
            TargetRTB.ScrollToCaret();
            TargetRTB.EndUpdate();
            TargetRTB.Refresh();

            TargetRTB.AllowDrop = true;
            //TargetRTB.BackColor = Color.AliceBlue;
        }

        private void DocumentMethod(Class SelectedClass, Method SelectedMethod, HtmlRichTextBox TargetRTB, bool ForPrint)
        {
            int SelectedComment = 0;
            int Counter = 0;

            TargetRTB.BeginUpdate();

            if (ForPrint)
            {
                Status.Text = _ResourceManager.GetString("Documenting") + " " + SelectedClass.ShortName.InnerText + "." + SelectedMethod.Name;
            }

            StatusBar.Refresh();

            if (Properties.Settings.Default.ShowFullTypeName)
            {
                AppendText(TargetRTB, Color.DarkMagenta, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedClass.ShortName.InnerText + ".");
            }

            AppendText(TargetRTB, Color.DarkMagenta, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedMethod.Name);

            if (SelectedMethod.DesignerName != "")
            {
                AppendText(TargetRTB, Color.DarkMagenta, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), " (DesignerName: " + SelectedMethod.DesignerName + ")");
            }

            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("Type"));
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + _ResourceManager.GetString("Method"));
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("Description"));
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendHTML(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + SelectedMethod.Comments[SelectedComment].Text);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("Syntax"));
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);

            if (SelectedMethod.DesignerName != "")
            {
                AppendText(TargetRTB, Color.DarkMagenta, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedMethod.DesignerName);
            }
            else
            {
                AppendText(TargetRTB, Color.DarkMagenta, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedMethod.Name);
            }

            if ((Properties.Settings.Default.ShowEmptyParentheses) | (SelectedMethod.Parameters.Count == 1 && SelectedMethod.Parameters[0].Type.ToLower() != "anywheresoftware.b4a.ba") | SelectedMethod.Parameters.Count > 1)
            {
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), "(");

                foreach (Parameter Parameter in SelectedMethod.Parameters)
                {
                    Counter += 1;
                    if (Properties.Settings.Default.HideBAObjectIfFirstParameter && Parameter.Type.ToLower() == "anywheresoftware.b4a.ba")
                    {
                    }
                    else
                    {
                        AppendText(TargetRTB, Color.Purple, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Parameter.Name);

                        AppendText(TargetRTB, Color.Blue, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), " As ");
                        AppendText(TargetRTB, Color.FromArgb(43, 145, 175), new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), TypeName(Parameter.Type));

                        if (Counter < SelectedMethod.Parameters.Count)
                        {
                            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), ", ");
                        }
                    }
                }

                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), ")");

            }

            if ((SelectedMethod.ReturnType.EndsWith("void") & Properties.Settings.Default.ShowVoidInUsage) | (!SelectedMethod.ReturnType.EndsWith("void") && SelectedMethod.ReturnType != ""))
            {
                AppendText(TargetRTB, Color.Blue, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), " As ");
                AppendText(TargetRTB, Color.FromArgb(43, 145, 175), new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), TypeName(SelectedMethod.ReturnType));
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("ReturnValue"));
                AppendText(TargetRTB, Color.FromArgb(43, 145, 175), new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + TypeName(SelectedMethod.ReturnType));
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            }


            if (ForPrint)
            {
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("Remarks"));
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("Example"));
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("VersionApplicability"));
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("SeeAlso"));
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            }


            TargetRTB.SelectionStart = 0;
            TargetRTB.SelectionLength = 0;
            TargetRTB.ScrollToCaret();
            TargetRTB.EndUpdate();
            TargetRTB.Refresh();

            TargetRTB.AllowDrop = true;
            //TargetRTB.BackColor = Color.AliceBlue;
        }

        private void DocumentNode(TreeNode Node, Class SelectedClass, HtmlRichTextBox TargetRTB)
        {
            TargetRTB.Clear();
            TargetRTB.ResetText();
            TargetRTB.Rtf = "";

            if (Node != null)
            {
                switch (Node.ImageIndex)
                {
                    case 0:  // Class
                    case 18:
                    case 19:
                        Class selectedClass = (Class)Node.Tag;

                        DocumentClass(SelectedClass, TargetRTB, false);

                        break;
                    case 2:  // Method
                    case 21: // Method - Commented
                    case 24: // Method - with errors
                        Method SelectedMethod = (Method)Node.Tag;

                        DocumentMethod(SelectedClass, SelectedMethod, TargetRTB, false);

                        break;
                    case 4:  // Property
                    case 23:
                        Property SelectedProperty = (Property)Node.Tag;

                        // This next line is called to document a property during normal usage
                        DocumentProperty(SelectedClass, SelectedProperty, TargetRTB, false);

                        break;
                    case 12:  // DesignerProperty
                        DesignerProperty SelectedDesignerProperty = (DesignerProperty)Node.Tag;

                        // This next line is called to document a designerproperty during normal usage
                        DocumentDesignerProperty(SelectedClass, SelectedDesignerProperty, TargetRTB, false);

                        break;
                    case 1:  // Field
                    case 20:
                        Field SelectedField = (Field)Node.Tag;

                        DocumentField(SelectedClass, SelectedField, TargetRTB, false);

                        break;
                }
            }

            TargetRTB.Update();
        }

        private void DocumentProperty(Class SelectedClass, Property SelectedProperty, HtmlRichTextBox TargetRTB, bool ForPrint)
        {
            int SelectedComment = 0;
            int Counter = 0;

            TargetRTB.BeginUpdate();

            if (ForPrint)
            {
                Status.Text = _ResourceManager.GetString("Documenting") + " " + SelectedClass.ShortName.InnerText + "." + SelectedProperty.Name;
            }

            StatusBar.Refresh();
            Application.DoEvents();

            if (Properties.Settings.Default.ShowFullTypeName)
            {
                AppendText(TargetRTB, Color.SlateGray, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedClass.ShortName.InnerText + ".");
            }

            AppendText(TargetRTB, Color.SlateGray, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedProperty.Name);

            if (SelectedProperty.DesignerName != "")
            {
                AppendText(TargetRTB, Color.SlateGray, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), " (DesignerName: " + SelectedProperty.DesignerName + ")");
            }

            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("Type"));
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + _ResourceManager.GetString("Property"));
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("Description"));
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendHTML(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + SelectedProperty.Comments[SelectedComment].Text);

            if (SelectedProperty.ReadWrite)
            {
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("PropertyIsReadWrite"));
            }
            else
            {
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("PropertyIsReadOnly"));
            }

            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("Syntax"));
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);

            if (SelectedProperty.DesignerName != "")
            {
                AppendText(TargetRTB, Color.SlateGray, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedProperty.DesignerName);
            }
            else
            {
                AppendText(TargetRTB, Color.SlateGray, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedProperty.Name);
            }

            if ((SelectedProperty.Parameters.Count > 0) | Properties.Settings.Default.ShowEmptyParentheses)
            {
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), "(");

                foreach (Parameter Parameter in SelectedProperty.Parameters)
                {
                    Counter += 1;
                    AppendText(TargetRTB, Color.Purple, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Parameter.Name);
                    AppendText(TargetRTB, Color.Blue, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), " As ");
                    AppendText(TargetRTB, Color.FromArgb(43, 145, 175), new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), TypeName(Parameter.Type));

                    if (Counter < SelectedProperty.Parameters.Count)
                    {
                        AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), ", ");
                    }
                }
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), ")");
            }

            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("ReturnValue"));
            AppendText(TargetRTB, Color.FromArgb(43, 145, 175), new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + TypeName(SelectedProperty.ReturnType));
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);

            if (ForPrint)
            {
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("Remarks"));
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("Example"));
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("VersionApplicability"));
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("SeeAlso"));
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            }

            TargetRTB.SelectionStart = 0;
            TargetRTB.SelectionLength = 0;
            TargetRTB.ScrollToCaret();
            TargetRTB.EndUpdate();
            TargetRTB.Refresh();

            TargetRTB.AllowDrop = true;
            //TargetRTB.BackColor = Color.AliceBlue;
        }

        private void DocumentDesignerProperty(Class SelectedClass, DesignerProperty SelectedProperty, HtmlRichTextBox TargetRTB, bool ForPrint)
        {
            TargetRTB.BeginUpdate();

            if (ForPrint)
            {
                Status.Text = _ResourceManager.GetString("Documenting") + " " + SelectedClass.ShortName.InnerText + "." + SelectedProperty.Key;
            }

            StatusBar.Refresh();
            Application.DoEvents();

            if (Properties.Settings.Default.ShowFullTypeName)
            {
                AppendText(TargetRTB, Color.SlateGray, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedClass.ShortName.InnerText + ".");
            }

            AppendText(TargetRTB, Color.SlateGray, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedProperty.Key);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);

            if (SelectedProperty.DisplayName != "")
            {
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), "Display Name");
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedProperty.DisplayName);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            }

            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("Type"));
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + "DesignerProperty");
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            //AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("Description"));
            //AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            //AppendHTML(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine + SelectedProperty.List[0].Text);

            // Designer properties are always read write
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), Environment.NewLine + _ResourceManager.GetString("PropertyIsReadWrite"));
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), "Default value");
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedProperty.DefaultValue);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), "Field Type");
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedProperty.FieldType);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);

            if (SelectedProperty.MinRange != "")
            {
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), "Min Range");
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedProperty.MinRange);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            }

            if (SelectedProperty.MaxRange != "")
            {
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), "Max Range");
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), SelectedProperty.MaxRange);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            }

            if (SelectedProperty.List.Count > 0)
            {
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Bold), "List");
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);

                foreach (string List in SelectedProperty.List)
                {
                    AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), List);
                    AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
                }
                AppendText(TargetRTB, Color.Black, new Font(TargetRTB.Font.FontFamily, TargetRTB.Font.Size, FontStyle.Regular), Environment.NewLine);
            }

            TargetRTB.SelectionStart = 0;
            TargetRTB.SelectionLength = 0;
            TargetRTB.ScrollToCaret();
            TargetRTB.EndUpdate();
            TargetRTB.Refresh();

            TargetRTB.AllowDrop = true;
            //TargetRTB.BackColor = Color.AliceBlue;
        }

        private void DoDropSnippet(object sender, DragEventArgs e)
        {
            string stringData = "";

            if (e != null)
            {
                stringData = e.Data.GetData(typeof(string)) as string;
            }

            frmSnippet SnippetForm = new frmSnippet();

            SnippetForm.Snippet = stringData;
            SnippetForm.SnippetName = _SelectedObjectName + " Snippet " + cmbSnippets.Items.Count.ToString();
            SnippetForm.ObjectName = _SelectedObjectName;
            SnippetForm.SaveRoot = System.IO.Path.Combine(_SaveRoot, _SelectedObjectName).Replace(".", @"\");

            SnippetForm.ShowDialog();

            cmbSnippets.Items.Clear();

            ComboBoxItem Item = new ComboBoxItem();

            Item.Text = _ResourceManager.GetString("Comment");
            Item.EnglishText = "Comment";
            cmbSnippets.Items.Add(Item);

            GetCodeSnippets();

            cmbSnippets.SelectedIndex = cmbSnippets.Items.Count - 1;
        }

        private void DoExit()
        {
            SaveScreenLayout();
            SaveSettings();

            //notifyIcon.Visible = false;
            //notifyIcon.Dispose();

            try
            {
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                Debug.Print(e.InnerException.ToString());
            }
        }

        private void DoOptions()
        {
            frmOptions OptionsForm = new frmOptions(Properties.Settings.Default.UIFontSize);

            try
            {
                OptionsForm.Visible = false;
                OptionsForm.ShowDialog();
            }
            catch
            {
                // Sometimes there is an error switching locales
            }

            UpdateUIControls();

            ResetScreenElements();

            LoadScreenLayout();

            if (OptionsForm.ChangeInOptions)
            {
                if (_SearchMode)
                {
                    DoSearch();
                }
                else
                {
                    LoadXMLFiles();
                }
            }
        }

        private void DoSearch()
        {
            if (txtSearch.Text.Trim() != _ResourceManager.GetString("SearchText"))
            {

                _SearchMode = true;
                ResetClassScreenElements();
                tvwClasses.BeginUpdate();
                tvwClasses.Nodes.Clear();

                Cursor.Current = Cursors.WaitCursor;

                foreach (Library SelectedLibrary in _Libraries)
                {
                    if (SelectedLibrary.Name.InnerText.ToLower().Contains(txtSearch.Text.ToLower()))
                    {
                        AddToTreeview(SelectedLibrary, false);
                    }

                    foreach (Annotation LibraryAnnotation in SelectedLibrary.Annotations)
                    {
                        if (LibraryAnnotation.Value.ToLower().Contains(txtSearch.Text.ToLower()) | LibraryAnnotation.Name.ToLower().Contains(txtSearch.Text.ToLower()))
                        {
                            AddToTreeview(LibraryAnnotation, false);
                        }
                    }

                    foreach (Class SelectedClass in SelectedLibrary.Classes)
                    {
                        if (SelectedClass.Name.InnerText.ToLower().Contains(txtSearch.Text.ToLower()))
                        {
                            AddToTreeview(SelectedClass, false);
                        }
                        if (SelectedClass.Owner.InnerText.ToLower().Contains(txtSearch.Text.ToLower()))
                        {
                            AddToTreeview(SelectedClass, false);
                        }
                        if (SelectedClass.ShortName.InnerText.ToLower().Contains(txtSearch.Text.ToLower()))
                        {
                            AddToTreeview(SelectedClass, false);
                        }
                        foreach (Permission SelectedPermission in SelectedClass.Permissions)
                        {
                            if (SelectedPermission.Name.ToLower().Contains(txtSearch.Text.ToLower()))
                            {
                                AddToTreeview(SelectedPermission, false);
                            }
                        }
                        foreach (Method SelectedMethod in SelectedClass.Methods)
                        {
                            if (SelectedMethod.Name.ToLower().Contains(txtSearch.Text.ToLower()) || SelectedMethod.DesignerName.ToLower().Contains(txtSearch.Text.ToLower()))
                            {
                                AddToTreeview(SelectedMethod, false);
                            }
                            foreach (Comment SelectedComment in SelectedMethod.Comments)
                            {
                                if (SelectedComment.Text.ToLower().Contains(txtSearch.Text.ToLower()))
                                {
                                    AddToTreeview(SelectedMethod, false);
                                }
                            }
                            foreach (Parameter SelectedParameter in SelectedMethod.Parameters)
                            {
                                if (SelectedParameter.Name.ToLower().Contains(txtSearch.Text.ToLower()))
                                {
                                    AddToTreeview(SelectedParameter, false);
                                }
                            }
                        }
                        foreach (Property SelectedProperty in SelectedClass.Properties)
                        {
                            if (SelectedProperty.Name.ToLower().Contains(txtSearch.Text.ToLower()) || SelectedProperty.DesignerName.ToLower().Contains(txtSearch.Text.ToLower()))
                            {
                                AddToTreeview(SelectedProperty, false);
                            }
                            foreach (Comment SelectedComment in SelectedProperty.Comments)
                            {
                                if (SelectedComment.Text.ToLower().Contains(txtSearch.Text.ToLower()))
                                {
                                    AddToTreeview(SelectedProperty, false);
                                }
                            }
                            // Note this doesn't work as property Parameters haven't been implemented properly
                            //foreach (Parameter SelectedParameter in SelectedProperty.Parameters)
                            //{
                            //    if (SelectedParameter.Name.ToLower().Contains(txtSearch.Text.ToLower()))
                            //    {
                            //        //AddToTreeview(SelectedParameter);
                            //    }
                            //}
                        }
                        foreach (DesignerProperty SelectedDesignerProperty in SelectedClass.DesignerProperties)
                        {
                            if (SelectedDesignerProperty.Key.ToLower().Contains(txtSearch.Text.ToLower()) || SelectedDesignerProperty.DisplayName.ToLower().Contains(txtSearch.Text.ToLower()))
                            {
                                AddToTreeview(SelectedDesignerProperty, false);
                            }
                            //foreach (Comment SelectedComment in SelectedDesignerProperty.Comments)
                            //{
                            //    if (SelectedComment.Text.ToLower().Contains(txtSearch.Text.ToLower()))
                            //    {
                            //        AddToTreeview(SelectedDesignerProperty, false);
                            //    }
                            //}
                            // Note this doesn't work as property Parameters haven't been implemented properly
                            //foreach (Parameter SelectedParameter in SelectedProperty.Parameters)
                            //{
                            //    if (SelectedParameter.Name.ToLower().Contains(txtSearch.Text.ToLower()))
                            //    {
                            //        //AddToTreeview(SelectedParameter);
                            //    }
                            //}
                        }
                        foreach (Field SelectedField in SelectedClass.Fields)
                        {
                            if (SelectedField.Name.ToLower().Contains(txtSearch.Text.ToLower()) || SelectedField.DesignerName.ToLower().Contains(txtSearch.Text.ToLower()))
                            {
                                AddToTreeview(SelectedField, false);
                            }
                            foreach (Comment SelectedComment in SelectedField.Comments)
                            {
                                if (SelectedComment.Text.ToLower().Contains(txtSearch.Text.ToLower()))
                                {
                                    AddToTreeview(SelectedField, false);
                                }
                            }
                        }

                        foreach (Annotation SelectedAnnotation in SelectedClass.Annotations)
                        {
                            if (SelectedAnnotation.Name.ToLower().Contains(txtSearch.Text.ToLower()) | SelectedAnnotation.Value.ToLower().Contains(txtSearch.Text.ToLower()))
                            {
                                AddToTreeview(SelectedAnnotation, false);
                            }
                        }

                        foreach (Event SelectedEvent in SelectedClass.Events)
                        {
                            if (SelectedEvent.Name.ToLower().Contains(txtSearch.Text.ToLower()))
                            {
                                AddToTreeview(SelectedEvent, false);
                            }
                        }
                    }
                }
                tvwClasses.Sort();
                tvwClasses.EndUpdate();

                // Save the entered text in the AutoComplete list
                if (Properties.Settings.Default.AutoCompleteSelection == null)
                {
                    Properties.Settings.Default.AutoCompleteSelection = new AutoCompleteStringCollection();
                }

                if (Properties.Settings.Default.AutoCompleteSelection.Contains(txtSearch.Text))
                {
                }
                else
                {
                    Properties.Settings.Default.AutoCompleteSelection.Add(txtSearch.Text);
                    Properties.Settings.Default.Save();
                }

                Cursor.Current = Cursors.Default;
            }
        }

        private void GetCodeSnippets()
        {
            bool UpdateIcon = false;

            // Get all snippets
            if (tvwMethodsPropertiesFields.SelectedNode != null)
            {
                string SnippetPath = System.IO.Path.Combine(_SaveRoot, _SelectedObjectName).Replace(".", @"\");

                if (System.IO.Directory.Exists(SnippetPath))
                {
                    foreach (string f in System.IO.Directory.GetFiles(SnippetPath))
                    {
                        ComboBoxItem Item = new ComboBoxItem();

                        Item.Text = System.IO.Path.GetFileNameWithoutExtension(f);
                        Item.EnglishText = Item.Text;
                        cmbSnippets.Items.Add(Item);
                        UpdateIcon = true;
                    }
                }
            }

            picExtraComments.Visible = UpdateIcon;
            btnEditSnippet.Enabled = UpdateIcon;
        }

        private DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = _ResourceManager.GetString("OK");
            buttonCancel.Text = _ResourceManager.GetString("Cancel");
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;

        }

        private void LoadDataFromClass(Class ThisClass, TreeView TargetTreeview)
        {
            ListViewItem ListItem;
            bool ShowMethod = true;
            //Color ForeColour = Color.Black;

            //TargetTreeview.BeginUpdate();

            lvwDetails.Items.Clear();

            #region Comments

            StringBuilder builder = new StringBuilder();

            foreach (Comment ClassComment in ThisClass.Comments)
            {
                builder.AppendLine(ClassComment.Text);
            }

            rtbClassComment.Text = builder.ToString();

            #endregion

            #region Annotations

            foreach (Annotation ClassAnnotation in ThisClass.Annotations)
            {
                ListItem = new ListViewItem(ClassAnnotation.Name);
                ListItem.SubItems.Add(ClassAnnotation.Value);
                lvwDetails.Items.Add(ListItem);
            }

            //lvwDetails.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            ResizeDetailsColumns();

            #endregion

            #region Events

            lvwEvents.Items.Clear();
            lvwPermissions.Items.Clear();

            foreach (Event SelectedEvent in ThisClass.Events)
            {
                if (_SearchMode)
                {
                    if (SelectedEvent.Name.ToLower().Contains(txtSearch.Text.Trim().ToLower()))
                    {
                        ListItem = new ListViewItem(SelectedEvent.Name);
                        ListItem.ForeColor = Color.Black;
                        lvwEvents.Items.Add(ListItem);
                    }
                    else
                    {
                        ListItem = new ListViewItem(SelectedEvent.Name);
                        ListItem.ForeColor = Color.DimGray;
                        lvwEvents.Items.Add(ListItem);
                    }
                }
                else
                {
                    ListItem = new ListViewItem(SelectedEvent.Name);
                    ListItem.ForeColor = Color.Black;
                    lvwEvents.Items.Add(ListItem);
                }
            }

            #endregion

            #region Permissions

            foreach (Permission SelectedPermission in ThisClass.Permissions)
            {
                ListItem = new ListViewItem(TypeName(SelectedPermission.Name));
                ListItem.ForeColor = Color.Black;
                lvwPermissions.Items.Add(ListItem);
            }

            #endregion

            #region Methods

            //TargetTreeview.BeginUpdate();

            if (Properties.Settings.Default.ShowMethods)
            {
                // Methods
                foreach (Method ThisMethod in ThisClass.Methods)
                {
                    // Setup default value, depending upon searching or not
                    if (_SearchMode)
                    {

                        #region Search Mode (True)

                        ShowMethod = false;

                        if (
                            ThisMethod.Name.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                            ThisMethod.DesignerName.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                            ThisMethod.Comments[0].ToString().ToLower().Contains(txtSearch.Text.Trim().ToLower())
                           )
                        {
                            // Handle Class_Globals setting
                            if (ThisMethod.Name.ToLower() == "class_globals" || ThisMethod.DesignerName.ToLower() == "class_globals")
                            {
                                if (ShowClassGlobalToolStripMenuItem.Checked)
                                {
                                    ShowMethod = true;
                                }
                                else
                                {
                                    ShowMethod = false;
                                }
                            }
                            else
                            {
                                ShowMethod = true;
                            }
                            // Handle Property Get and Property Set setting
                            if (ThisMethod.Name.StartsWith("get") || ThisMethod.DesignerName.StartsWith("get") || ThisMethod.Name.StartsWith("set") || ThisMethod.DesignerName.StartsWith("set"))
                            {
                                if (ShowPropertyGetAndSetToolStripMenuItem.Checked)
                                {
                                    ShowMethod = true;
                                }
                                else
                                {
                                    ShowMethod = false;
                                }
                            }
                            else
                            {
                                ShowMethod = true;
                            }

                            // Handle DesignerCreateView setting
                            if (ThisMethod.Name == "_designercreateview")
                            {
                                if (ShowDesignerCreateViewToolStripMenuItem.Checked)
                                {
                                    ShowMethod = true;
                                }
                                else
                                {
                                    ShowMethod = false;
                                }
                            }
                            else
                            {
                                ShowMethod = true;
                            }
                        }

                        #endregion

                    }
                    else
                    {

                        #region Search Mode (False)

                        ShowMethod = true;

                        // Handle Class_Globals setting
                        if (ThisMethod.Name.ToLower() == "class_globals" || ThisMethod.DesignerName.ToLower() == "class_globals")
                        {
                            if (ShowClassGlobalToolStripMenuItem.Checked)
                            {
                                ShowMethod = true;
                            }
                            else
                            {
                                ShowMethod = false;
                            }
                        }

                        // Handle Property Get and Property Set setting
                        if (ThisMethod.Name.StartsWith("get") || ThisMethod.DesignerName.StartsWith("get") || ThisMethod.Name.StartsWith("set") || ThisMethod.DesignerName.StartsWith("set"))
                        {
                            if (ShowPropertyGetAndSetToolStripMenuItem.Checked)
                            {
                                ShowMethod = true;
                            }
                            else
                            {
                                ShowMethod = false;
                            }
                        }

                        // Handle DesignerCreateView setting
                        if (ThisMethod.Name == "_designercreateview" || ThisMethod.DesignerName == "DesignerCreateView")
                        {
                            if (ShowDesignerCreateViewToolStripMenuItem.Checked)
                            {
                                ShowMethod = true;
                            }
                            else
                            {
                                ShowMethod = false;
                            }
                        }

                        #endregion

                    }

                    TreeNode MethodNode = new TreeNode();

                    if (ThisMethod.DesignerName != "")
                    {
                        MethodNode.Text = ThisMethod.DesignerName;
                    }
                    else
                    {
                        MethodNode.Text = ThisMethod.Name;
                    }

                    MethodNode.Tag = ThisMethod;

                    picExtraComments.Visible = SnippetExists(ThisMethod.Name);
                    btnEditSnippet.Enabled = picExtraComments.Visible;
                    //cmbSnippets.Enabled = picExtraComments.Visible;

                    if (ThisMethod.ReturnType == null || ThisMethod.ReturnType == "")
                    {
                        MethodNode.ImageIndex = 24;
                        MethodNode.SelectedImageIndex = 24;
                        MethodNode.ToolTipText = "This method does not have a ReturnType defined";
                    }
                    else
                    {
                        MethodNode.ImageIndex = 2;
                        MethodNode.SelectedImageIndex = 2;
                        MethodNode.ToolTipText = "";
                    }

                    if (ShowMethod)
                    {
                        MethodNode.ForeColor = Color.Black;
                    }
                    else
                    {
                        MethodNode.ForeColor = Color.DimGray;
                    }

                    TargetTreeview.Nodes.Add(MethodNode);
                    //}
                }
            }

            #endregion

            #region Properties

            if (Properties.Settings.Default.ShowProperties)
            {
                // Properties
                foreach (Property ThisProperty in ThisClass.Properties)
                {
                    TreeNode PropertyNode = new TreeNode();

                    if (ThisProperty.DesignerName != "")
                    {
                        PropertyNode.Text = ThisProperty.DesignerName;
                    }
                    else
                    {
                        PropertyNode.Text = ThisProperty.Name;
                    }

                    PropertyNode.Tag = ThisProperty;

                    picExtraComments.Visible = SnippetExists(ThisProperty.Name);
                    btnEditSnippet.Enabled = picExtraComments.Visible;
                    //cmbSnippets.Enabled = picExtraComments.Visible;

                    PropertyNode.ImageIndex = 4;
                    PropertyNode.SelectedImageIndex = 4;

                    if (_SearchMode)
                    {
                        if (ThisProperty.Name.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                            ThisProperty.DesignerName.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                            ThisProperty.Comments[0].ToString().ToLower().Contains(txtSearch.Text.Trim().ToLower())
                           )
                        {
                            PropertyNode.ForeColor = Color.Black;
                        }
                        else
                        {
                            PropertyNode.ForeColor = Color.DimGray;
                        }
                    }
                    else
                    {
                        PropertyNode.ForeColor = Color.Black;
                    }

                    TargetTreeview.Nodes.Add(PropertyNode);
                    //}
                }
            }

            #endregion

            #region Fields

            if (Properties.Settings.Default.ShowFields)
            {
                // Fields
                foreach (Field ThisField in ThisClass.Fields)
                {
                    TreeNode FieldNode = new TreeNode();

                    if (ThisField.DesignerName != "")
                    {
                        FieldNode.Text = ThisField.DesignerName;
                    }
                    else
                    {
                        FieldNode.Text = ThisField.Name;
                    }

                    FieldNode.Tag = ThisField;

                    picExtraComments.Visible = SnippetExists(ThisField.Name);
                    btnEditSnippet.Enabled = picExtraComments.Visible;
                    //cmbSnippets.Enabled = picExtraComments.Visible;

                    FieldNode.ImageIndex = 1;
                    FieldNode.SelectedImageIndex = 1;

                    if (_SearchMode)
                    {
                        if (
                            ThisField.Name.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                            ThisField.DesignerName.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                            ThisField.Comments[0].ToString().ToLower().Contains(txtSearch.Text.Trim().ToLower())
                           )
                        {
                            FieldNode.ForeColor = Color.Black;
                        }
                        else
                        {
                            FieldNode.ForeColor = Color.DimGray;
                        }
                    }
                    else
                    {
                        FieldNode.ForeColor = Color.Black;
                    }

                    TargetTreeview.Nodes.Add(FieldNode);
                    //}
                }
            }

            #endregion

            // Sort the treeview
            TargetTreeview.Sort();

            #region DesignerProperties

            if (Properties.Settings.Default.ShowDesignerProperties)
            {
                // Add the designer Properties last
                foreach (DesignerProperty ThisProperty in ThisClass.DesignerProperties)
                {
                    TreeNode DesignerPropertyNode = new TreeNode();

                    //if (ThisProperty.DisplayName != "")
                    //{
                    //    DesignerPropertyNode.Text = ThisProperty.DisplayName;
                    //}
                    //else
                    //{
                    DesignerPropertyNode.Text = ThisProperty.Key;
                    //}

                    DesignerPropertyNode.Tag = ThisProperty;

                    DesignerPropertyNode.ImageIndex = 12;
                    DesignerPropertyNode.SelectedImageIndex = 12;

                    if (_SearchMode)
                    {
                        if (ThisProperty.Key.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                            ThisProperty.DisplayName.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                            ThisProperty.Description.ToLower().Contains(txtSearch.Text.Trim().ToLower())
                           )
                        {
                            DesignerPropertyNode.ForeColor = Color.Black;
                        }
                        else
                        {
                            DesignerPropertyNode.ForeColor = Color.DimGray;
                        }
                    }
                    else
                    {
                        DesignerPropertyNode.ForeColor = Color.Black;
                    }

                    TargetTreeview.Nodes.Insert(0, DesignerPropertyNode);
                    //}
                }
            }

            #endregion


            //TargetTreeview.EndUpdate();

        }

        private void LoadExportedSettings()
        {
            if (Properties.Settings.Default.FirstRun)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.FirstRun = false;
                Properties.Settings.Default.Save();

                if (System.IO.File.Exists(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "ExportedSettings.xml")))
                {
                    DialogResult Response = MessageBox.Show(_ResourceManager.GetString("NoApplicationPaths"), _ResourceManager.GetString("PleaseConfirm"), MessageBoxButtons.YesNo);
                    if (Response == System.Windows.Forms.DialogResult.Yes)
                    {
                        SettingsIO.Import(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "ExportedSettings.xml"));
                        ReloadSettings();
                    }
                }
                else
                {
                    ShowOpenFolderDialog();
                }
            }
        }

        private void LoadLibraries()
        {
            int Pathcount = 0;
            int SharedPathCount = 0;

            tvwClasses.BeginUpdate();

            Status.Text = _ResourceManager.GetString("LoadingLibraries");
            this.Refresh();

            Cursor.Current = Cursors.WaitCursor;

            if (Properties.Settings.Default.AdditionalSharedLibraryPaths != null)
            {
                SharedPathCount = Properties.Settings.Default.AdditionalSharedLibraryPaths.Count;
            }

            switch (_SelectedLanguage)
            {
                case Structs.Language.Android:
                    {
                        if (Properties.Settings.Default.AdditionalB4aLibraryPaths != null)
                        {
                            Pathcount = Properties.Settings.Default.AdditionalB4aLibraryPaths.Count;
                        }

                        break;
                    }
                case Structs.Language.IOS:
                    {
                        if (Properties.Settings.Default.AdditionalB4iLibraryPaths != null)
                        {
                            Pathcount = Properties.Settings.Default.AdditionalB4iLibraryPaths.Count;
                        }

                        break;
                    }
                case Structs.Language.Java:
                    {
                        if (Properties.Settings.Default.AdditionalB4jLibraryPaths != null)
                        {
                            Pathcount = Properties.Settings.Default.AdditionalB4jLibraryPaths.Count;
                        }

                        break;
                    }
                case Structs.Language.Arduino:
                    {
                        if (Properties.Settings.Default.AdditionalB4rLibraryPaths != null)
                        {
                            Pathcount = Properties.Settings.Default.AdditionalB4rLibraryPaths.Count;
                        }

                        break;
                    }
            }

            for (int Counter = 0; Counter < SharedPathCount; Counter++)
            {
                //Progress.Style = ProgressBarStyle.Marquee;
                StatusBar.Refresh();

                if (System.IO.Directory.Exists(Properties.Settings.Default.AdditionalSharedLibraryPaths[Counter]))
                {
                    foreach (string Filename in System.IO.Directory.GetFiles(Properties.Settings.Default.AdditionalSharedLibraryPaths[Counter], "*.xml"))
                    {
                        try
                        {
                            LoadXMLFile(Filename);
                        }
                        catch { }
                    }
                }
                else
                {
                    Console.WriteLine("Shared Library folder not found {0}", Properties.Settings.Default.AdditionalSharedLibraryPaths[Counter]);
                }
            }

            for (int Counter = 0; Counter < Pathcount; Counter++)
            {
                //Progress.Style = ProgressBarStyle.Marquee;
                StatusBar.Refresh();

                switch (_SelectedLanguage)
                {
                    case Structs.Language.Android:
                        {
                            if (System.IO.Directory.Exists(Properties.Settings.Default.AdditionalB4aLibraryPaths[Counter]))
                            {
                                foreach (string Filename in System.IO.Directory.GetFiles(Properties.Settings.Default.AdditionalB4aLibraryPaths[Counter], "*.xml"))
                                {
                                    try
                                    {
                                        LoadXMLFile(Filename);
                                    }
                                    catch { }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Library folder not found {0}", Properties.Settings.Default.AdditionalB4aLibraryPaths[Counter]);
                            }

                            break;
                        }
                    case Structs.Language.IOS:
                        {
                            if (System.IO.Directory.Exists(Properties.Settings.Default.AdditionalB4iLibraryPaths[Counter]))
                            {
                                foreach (string Filename in System.IO.Directory.GetFiles(Properties.Settings.Default.AdditionalB4iLibraryPaths[Counter], "*.xml"))
                                {
                                    try
                                    {
                                        LoadXMLFile(Filename);
                                    }
                                    catch { }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Library folder not found {0}", Properties.Settings.Default.AdditionalB4iLibraryPaths[Counter]);
                            }

                            break;
                        }
                    case Structs.Language.Java:
                        {
                            if (System.IO.Directory.Exists(Properties.Settings.Default.AdditionalB4jLibraryPaths[Counter]))
                            {
                                foreach (string Filename in System.IO.Directory.GetFiles(Properties.Settings.Default.AdditionalB4jLibraryPaths[Counter], "*.xml"))
                                {
                                    try
                                    {
                                        LoadXMLFile(Filename);
                                    }
                                    catch { }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Library folder not found {0}", Properties.Settings.Default.AdditionalB4jLibraryPaths[Counter]);
                            }

                            break;
                        }
                    case Structs.Language.Arduino:
                        {
                            if (System.IO.Directory.Exists(Properties.Settings.Default.AdditionalB4rLibraryPaths[Counter]))
                            {
                                foreach (string Filename in System.IO.Directory.GetFiles(Properties.Settings.Default.AdditionalB4rLibraryPaths[Counter], "*.xml"))
                                {
                                    try
                                    {
                                        LoadXMLFile(Filename);
                                    }
                                    catch { }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Library folder not found {0}", Properties.Settings.Default.AdditionalB4rLibraryPaths[Counter]);
                            }

                            break;
                        }
                }
            }

            tvwClasses.EndUpdate();
        }

        private void LoadScreenLayout()
        {
            try
            {
                this.WindowState = Properties.Settings.Default.frmMainWindowState;
                this.Location = Properties.Settings.Default.frmMainLocation;
                this.Width = Properties.Settings.Default.frmMainWidth;
                this.Height = Properties.Settings.Default.frmMainHeight;
            }
            catch { }

            UpdateLabel();  // Update Methods / Properties / Fields label as appropriate

            // Update search list
            txtSearch.AutoCompleteCustomSource = Properties.Settings.Default.AutoCompleteSelection;

            SetLabelVisibility();

            SetMenuInitialValues();

            ShowClassDetails(Properties.Settings.Default.ClassDetailsVisible);
        }

        private void LoadXMLFile(string Filename)
        {
            string ShortFilename = Path.GetFileNameWithoutExtension(Filename);
            TreeNode RootNode;
            Library ThisLibrary = new Library();

            tvwMethodsPropertiesFields.Nodes.Clear();

            // Create Root node for this file
            RootNode = new TreeNode(ShortFilename);

            RootNode.ImageIndex = 3;
            RootNode.SelectedImageIndex = 3;

            RootNode.Name = Filename;

            tvwClasses.Nodes.Add(RootNode);

            ThisLibrary.Path.InnerText = Filename;
            ThisLibrary.Name.InnerText = ShortFilename;
            ThisLibrary.FilePath = Filename;

            RootNode.Tag = ThisLibrary;

            if (!Properties.Settings.Default.LoadXMLOnDemand)
            {
                LoadXMLFileData(Filename, RootNode, ThisLibrary);
            }
        }

        private void LoadXMLFileData(string Filename, TreeNode RootNode, Library ParentLibrary)
        {
            XDocument XMLFile;
            Annotation LibraryAnnotation;
            Annotation ClassAnnotation;
            System.Xml.XmlReader Reader;
            string XMLFileContent = "";
            Comment FileComment = null;

            Reader = System.Xml.XmlReader.Create(new StreamReader(Filename, Encoding.GetEncoding("UTF-8")));
            XMLFile = XDocument.Load(Reader);

            Status.Text = _ResourceManager.GetString("LoadingLibraryFile") + " " + Filename;
            //Progress.Style = ProgressBarStyle.Marquee;

            tvwClasses.BeginUpdate();

            #region Library Author
            //-------------------------------  LIBRARY AUTHOR ---------------------------------
            try
            {
                if (XMLFile.Root.Element("author") != null)
                {
                    ParentLibrary.Author.InnerText = Decode(XMLFile.Root.Element("author").Value);
                }

                LibraryAnnotation = new Annotation(_ResourceManager.GetString("Author"), ParentLibrary.Author.InnerText);
                LibraryAnnotation.ParentLibrary = ParentLibrary;
                ParentLibrary.Annotations.Add(LibraryAnnotation);
            }
            catch
            {
                // Unexpected error 
            }
            #endregion

            #region Library Version
            //-------------------------------  LIBRARY VERSION ---------------------------------
            try
            {
                if (XMLFile.Root.Element("version") != null)
                {
                    ParentLibrary.Version.InnerText = XMLFile.Root.Element("version").Value;

                    LibraryAnnotation = new Annotation(_ResourceManager.GetString("Version"), ParentLibrary.Version.InnerText);
                    LibraryAnnotation.ParentLibrary = ParentLibrary;
                    ParentLibrary.Annotations.Add(LibraryAnnotation);
                }
            }
            catch
            {
                // Unexpected error 
            }
            #endregion

            #region Library Doclet Version
            //-------------------------------  LIBRARY DOCLET VERSION ---------------------------------
            try
            {
                if (XMLFile.Root.Element("doclet-version-NOT-library-version") != null)
                {
                    ParentLibrary.DocletVersion.InnerText = XMLFile.Root.Element("doclet-version-NOT-library-version").Value;

                    LibraryAnnotation = new Annotation(_ResourceManager.GetString("DocletVersionNOTLibraryVersion"), ParentLibrary.DocletVersion.InnerText);
                    LibraryAnnotation.ParentLibrary = ParentLibrary;
                    ParentLibrary.Annotations.Add(LibraryAnnotation);
                }
            }
            catch
            {
                // Unexpected error 
            }
            #endregion

            #region Library DependsOn
            //-------------------------------  LIBRARY DEPENDSON ---------------------------------
            IEnumerable<XElement> DependsOn = XMLFile.Root.Elements("dependsOn").Select(x => x);

            foreach (XElement DependsOnElement in DependsOn)
            {
                try
                {
                    LibraryAnnotation = new Annotation(_ResourceManager.GetString("DependsOn"), DependsOnElement.Value.ToString());
                    LibraryAnnotation.ParentLibrary = ParentLibrary;
                    ParentLibrary.Annotations.Add(LibraryAnnotation);
                }
                catch
                {
                    // Unexpected error 
                }
            }
            #endregion

            #region Library Comment
            //-------------------------------  LIBRARY COMMENT ---------------------------------
            IEnumerable<XElement> LibraryXMLComment = XMLFile.Root.Elements("comment").Select(x => x);

            foreach (XElement LibraryCommentElement in LibraryXMLComment)
            {
                try
                {
                    Comment LibraryComment = new Comment();
                    LibraryComment.Author = "";
                    LibraryComment.Text = LibraryCommentElement.Value.ToString();
                    ParentLibrary.Comments.Add(LibraryComment);
                }
                catch
                {
                    // Unexpected error 
                }
            }
            #endregion

            // Get each class
            IEnumerable<XElement> XMLFileClasses = XMLFile.Root.Elements("class").Select(x => x);

            foreach (XElement XMLFileClassElement in XMLFileClasses)
            {
                Class ThisClass = new Class();

                bool DuplicateClassShortName = false;

                ThisClass.Parent = ParentLibrary;

                StatusBar.Refresh();

                #region Name
                //-------------------------------  NAME ---------------------------------
                try
                {
                    ThisClass.Name.InnerText = XMLFileClassElement.Element("name").Value.ToString();

                    //Console.WriteLine("Loading " + ThisClass.Parent.Name.InnerText + "!" + ThisClass.Name.InnerText + " (" + ThisClass.ShortName.InnerText + ")");

                    ClassAnnotation = new Annotation(_ResourceManager.GetString("Name"), ThisClass.Name.InnerText);
                    ClassAnnotation.ParentClass = ThisClass;
                    ThisClass.Annotations.Add(ClassAnnotation);
                }
                catch
                {
                    // Unexpected error 
                    Exception ex = new Exception("Unexpected error loading Class names");

                }

                #endregion

                #region Class Comment

                //-------------------------------  CLASS COMMENT ---------------------------------
                if (XMLFileClassElement.Element("comment") != null)
                {
                    XMLFileContent = XMLFileClassElement.Element("comment").Value.ToString();
                }

                FileComment = new Comment();

                FileComment.Text = XMLFileContent;

                XMLFileContent = "";
                ThisClass.Comments.Add(FileComment);

                #endregion

                #region Events
                //-------------------------------  EVENTS ---------------------------------
                IEnumerable<XElement> XMLEvents = XMLFileClassElement.Elements("event").Select(x => x);

                foreach (XElement EventXMLElement in XMLEvents)
                {
                    try
                    {
                        Event NewEvent = new Event(EventXMLElement.Value.ToString());
                        NewEvent.Parent = ThisClass;
                        ThisClass.Events.Add(NewEvent);
                    }
                    catch
                    {
                        // Unexpected error 
                    }
                }
                #endregion

                #region Permissions
                //-------------------------------  PERMISSIONS ---------------------------------
                IEnumerable<XElement> Permissions = XMLFileClassElement.Elements("permission").Select(x => x);

                foreach (XElement PermissionElement in Permissions)
                {
                    try
                    {
                        Permission NewPermission = new Permission(PermissionElement.Value.ToString());
                        NewPermission.Parent = ThisClass;
                        ThisClass.Permissions.Add(NewPermission);
                    }
                    catch
                    {
                        // Unexpected error 
                    }
                }
                #endregion

                #region ObjectWrapper
                //-------------------------------  OBJECTWRAPPER ---------------------------------
                try
                {
                    if (XMLFileClassElement.Element("objectwrapper") != null)
                    {
                        if (XMLFileClassElement.Element("objectwrapper").ToString() != "")
                        {
                            ThisClass.ObjectWrapper.InnerText = TypeName(XMLFileClassElement.Element("objectwrapper").Value.ToString());
                        }

                        ClassAnnotation = new Annotation(_ResourceManager.GetString("ObjectWrapper"), ThisClass.ObjectWrapper.InnerText);
                        ClassAnnotation.ParentClass = ThisClass;
                        ThisClass.Annotations.Add(ClassAnnotation);
                    }
                }
                catch
                {
                    // Unexpected error 
                }
                #endregion

                #region Owner
                //-------------------------------  OWNER ---------------------------------
                try
                {
                    if (XMLFileClassElement.Element("owner") != null)
                    {
                        ThisClass.Owner.InnerText = XMLFileClassElement.Element("owner").Value.ToString();  // Class type

                        ClassAnnotation = new Annotation(_ResourceManager.GetString("Owner"), ThisClass.Owner.InnerText);
                        ClassAnnotation.ParentClass = ThisClass;
                        ThisClass.Annotations.Add(ClassAnnotation);

                        if (XMLFileClassElement.Element("owner").Attribute("CheckForReinitialize") != null)
                        {
                            ThisClass.OwnerIsSetToCheckForInitialize = Convert.ToBoolean(XMLFileClassElement.Element("owner").Attribute("CheckForReinitialize").Value.ToString());  // Class type

                            ClassAnnotation = new Annotation("Owner: Check For Reinitialize", ThisClass.OwnerIsSetToCheckForInitialize.ToString());
                            ClassAnnotation.ParentClass = ThisClass;
                            ThisClass.Annotations.Add(ClassAnnotation);
                        }
                    }
                }
                catch
                {
                    Exception ex = new Exception("Unexpected error loading Class Owner");
                }
                #endregion

                #region Shortname
                //-------------------------------  SHORTNAME ---------------------------------
                try
                {
                    if (XMLFileClassElement.Element("shortname") != null)
                    {
                        ThisClass.ShortName.InnerText = XMLFileClassElement.Element("shortname").Value.ToString();

                        //Console.WriteLine("    Shortname:" + ThisClass.ShortName.InnerText);

                        ClassAnnotation = new Annotation(_ResourceManager.GetString("ShortName"), ThisClass.ShortName.InnerText);
                        ClassAnnotation.ParentClass = ThisClass;
                        ThisClass.Annotations.Add(ClassAnnotation);
                    }
                    else
                    {
                        // No shortname, so use name instead
                        ThisClass.ShortName.InnerText = XMLFileClassElement.Element("name").Value.ToString();

                        //Console.WriteLine("    Shortname:" + ThisClass.ShortName.InnerText);

                    }
                }
                catch
                {
                    // Unexpected error 
                    Exception ex = new Exception("Unexpected error loading Class Short name");
                }
                #endregion

                #region Methods
                //-------------------------------  METHODS ---------------------------------
                IEnumerable<XElement> Methods = XMLFileClassElement.Elements("method").Select(x => x);

                foreach (XElement XMLFileMethodElement in Methods)
                {
                    Method ThisMethod = new Method();

                    ThisMethod.Parent = ThisClass;
                    ThisMethod.Name = XMLFileMethodElement.Element("name").Value.ToString();

                    ThisMethod.DesignerName = "";

                    if (XMLFileMethodElement.Element("name").HasAttributes)
                    {
                        try
                        {
                            if (XMLFileMethodElement.Element("name").Attribute("DesignerName") != null)
                            {
                                if (XMLFileMethodElement.Element("name").Attribute("DesignerName").Value.ToString() != "")
                                {
                                    ThisMethod.DesignerName = XMLFileMethodElement.Element("name").Attribute("DesignerName").Value.ToString();
                                }
                            }
                        }
                        catch { }
                    }

                    if (XMLFileMethodElement.Element("comment") != null)
                    {
                        XMLFileContent = XMLFileMethodElement.Element("comment").Value.ToString();
                    }

                    FileComment = new Comment();

                    FileComment.Text = XMLFileContent;

                    XMLFileContent = "";
                    ThisMethod.Comments.Add(FileComment);

                    var ReturnTypeElement = XMLFileMethodElement.Element("returntype");

                    if (ReturnTypeElement != null && ReturnTypeElement.Value != null)
                    {
                        ThisMethod.ReturnType = ReturnTypeElement.Value.ToString();
                    }

                    // Now to read Attributes (if any)

                    IEnumerable<XElement> Parameters = XMLFileMethodElement.Elements("parameter").Select(x => x);

                    // Finally, read Parameters
                    foreach (XElement XMLFileParameterElement in Parameters)
                    {
                        Parameter ThisParameter = new Parameter();
                        ThisParameter.Name = XMLFileParameterElement.Element("name").Value.ToString();
                        ThisParameter.Type = XMLFileParameterElement.Element("type").Value.ToString();
                        ThisParameter.Parent = ThisMethod;

                        ThisMethod.Parameters.Add(ThisParameter);
                    }

                    ThisClass.Methods.Add(ThisMethod);

                }

                ThisClass.Methods.Sort();

                #endregion

                #region Properties

                //-------------------------------  PROPERTIES ---------------------------------
                IEnumerable<XElement> Properties = XMLFileClassElement.Elements("property").Select(x => x);

                foreach (XElement XMLFilePropertyElement in Properties)
                {
                    Property ThisProperty = new Property();

                    ThisProperty.Parent = ThisClass;

                    ThisProperty.Name = XMLFilePropertyElement.Element("name").Value.ToString();

                    ThisProperty.DesignerName = "";

                    if (XMLFilePropertyElement.Element("name").HasAttributes)
                    {
                        if (XMLFilePropertyElement.Element("name").Attribute("DesignerName") != null)
                        {
                            if (XMLFilePropertyElement.Element("name").Attribute("DesignerName").Value.ToString() != "")
                            {
                                ThisProperty.DesignerName = XMLFilePropertyElement.Element("name").Attribute("DesignerName").Value.ToString();
                            }
                        }
                    }

                    if (XMLFilePropertyElement.Element("comment") != null)
                    {
                        XMLFileContent = XMLFilePropertyElement.Element("comment").Value.ToString();
                    }

                    FileComment = new Comment();

                    FileComment.Text = XMLFileContent;

                    XMLFileContent = "";
                    ThisProperty.Comments.Add(FileComment);

                    if (XMLFilePropertyElement.Element("returntype") != null)
                    {
                        ThisProperty.ReturnType = XMLFilePropertyElement.Element("returntype").Value.ToString();
                    }

                    IEnumerable<XElement> parameters = XMLFilePropertyElement.Elements("parameter").Select(x => x);

                    foreach (XElement ParameterElement in parameters)
                    {
                        Parameter ThisParameter = new Parameter();
                        ThisParameter.Name = ParameterElement.Element("name").Value.ToString();
                        ThisParameter.Type = ParameterElement.Element("type").Value.ToString();

                        ThisProperty.Parameters.Add(ThisParameter);
                    }
                    ThisProperty.Parameters.Sort();

                    ThisClass.Properties.Add(ThisProperty);
                }

                ThisClass.Properties.Sort();

                #endregion

                #region DesignerProperties

                //-------------------------------  DESIGNER PROPERTIES ---------------------------------
                IEnumerable<XElement> DesignerProperties = XMLFileClassElement.Elements("designerProperty").Select(x => x);

                foreach (XElement XMLFileDesignerPropertyElement in DesignerProperties)
                {
                    DesignerProperty ThisDesignerProperty = new DesignerProperty();

                    ThisDesignerProperty.Parent = ThisClass;

                    string DesignerPropertyValue = XMLFileDesignerPropertyElement.Value;

                    string[] Propertyvalues = DesignerPropertyValue.Split(',');

                    foreach (string p in Propertyvalues)
                    {
                        string PropertyName = p.Substring(0, p.IndexOf(':'));
                        string PropertyValue = p.Substring(p.IndexOf(':') + 1);

                        switch (PropertyName.ToLower().Trim())
                        {
                            case "key":
                                ThisDesignerProperty.Key = PropertyValue;
                                break;
                            case "displayname":
                                ThisDesignerProperty.DisplayName = PropertyValue;
                                break;
                            case "list":
                                List<string> s = PropertyValue.Split('|').ToList<string>();
                                ThisDesignerProperty.List.Sort();
                                break;
                            case "defaultvalue":
                                ThisDesignerProperty.DefaultValue = PropertyValue;
                                break;
                            case "description":
                                ThisDesignerProperty.Description = PropertyValue;
                                break;
                            case "fieldtype":
                                ThisDesignerProperty.FieldType = PropertyValue;
                                break;
                            case "minrange":
                                ThisDesignerProperty.MinRange = PropertyValue;
                                break;
                            case "maxrange":
                                ThisDesignerProperty.MaxRange = PropertyValue;
                                break;
                            default:
                                break;
                        }
                    }

                    ThisClass.DesignerProperties.Add(ThisDesignerProperty);
                }

                #endregion

                #region Fields

                //-------------------------------  FIELDS ---------------------------------
                IEnumerable<XElement> fields = XMLFileClassElement.Elements("field").Select(x => x);

                foreach (XElement FieldElement in fields)
                {
                    Field ThisField = new Field();

                    ThisField.Parent = ThisClass;

                    ThisField.Name = FieldElement.Element("name").Value.ToString();

                    ThisField.DesignerName = "";

                    if (FieldElement.Element("name").HasAttributes)
                    {
                        if (FieldElement.Element("name").Attribute("DesignerName").Value.ToString() != "")
                        {
                            ThisField.DesignerName = FieldElement.Element("name").Attribute("DesignerName").Value.ToString();
                        }
                    }

                    ThisField.ReturnType = FieldElement.Element("returntype").Value.ToString();

                    if (FieldElement.Element("comment") != null)
                    {
                        XMLFileContent = FieldElement.Element("comment").Value.ToString();
                    }

                    FileComment = new Comment();

                    FileComment.Text = XMLFileContent;

                    XMLFileContent = "";
                    ThisField.Comments.Add(FileComment);

                    ThisClass.Fields.Add(ThisField);
                }

                ThisClass.Fields.Sort();

                #endregion

                TreeNode ClassNode = new TreeNode();

                ClassNode.Text = ThisClass.ShortName.InnerText;
                ClassNode.Tag = ThisClass;
                ClassNode.Name = ThisClass.ShortName.InnerText;
                ClassNode.ImageIndex = 0;
                ClassNode.SelectedImageIndex = 0;

                // Loop through all classes to see if there is already a class with the same shortname
                foreach (Class ExistingClass in Classes)
                {
                    if (ExistingClass.ShortName.InnerText != null && ThisClass.ShortName.InnerText != null)
                    {
                        if (ExistingClass.ShortName.InnerText.ToLower() == ThisClass.ShortName.InnerText.ToLower())
                        {
                            DuplicateClassShortName = true;

                            ClassNode.ImageIndex = 18;
                            ClassNode.SelectedImageIndex = 18;
                            ClassNode.ToolTipText = _ResourceManager.GetString("DuplicateClassName").Replace("<PARENTNAME>", ExistingClass.Parent.Name.InnerText).Replace("<SHORTNAME>", ExistingClass.ShortName.InnerText);
                        }
                    }
                }

                RootNode.Nodes.Add(ClassNode);

                ParentLibrary.Classes.Add(ThisClass);

                Classes.Add(ThisClass);

                if (DuplicateClassShortName)
                {
                    ClassNode.Parent.ImageIndex = 17;
                    ClassNode.Parent.SelectedImageIndex = 17;
                    ClassNode.Parent.ToolTipText = _ResourceManager.GetString("DuplicateClassNameInLibrary");
                }
            }

            tvwClasses.Sort();
            tvwClasses.EndUpdate();

            Classes.Sort();
            Reader.Close();
            XMLFile = null;
            Reader = null;

            _Libraries.Add(ParentLibrary);

            RootNode.Tag = ParentLibrary;

            Status.Text = _ResourceManager.GetString("Idle");
            //Progress.Style = ProgressBarStyle.Blocks;
            //Progress.Value = 0;
        }

        private void LoadXMLFiles()
        {
            tvwClasses.Nodes.Clear();
            tvwMethodsPropertiesFields.Nodes.Clear();
            lvwDetails.Items.Clear();
            lvwEvents.Items.Clear();
            lvwPermissions.Items.Clear();
            Classes.Clear();
            _Libraries.Clear();

            Cursor.Current = Cursors.WaitCursor;

            LoadLibraries();

            //Progress.Style = ProgressBarStyle.Blocks;
            //Progress.Value = 0;
            tvwClasses.Sort();
            Status.Text = _ResourceManager.GetString("Idle");
            Cursor.Current = Cursors.Default;
        }

        private void OpenSite(string URL)
        {
            ProcessStartInfo ProcessInfo = new ProcessStartInfo();

            ProcessInfo.FileName = URL;
            ProcessInfo.UseShellExecute = true;

            System.Diagnostics.Process.Start(ProcessInfo);
        }

        private void OpenFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = folderPath,
                    FileName = "explorer.exe"
                };

                Process.Start(startInfo);
            }
            else
            {
                MessageBox.Show($"{folderPath} Directory does not exist!");
            }
        }

        private void OpenApplication(string FilePath)
        {
            Process p = new Process();

            ProcessStartInfo s = new ProcessStartInfo(FilePath)
            {
                UseShellExecute = true
            };

            p.StartInfo = s;

            p.Start();
        }

        private void PerformSiteSearch(string Term)
        {
            ProcessStartInfo ProcessInfo = new ProcessStartInfo();

            ProcessInfo.FileName = "http://www.google.com/search?as_q=" + Term + "&as_sitesearch=b4x.com";
            ProcessInfo.UseShellExecute = true;

            System.Diagnostics.Process.Start(ProcessInfo);
        }

        private void ReloadSettings()
        {
            txtSearch.Text = _ResourceManager.GetString("SearchText");
            _SearchMode = false;

            ResetScreenElements();
            LoadXMLFiles();
        }

        private void ResetClassScreenElements()
        {
            tvwMethodsPropertiesFields.Nodes.Clear();
            rtbClassComment.Enabled = true;

            ResetScreenElements();
        }

        private void ResetLibraryScreenElements()
        {
            lvwDetails.Items.Clear();
            rtbClassComment.Text = "";
            rtbClassComment.Enabled = false;
            lvwPermissions.Items.Clear();
            lvwEvents.Items.Clear();
            ResetScreenElements();
        }

        private void ResetMPFScreenElements()
        {
            rtbClassComment.Clear();
            rtbClassComment.AllowDrop = false;

            btnAddSnippet.Enabled = true;
            btnRemoveSnippet.Enabled = false;
            tlpCommentSnippets.AllowDrop = false;
            btnAddSnippet.AllowDrop = false;
            btnRemoveSnippet.AllowDrop = false;
        }

        private void ResetScreenElements()
        {
            rtbClassComment.AllowDrop = false;
            rtbClassComment.BackColor = Color.White;

            rtbClassComment.Clear();

            //picExtraComments.Visible = false;
            //btnEditSnippet.Enabled = false;
            //btnAddSnippet.Enabled = false;
            //btnRemoveSnippet.Enabled = false;

            //cmbSnippets.SelectedIndex = 0;

        }

        private void ResizeDetailsColumns()
        {
            if (lvwDetails.Items.Count > 0)
            {
                lvwDetails.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            else
            {
                lvwDetails.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            lvwDetails.Columns[1].Width = lvwDetails.ClientRectangle.Width - lvwDetails.Columns[0].Width;
        }

        private void SaveScreenLayout()
        {
            Properties.Settings.Default.frmMainLocation = this.Location;
            Properties.Settings.Default.frmMainWindowState = this.WindowState;
            Properties.Settings.Default.frmMainWidth = this.Width;
            Properties.Settings.Default.frmMainHeight = this.Height;

            try
            {
                Properties.Settings.Default.Save();
            }
            catch { }
        }

        private void SaveSettings()
        {
            try
            {
                if (tvwClasses.SelectedNode != null)
                {
                    Properties.Settings.Default.LastSelectedClass = tvwClasses.SelectedNode.Text;

                    Properties.Settings.Default.Save();
                }
            }
            catch
            {
            }
        }

        private string SelectedNodeFullname(TreeNode Node)
        {
            string Results = "";

            //Console.WriteLine("NodeIndex: " + Node.ImageIndex);

            if (Node != null)
            {

                switch (Node.ImageIndex)
                {
                    case 0:  // Class
                        Class SelectedClass = (Class)Node.Tag;

                        Results = SelectedClass.Name.InnerText;

                        break;
                    case 1:  // Field
                        Field SelectedField = (Field)Node.Tag;

                        if (SelectedField.DesignerName != "")
                        {
                            Results = SelectedField.Parent.Name.InnerText + "." + SelectedField.DesignerName;
                        }
                        else
                        {
                            Results = SelectedField.Parent.Name.InnerText + "." + SelectedField.Name;
                        }

                        break;
                    case 2:  // Method
                        Method SelectedMethod = (Method)Node.Tag;

                        if (SelectedMethod.DesignerName != "")
                        {
                            Results = SelectedMethod.Parent.Name.InnerText + "." + SelectedMethod.DesignerName;
                        }
                        else
                        {
                            Results = SelectedMethod.Parent.Name.InnerText + "." + SelectedMethod.Name;
                        }

                        break;
                    case 3:  // Library
                        Library SelectedLibrary = (Library)Node.Tag;

                        Results = SelectedLibrary.Name.InnerText + " " + _ResourceManager.GetString("LibrarySelectedChooseAClass");

                        break;
                    case 4:  // Property
                        Property SelectedProperty = (Property)Node.Tag;

                        if (SelectedProperty.DesignerName != "")
                        {
                            Results = SelectedProperty.Parent.Name.InnerText + "." + SelectedProperty.DesignerName;
                        }
                        else
                        {
                            Results = SelectedProperty.Parent.Name.InnerText + "." + SelectedProperty.Name;
                        }


                        break;
                    case 12:  // DesignerProperty
                        DesignerProperty SelectedDesignerProperty = (DesignerProperty)Node.Tag;

                        if (SelectedDesignerProperty.DisplayName != "")
                        {
                            Results = SelectedDesignerProperty.Parent.Name.InnerText + "." + SelectedDesignerProperty.DisplayName;
                        }
                        else
                        {
                            Results = SelectedDesignerProperty.Parent.Name.InnerText + "." + SelectedDesignerProperty.Key;
                        }


                        break;
                }
            }

            return Results;
        }

        private void SetLabelVisibility()
        {
            if (Properties.Settings.Default.ShowLabels)
            {
                lblClasses.Visible = true;
                lblMethodsPropertiesFields.Visible = true;
                lblPermissions.Visible = true;
                lblEvents.Visible = true;
            }
            else
            {
                lblClasses.Visible = false;
                lblMethodsPropertiesFields.Visible = false;
                lblPermissions.Visible = false;
                lblEvents.Visible = false;
            }
        }

        private void SetMenuInitialValues()
        {
            classDetailsToolStripMenuItem.Checked = Properties.Settings.Default.ClassDetailsVisible;
            FieldsToolStripMenuItem.Checked = Properties.Settings.Default.ShowFields;
            HideBAObjectIfFirstParameterToolStripMenuItem.Checked = Properties.Settings.Default.HideBAObjectIfFirstParameter;
            LoadXMLOnDemandToolStripMenuItem.Checked = Properties.Settings.Default.LoadXMLOnDemand;
            MethodsToolStripMenuItem.Checked = Properties.Settings.Default.ShowMethods;
            PropertiesToolStripMenuItem.Checked = Properties.Settings.Default.ShowProperties;
            DesignerPropertiesToolStripMenuItem.Checked = Properties.Settings.Default.ShowDesignerProperties;
            ShowEmptyParenthesesToolStripMenuItem.Checked = Properties.Settings.Default.ShowEmptyParentheses;
            ShowFullTypenameToolStripMenuItem.Checked = Properties.Settings.Default.ShowFullTypeName;
            ShowLabelsToolStripMenuItem.Checked = Properties.Settings.Default.ShowLabels;
            ShowSearchResultsInClassAndLibraryTreeViewToolStripMenuItem.Checked = Properties.Settings.Default.ShowSearchResultsInLibraryClassTreeView;
            ShowVoidInUsageToolStripMenuItem.Checked = Properties.Settings.Default.ShowVoidInUsage;
            StayOnTopToolStripMenuItem.Checked = Properties.Settings.Default.AlwaysOnTop;
            enableSnippetDragDropToolStripMenuItem.Checked = Properties.Settings.Default.EnableSnippetDragDrop;


            if (Properties.Settings.Default.UIFontSize != 0)
            {
                this.Font = new Font(this.Font.FontFamily, Properties.Settings.Default.UIFontSize);

                switch (Properties.Settings.Default.UIFontSize)
                {
                    case 8:
                        FontSize8ToolStripMenuItem.Checked = true;
                        break;
                    case 9:
                        FontSize9ToolStripMenuItem.Checked = true;
                        break;
                    case 10:
                        FontSize10ToolStripMenuItem.Checked = true;
                        break;
                    case 12:
                        FontSize12ToolStripMenuItem.Checked = true;
                        break;
                    case 14:
                        FontSize14ToolStripMenuItem.Checked = true;
                        break;
                    case 16:
                        FontSize16ToolStripMenuItem.Checked = true;
                        break;
                }
            }
        }

        private void ShowAbout()
        {
            frmAbout AboutForm = new frmAbout(this);

            AboutForm.ShowDialog();
        }

        private void ShowClassDetails(bool State)
        {
            splitMain.Panel1Collapsed = !State;

            Properties.Settings.Default.ClassDetailsVisible = State;

            //classDetailsToolStripMenuItem.Checked = State;

            Properties.Settings.Default.Save();
        }

        private void ShowOpenFolderDialog()
        {
            MessageBox.Show(_ResourceManager.GetString("PleaseConfigureOptions"));

            DoOptions();
        }

        private bool SnippetExists(string ObjectPath)
        {
            string FileRoot = System.IO.Path.Combine(_SaveRoot, _SelectedObjectName).Replace(".", @"\");
            string FolderPath = System.IO.Path.Combine(FileRoot, ObjectPath);

            if (System.IO.Directory.Exists(FolderPath))
            {
                return System.IO.Directory.GetFiles(FolderPath).Count() > 0;
            }

            return false;
        }

        private string TypeName(string OriginalTypename)
        {
            string ReturnTypeName = OriginalTypename;

            if (!IsNumeric(OriginalTypename))
            {
                if (!Properties.Settings.Default.ShowFullTypeName)
                {
                    if (OriginalTypename.IndexOf(".") > 0)
                        // shorten the typename
                        ReturnTypeName = OriginalTypename.Substring(OriginalTypename.LastIndexOf(".") + 1);
                }
            }

            return ReturnTypeName;
        }

        private void UpdateLabel()
        {
            string Label = "";

            try
            {
                // determine what label to Show
                if (Properties.Settings.Default.ShowMethods)
                    Label = _ResourceManager.GetString("Methods");

                if (Properties.Settings.Default.ShowProperties)
                    Label += ", " + _ResourceManager.GetString("Properties");

                if (Properties.Settings.Default.ShowFields)
                    Label += ", " + _ResourceManager.GetString("Fields");

                if (Label.StartsWith(","))
                    Label = Label.Substring(1).Trim();

                lblMethodsPropertiesFields.Text = Label;
            }
            catch { }
        }

        private void UpdateUIControls()
        {
            _CurrentCultureName = "en-US";

            switch (Globals.PCLanguageSetting)
            {
                case "English":
                    _CurrentCultureName = "en-US";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "Afrikaans":
                    _CurrentCultureName = "af-ZA";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "العربية":
                    _CurrentCultureName = "ar-SA";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    break;
                case "български":
                    _CurrentCultureName = "bg-BG";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "Catalan":
                    _CurrentCultureName = "ca-ES";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "中文（简体":
                    _CurrentCultureName = "zh-CN";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "Deutsch":
                    _CurrentCultureName = "de-DE";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "español":
                    _CurrentCultureName = "es-ES";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "français":
                    _CurrentCultureName = "fr-FR";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "ελληνικός":
                    _CurrentCultureName = "el-GR";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "עברית":
                    _CurrentCultureName = "he-IL";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    break;
                case "Bahasa Indonesia":
                    _CurrentCultureName = "id-ID";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "hrvatski":  // Croatian
                    _CurrentCultureName = "hr-BA";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "italiano":
                    _CurrentCultureName = "it-IT";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "日本語":
                    _CurrentCultureName = "ja-JP";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "Nederlands":
                    _CurrentCultureName = "nl-NL";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "norsk":
                    _CurrentCultureName = "nn-NO";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "polski":
                    _CurrentCultureName = "pl-PL";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "português":
                    _CurrentCultureName = "pt-PT";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "român":
                    _CurrentCultureName = "ro-RO";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "русский":
                    _CurrentCultureName = "ru-RU";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "svenska":
                    _CurrentCultureName = "sv-SE";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "ภาษาไทย":
                    _CurrentCultureName = "th-TH";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "Український":
                    _CurrentCultureName = "uk-UA";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "Việt":
                    _CurrentCultureName = "vi-VN";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "فارسی":
                    _CurrentCultureName = "fa-IR";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    break;
                case "České":
                    _CurrentCultureName = "cs-CZ";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "Dansk":
                    _CurrentCultureName = "da-DK";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
                case "Filipino":
                    _CurrentCultureName = "fil-PH";
                    this.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwClasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    tvwMethodsPropertiesFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    break;
            }

            // This is used for the language of the user interface
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(_CurrentCultureName);
            //
            // http://msdn.microsoft.com/en-us/goglobal/bb896001.aspx
            //
            // This is used with formatting and sort options (e.g. number and date formats)
            // e.g. a float value 2.352 will be 2,3.52 if CurrentCulture is set to de-DE
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(_CurrentCultureName);

            try
            {
                if (_ResourceManager != null)
                {
                    this.Text = _ResourceManager.GetString("B4xObjectBrowser");

                    toolStripMenuItem1.Text = _ResourceManager.GetString("File");
                    reloadToolStripMenuItem.Text = _ResourceManager.GetString("ReloadLibraries");
                    exitToolStripMenuItem.Text = _ResourceManager.GetString("Exit");

                    viewToolStripMenuItem.Text = _ResourceManager.GetString("View");
                    classDetailsToolStripMenuItem.Text = _ResourceManager.GetString("ClassDetails");
                    lblClassDetails.Text = _ResourceManager.GetString("ClassDetails");
                    FieldsToolStripMenuItem.Text = _ResourceManager.GetString("Fields");
                    HideBAObjectIfFirstParameterToolStripMenuItem.Text = _ResourceManager.GetString("HideBAObjectIfFirstParameter");
                    LoadXMLOnDemandToolStripMenuItem.Text = _ResourceManager.GetString("LoadXMLOnDemand");
                    MethodsToolStripMenuItem.Text = _ResourceManager.GetString("Methods");
                    PropertiesToolStripMenuItem.Text = _ResourceManager.GetString("Properties");
                    ShowEmptyParenthesesToolStripMenuItem.Text = _ResourceManager.GetString("ShowEmptyParentheses");
                    ShowFullTypenameToolStripMenuItem.Text = _ResourceManager.GetString("ShowFullTypename");
                    ShowLabelsToolStripMenuItem.Text = _ResourceManager.GetString("ShowLabels");
                    ShowSearchResultsInClassAndLibraryTreeViewToolStripMenuItem.Text = _ResourceManager.GetString("ShowSearchResultsInLibraryClassTreeView");
                    ShowVoidInUsageToolStripMenuItem.Text = _ResourceManager.GetString("ShowVoidInUsage");
                    ShowClassGlobalToolStripMenuItem.Text = _ResourceManager.GetString("ShowClassGlobals");
                    ShowPropertyGetAndSetToolStripMenuItem.Text = _ResourceManager.GetString("ShowPropertyGetAndSet");
                    ShowDesignerCreateViewToolStripMenuItem.Text = _ResourceManager.GetString("ShowDesignerCreateView");
                    StayOnTopToolStripMenuItem.Text = _ResourceManager.GetString("StayOnTop");
                    CheckForUpdateToolStripMenuItem.Text = _ResourceManager.GetString("CheckForUpdate");
                    DonateToolStripMenuItem.Text = _ResourceManager.GetString("Donate");
                    enableEditsToolStripMenuItem.Text = _ResourceManager.GetString("EnableEdits");
                    enableSnippetDragDropToolStripMenuItem.Text = _ResourceManager.GetString("EnableSnippetDragDrop");

                    toolsToolStripMenuItem.Text = _ResourceManager.GetString("Tools");
                    optionsToolStripMenuItem.Text = _ResourceManager.GetString("Options");

                    helpToolStripMenuItem.Text = _ResourceManager.GetString("Help");
                    aboutToolStripMenuItem.Text = _ResourceManager.GetString("About");

                    ToolstripExit.ToolTipText = _ResourceManager.GetString("Exit");
                    ToolstripReload.ToolTipText = _ResourceManager.GetString("ReloadLibraries");
                    ToolstripOptions.ToolTipText = _ResourceManager.GetString("Options");
                    ToolstripAbout.ToolTipText = _ResourceManager.GetString("About");
                    Search.ToolTipText = _ResourceManager.GetString("Search");
                    B4xHelp.ToolTipText = _ResourceManager.GetString("B4xHelp");
                    B4xForum.ToolTipText = _ResourceManager.GetString("B4xForum");
                    SiteSearch.ToolTipText = _ResourceManager.GetString("B4xSiteSearch");
                    LanguageAPI.ToolTipText = _ResourceManager.GetString("AndroidPackages");

                    tips.SetToolTip(btnSearch, _ResourceManager.GetString("Search"));
                    tips.SetToolTip(btnClearSearch, _ResourceManager.GetString("Clear"));

                    tips.SetToolTip(btnAddSnippet, _ResourceManager.GetString("AddSnippet"));
                    tips.SetToolTip(btnRemoveSnippet, _ResourceManager.GetString("RemoveSnippet"));

                    if (!_SearchMode)
                    {
                        txtSearch.Text = _ResourceManager.GetString("SearchText");
                    }
                    tips.SetToolTip(btnSearch, _ResourceManager.GetString("Search"));
                    tips.SetToolTip(btnClearSearch, _ResourceManager.GetString("Clear"));

                    lvwDetails.Columns[0].Text = _ResourceManager.GetString("Annotation");
                    lvwDetails.Columns[1].Text = _ResourceManager.GetString("Value");
                    //lvwDetails.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);

                    lblPermissions.Text = _ResourceManager.GetString("Permissions");
                    lblEvents.Text = _ResourceManager.GetString("Events");
                    lblClasses.Text = _ResourceManager.GetString("Classes");
                    lblMethodsPropertiesFields.Text = _ResourceManager.GetString("MethodsPropertiesFields");

                    //lblStandardClassComment.Text = _ResourceManager.GetString("Comment");
                    cmbSnippets.Items.Clear();

                    ComboBoxItem Item = new ComboBoxItem();
                    Item.Text = _ResourceManager.GetString("Comment");
                    Item.EnglishText = "Comment";
                    cmbSnippets.Items.Add(Item);

                    tips.SetToolTip(btnEditSnippet, _ResourceManager.GetString("Edit"));
                    //cmbSnippets.Text = _ResourceManager.GetString("Comment");
                    cmbSnippets.SelectedIndex = 0;

                    Status.Text = _ResourceManager.GetString("Idle");

                    //notifyIcon.Text = _ResourceManager.GetString("B4xCodeSnippets");

                    copyNameToolStripMenuItem1.Text = _ResourceManager.GetString("CopyName");
                    CopyMPFText.Text = _ResourceManager.GetString("CopyNames");
                    CopyFullPathToolStripMenuItem.Text = _ResourceManager.GetString("CopyFullPath");
                    searchB4xSiteToolStripMenuItem1.Text = _ResourceManager.GetString("SearchB4aSite");

                    copyRTF.Text = _ResourceManager.GetString("CopyRTF");
                    CopyDetails.Text = _ResourceManager.GetString("CopyText");

                    copyNameToolStripMenuItem.Text = _ResourceManager.GetString("CopyName");
                    DocumentSelectedLibrary.Text = _ResourceManager.GetString("DocumentLibrary");
                    DocumentSelectedClass.Text = _ResourceManager.GetString("DocumentClass");
                    DocumentAll.Text = _ResourceManager.GetString("DocumentAll");
                    searchB4xSiteToolStripMenuItem.Text = _ResourceManager.GetString("SearchB4xSite");

                    CommentCopyText.Text = _ResourceManager.GetString("Copy");
                    CommentSearchB4xSite.Text = _ResourceManager.GetString("SearchB4xSite");
                    copyRTFToolStripMenuItem.Text = _ResourceManager.GetString("CopyRTF");

                    EventCopyText.Text = _ResourceManager.GetString("Copy");
                    EventSearch.Text = _ResourceManager.GetString("SearchB4xSite");

                    SiteSearch.Text = _ResourceManager.GetString("SearchB4xSite");

                    EventName.Text = _ResourceManager.GetString("Name");
                    PermissionName.Text = _ResourceManager.GetString("Name");

                    editToolStripMenuItem2.Text = _ResourceManager.GetString("Edit");
                    editToolStripMenuItem3.Text = _ResourceManager.GetString("Edit");

                    tips.SetToolTip(btnEditSnippet, _ResourceManager.GetString("EditSnippet"));
                    tips.SetToolTip(btnAddSnippet, _ResourceManager.GetString("AddSnippet"));
                    tips.SetToolTip(btnRemoveSnippet, _ResourceManager.GetString("DeleteSnippet"));
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        #endregion

        #region Public Methods

        public static bool IsNumeric(string StringToTest)
        {
            int i;
            float f;
            decimal d;

            return int.TryParse(StringToTest, out i) ||
            float.TryParse(StringToTest, out f) ||
            decimal.TryParse(StringToTest, out d);
        }

        public void SelectLibraryOrClassTreeNode()
        {
            TreeNode SelectedNode = tvwClasses.SelectedNode;  // remember the currently selected node
            Class ThisClass = new Class();
            Library ThisLibrary = new Library();
            string SelectedClassNodeText = SelectedNodeFullname(tvwClasses.SelectedNode);
            ListViewItem ListItem;

            ResetClassScreenElements();

            if (tvwClasses.SelectedNode != null)
            {

                switch (tvwClasses.SelectedNode.Level)
                {
                    case 0: // Library

                        #region Library Level

                        lblClassDetails.Text = _ResourceManager.GetString("Library");

                        ThisLibrary = (Library)tvwClasses.SelectedNode.Tag;

                        ResetLibraryScreenElements();

                        if (Properties.Settings.Default.LoadXMLOnDemand)
                        {
                            if (tvwClasses.SelectedNode.Nodes.Count == 0)
                            {
                                LoadXMLFileData(ThisLibrary.Path.InnerText, tvwClasses.SelectedNode, ThisLibrary);

                                // LoadXMLFile de-selects the node, so we have to set it back to what it was
                                tvwClasses.SelectedNode = SelectedNode;

                                if (tvwClasses.SelectedNode != null)
                                {
                                    tvwClasses.SelectedNode.Expand();
                                }
                            }
                        }
                        //lblStandardClassComment.Text = SelectedNodeFullname(tvwClasses.SelectedNode);
                        //cmbSnippets.Text = SelectedNodeFullname(tvwClasses.SelectedNode);
                        cmbSnippets.SelectedIndex = 0;
                        #region Library comments

                        rtbClassComment.Clear();

                        foreach (Comment SelectedLibraryComment in ThisLibrary.Comments)
                        {
                            rtbClassComment.AddHTML(SelectedLibraryComment.Text);
                        }

                        rtbClassComment.SelectionStart = 0;
                        rtbClassComment.Enabled = true;

                        #endregion

                        //////////////////////

                        lvwDetails.Items.Clear();

                        // Annotations
                        foreach (Annotation ClassAnnotation in ThisLibrary.Annotations)
                        {
                            ListItem = new ListViewItem(ClassAnnotation.Name);
                            ListItem.SubItems.Add(ClassAnnotation.Value);
                            lvwDetails.Items.Add(ListItem);
                        }

                        //lvwDetails.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
                        ResizeDetailsColumns();

                        #endregion

                        break;
                    case 1: // Class

                        #region Class Level

                        lblClassDetails.Text = _ResourceManager.GetString("ClassDetails");

                        switch (tvwClasses.SelectedNode.ImageIndex)
                        {
                            case 0: // Class
                            case 18:
                                ThisClass = (Class)tvwClasses.SelectedNode.Tag;
                                _SelectedObjectName = ThisClass.Name.InnerText;
                                break;
                            case 1: // Field
                                Field ThisField = (Field)tvwClasses.SelectedNode.Tag;
                                _SelectedObjectName = ThisField.Name;
                                ThisClass = (Class)ThisField.Parent;
                                break;
                            case 2: // Method
                                Method ThisMethod = (Method)tvwClasses.SelectedNode.Tag;
                                _SelectedObjectName = ThisMethod.Name;
                                ThisClass = (Class)ThisMethod.Parent;
                                break;
                            case 4: // Property
                                Property ThisProperty = (Property)tvwClasses.SelectedNode.Tag;
                                _SelectedObjectName = ThisProperty.Name;
                                ThisClass = (Class)ThisProperty.Parent;
                                break;
                            case 12: // DesignerProperty
                                DesignerProperty ThisDesignerProperty = (DesignerProperty)tvwClasses.SelectedNode.Tag;
                                _SelectedObjectName = ThisDesignerProperty.Key;
                                ThisClass = (Class)ThisDesignerProperty.Parent;
                                break;
                            case 13: // Parameter
                                Parameter ThisParameter = (Parameter)tvwClasses.SelectedNode.Tag;
                                _SelectedObjectName = ThisParameter.Name;
                                ThisClass = (Class)ThisParameter.Parent.Parent;
                                break;
                            case 14: // Annotation
                                Annotation ThisAnnotation = (Annotation)tvwClasses.SelectedNode.Tag;
                                _SelectedObjectName = ThisAnnotation.Name;
                                if (ThisAnnotation.ParentClass != null)
                                    ThisClass = ThisAnnotation.ParentClass;
                                if (ThisAnnotation.ParentLibrary != null)
                                    ThisLibrary = ThisAnnotation.ParentLibrary;
                                break;
                            case 15: // Event
                                Event ThisEvent = (Event)tvwClasses.SelectedNode.Tag;
                                _SelectedObjectName = ThisEvent.Name;
                                ThisClass = (Class)ThisEvent.Parent;
                                break;
                            case 16: // Permission
                                Permission ThisPermission = (Permission)tvwClasses.SelectedNode.Tag;
                                _SelectedObjectName = ThisPermission.Name;
                                ThisClass = (Class)ThisPermission.Parent;
                                break;
                            default:
                                //Exception ex = new Exception("Unknown Icon type (" + tvwClasses.SelectedNode.ImageIndex + "");
                                break;
                        }

                        LoadDataFromClass(ThisClass, tvwMethodsPropertiesFields);

                        #endregion

                        break;
                    case 2: // Method or Property or Field (whilst navigating search results)
                        SelectMethodPropertyFieldTreeNode();

                        TreeNode Node = tvwClasses.SelectedNode;

                        break;
                }
            }
        }

        public void SelectMethodPropertyFieldTreeNode()
        {
            Class ThisClass = null; // (Class)tvwClasses.SelectedNode.Tag;
            Library ThisLibrary = null;
            //int VoteCount = 0;
            //int SelectedComment = 0;

            ResetMPFScreenElements();

            // Work out what object type has been selected
            if (tvwClasses.SelectedNode != null)
            {
                switch (tvwClasses.SelectedNode.Level)
                {
                    case 0: // Library
                        break;
                    case 1: // Class
                        ThisClass = (Class)tvwClasses.SelectedNode.Tag;

                        _SelectedObjectName = ThisClass.Name.InnerText;
                        break;
                    case 2: // Method / Property / Field

                        switch (tvwClasses.SelectedNode.ImageIndex)
                        {
                            case 0: // Class
                            case 18:
                                ThisClass = (Class)tvwClasses.SelectedNode.Tag;

                                _SelectedObjectName = ThisClass.Name.InnerText;
                                break;
                            case 1: // Field
                                Field ThisField = (Field)tvwClasses.SelectedNode.Tag;

                                _SelectedObjectName = ThisField.Name;
                                ThisClass = (Class)ThisField.Parent;
                                break;
                            case 2: // Method
                                Method ThisMethod = (Method)tvwClasses.SelectedNode.Tag;

                                _SelectedObjectName = ThisMethod.Name;
                                ThisClass = (Class)ThisMethod.Parent;
                                break;
                            case 4: // Property
                                Property ThisProperty = (Property)tvwClasses.SelectedNode.Tag;

                                _SelectedObjectName = ThisProperty.Name;
                                ThisClass = (Class)ThisProperty.Parent;
                                break;
                            case 12: // DesignerProperty
                                DesignerProperty ThisDesignerProperty = (DesignerProperty)tvwClasses.SelectedNode.Tag;

                                _SelectedObjectName = ThisDesignerProperty.Key;
                                ThisClass = (Class)ThisDesignerProperty.Parent;
                                break;
                            case 13: // Parameter
                                Parameter ThisParameter = (Parameter)tvwClasses.SelectedNode.Tag;

                                _SelectedObjectName = ThisParameter.Name;
                                ThisClass = (Class)ThisParameter.Parent.Parent;
                                break;
                            case 14: // Annotation
                                Annotation ThisAnnotation = (Annotation)tvwClasses.SelectedNode.Tag;

                                _SelectedObjectName = ThisAnnotation.Name;

                                if (ThisAnnotation.ParentClass != null)
                                {
                                    ThisClass = ThisAnnotation.ParentClass;
                                }
                                if (ThisAnnotation.ParentLibrary != null)
                                {
                                    ThisLibrary = ThisAnnotation.ParentLibrary;
                                }
                                break;
                            case 15: // Event
                                Event ThisEvent = (Event)tvwClasses.SelectedNode.Tag;

                                _SelectedObjectName = ThisEvent.Name;
                                ThisClass = (Class)ThisEvent.Parent;
                                break;
                            case 16: // Permission
                                Permission ThisPermission = (Permission)tvwClasses.SelectedNode.Tag;

                                _SelectedObjectName = ThisPermission.Name;
                                ThisClass = (Class)ThisPermission.Parent;
                                break;
                            default:
                                //Exception ex = new Exception("Unknown Icon type (" + tvwClasses.SelectedNode.ImageIndex + "");
                                break;
                        }
                        break;
                }
            }

            if (tvwMethodsPropertiesFields.SelectedNode != null)
            {
                _SelectedObjectName += "." + tvwMethodsPropertiesFields.SelectedNode.Text;
            }

            //tlpCommentSnippets.AllowDrop = true;
            //btnAddSnippet.AllowDrop = true;
            //btnRemoveSnippet.AllowDrop = true;

            // It is now possible to enter this method without a selected Node in tvwMethodsPropertiesFields, due to the Search results
            // This is now catered for...
            if (tvwMethodsPropertiesFields.Nodes.Count == 0)
            {
                // Search results mode
                DocumentNode(tvwClasses.SelectedNode, ThisClass, rtbClassComment);
            }
            else
            {
                // Normal mode
                DocumentNode(tvwMethodsPropertiesFields.SelectedNode, ThisClass, rtbClassComment);
            }
        }

        #endregion

    }
}
