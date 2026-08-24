namespace Browser
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);

            //this.Client.Close();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.split1 = new System.Windows.Forms.SplitContainer();
            this.cmsDocumentation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DocumentSelectedLibrary = new System.Windows.Forms.ToolStripMenuItem();
            this.DocumentSelectedClass = new System.Windows.Forms.ToolStripMenuItem();
            this.DocumentAll = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editXMLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchB4xSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imlObject = new System.Windows.Forms.ImageList(this.components);
            this.lblClasses = new System.Windows.Forms.Label();
            this.split2 = new System.Windows.Forms.SplitContainer();
            this.rtbDocumentation = new HtmlRichText.HtmlRichTextBox();
            this.cmsMPF = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyNameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyMPFText = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyFullPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchB4xSiteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMethodsPropertiesFields = new System.Windows.Forms.Label();
            this.rtbClassComment = new HtmlRichText.HtmlRichTextBox();
            this.cmsComment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CommentCopyText = new System.Windows.Forms.ToolStripMenuItem();
            this.copyRTFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.CommentSearchB4xSite = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpCommentSnippets = new System.Windows.Forms.TableLayoutPanel();
            this.cmbSnippets = new System.Windows.Forms.ComboBox();
            this.picExtraComments = new System.Windows.Forms.PictureBox();
            this.btnRemoveSnippet = new System.Windows.Forms.Button();
            this.btnAddSnippet = new System.Windows.Forms.Button();
            this.btnEditSnippet = new System.Windows.Forms.Button();
            this.cmsDetails = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyRTF = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DesignerPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FieldsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HideBAObjectIfFirstParameterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadXMLOnDemandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MethodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowClassGlobalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowDesignerCreateViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowEmptyParenthesesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowFullTypenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowPropertyGetAndSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowSearchResultsInClassAndLibraryTreeViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowVoidInUsageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StayOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontSize8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontSize9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontSize10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontSize12ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontSize14ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontSize16ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DonateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableEditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.enableSnippetDragDropToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvwDetails = new System.Windows.Forms.ListView();
            this.Annotation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblClassDetails = new System.Windows.Forms.Label();
            this.lvwEvents = new System.Windows.Forms.ListView();
            this.EventName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsEvents = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EventCopyText = new System.Windows.Forms.ToolStripMenuItem();
            this.EventSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.lblEvents = new System.Windows.Forms.Label();
            this.lvwPermissions = new System.Windows.Forms.ListView();
            this.PermissionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblPermissions = new System.Windows.Forms.Label();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.ToolstripExit = new System.Windows.Forms.ToolStripButton();
            this.ToolstripReload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonB4a = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonB4i = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonB4j = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonB4r = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolstripOptions = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolstripAbout = new System.Windows.Forms.ToolStripButton();
            this.Search = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.B4xHelp = new System.Windows.Forms.ToolStripButton();
            this.B4xForum = new System.Windows.Forms.ToolStripButton();
            this.SiteSearch = new System.Windows.Forms.ToolStripButton();
            this.LanguageAPI = new System.Windows.Forms.ToolStripButton();
            this.tips = new System.Windows.Forms.ToolTip(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.PermissionsTips = new System.Windows.Forms.ToolTip(this.components);
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.tlpClassInfo = new System.Windows.Forms.TableLayoutPanel();
            this.pnlDetails1 = new System.Windows.Forms.Panel();
            this.pnlDetails2 = new System.Windows.Forms.Panel();
            this.pnlDetails3 = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tlpSearch = new System.Windows.Forms.TableLayoutPanel();
            this.tvwClasses = new BufferedTreeView();
            this.tvwMethodsPropertiesFields = new BufferedTreeView();
            ((System.ComponentModel.ISupportInitialize)(this.split1)).BeginInit();
            this.split1.Panel1.SuspendLayout();
            this.split1.Panel2.SuspendLayout();
            this.split1.SuspendLayout();
            this.cmsDocumentation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split2)).BeginInit();
            this.split2.Panel1.SuspendLayout();
            this.split2.Panel2.SuspendLayout();
            this.split2.SuspendLayout();
            this.cmsMPF.SuspendLayout();
            this.cmsComment.SuspendLayout();
            this.tlpCommentSnippets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExtraComments)).BeginInit();
            this.cmsDetails.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.cmsEvents.SuspendLayout();
            this.tools.SuspendLayout();
            this.StatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.tlpClassInfo.SuspendLayout();
            this.pnlDetails1.SuspendLayout();
            this.pnlDetails2.SuspendLayout();
            this.pnlDetails3.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.tlpSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // split1
            // 
            this.split1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.split1.Location = new System.Drawing.Point(0, 0);
            this.split1.Name = "split1";
            // 
            // split1.Panel1
            // 
            this.split1.Panel1.Controls.Add(this.tvwClasses);
            this.split1.Panel1.Controls.Add(this.lblClasses);
            // 
            // split1.Panel2
            // 
            this.split1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.split1.Panel2.Controls.Add(this.split2);
            this.split1.Size = new System.Drawing.Size(903, 344);
            this.split1.SplitterDistance = 189;
            this.split1.SplitterWidth = 5;
            this.split1.TabIndex = 0;
            // 
            // cmsDocumentation
            // 
            this.cmsDocumentation.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsDocumentation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyNameToolStripMenuItem,
            this.DocumentSelectedLibrary,
            this.DocumentSelectedClass,
            this.DocumentAll,
            this.OpenFolderToolStripMenuItem,
            this.editXMLFileToolStripMenuItem,
            this.searchB4xSiteToolStripMenuItem});
            this.cmsDocumentation.Name = "cmsRightClick";
            this.cmsDocumentation.ShowImageMargin = false;
            this.cmsDocumentation.Size = new System.Drawing.Size(172, 158);
            this.cmsDocumentation.Text = "Right Click";
            // 
            // copyNameToolStripMenuItem
            // 
            this.copyNameToolStripMenuItem.Name = "copyNameToolStripMenuItem";
            this.copyNameToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.copyNameToolStripMenuItem.Text = "Copy Name";
            this.copyNameToolStripMenuItem.Click += new System.EventHandler(this.copyNameToolStripMenuItem_Click);
            // 
            // DocumentSelectedLibrary
            // 
            this.DocumentSelectedLibrary.Name = "DocumentSelectedLibrary";
            this.DocumentSelectedLibrary.Size = new System.Drawing.Size(171, 22);
            this.DocumentSelectedLibrary.Text = "Document Library";
            this.DocumentSelectedLibrary.Click += new System.EventHandler(this.DocumentSelectedLibrary_Click);
            // 
            // DocumentSelectedClass
            // 
            this.DocumentSelectedClass.Name = "DocumentSelectedClass";
            this.DocumentSelectedClass.Size = new System.Drawing.Size(171, 22);
            this.DocumentSelectedClass.Text = "Document Class";
            this.DocumentSelectedClass.Click += new System.EventHandler(this.DocumentSelectedClass_Click);
            // 
            // DocumentAll
            // 
            this.DocumentAll.Name = "DocumentAll";
            this.DocumentAll.Size = new System.Drawing.Size(171, 22);
            this.DocumentAll.Text = "Document All";
            this.DocumentAll.Click += new System.EventHandler(this.DocumentAll_Click);
            // 
            // OpenFolderToolStripMenuItem
            // 
            this.OpenFolderToolStripMenuItem.Name = "OpenFolderToolStripMenuItem";
            this.OpenFolderToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.OpenFolderToolStripMenuItem.Text = "Open folder in Explorer";
            this.OpenFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenFolderToolStripMenuItem_Click);
            // 
            // editXMLFileToolStripMenuItem
            // 
            this.editXMLFileToolStripMenuItem.Name = "editXMLFileToolStripMenuItem";
            this.editXMLFileToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.editXMLFileToolStripMenuItem.Text = "Open XML file";
            this.editXMLFileToolStripMenuItem.Click += new System.EventHandler(this.editXMLFileToolStripMenuItem_Click);
            // 
            // searchB4xSiteToolStripMenuItem
            // 
            this.searchB4xSiteToolStripMenuItem.Name = "searchB4xSiteToolStripMenuItem";
            this.searchB4xSiteToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.searchB4xSiteToolStripMenuItem.Text = "Search B4x Site";
            this.searchB4xSiteToolStripMenuItem.Click += new System.EventHandler(this.searchB4xSiteToolStripMenuItem_Click);
            // 
            // imlObject
            // 
            this.imlObject.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlObject.ImageStream")));
            this.imlObject.TransparentColor = System.Drawing.Color.Transparent;
            this.imlObject.Images.SetKeyName(0, "Class.gif");
            this.imlObject.Images.SetKeyName(1, "FieldOrVariable.gif");
            this.imlObject.Images.SetKeyName(2, "MethodOrFunction.gif");
            this.imlObject.Images.SetKeyName(3, "Namespace.gif");
            this.imlObject.Images.SetKeyName(4, "Property.gif");
            this.imlObject.Images.SetKeyName(5, "file.png");
            this.imlObject.Images.SetKeyName(6, "users.png");
            this.imlObject.Images.SetKeyName(7, "user-alt-3.png");
            this.imlObject.Images.SetKeyName(8, "connect.png");
            this.imlObject.Images.SetKeyName(9, "disconnect.png");
            this.imlObject.Images.SetKeyName(10, "user-me.png");
            this.imlObject.Images.SetKeyName(11, "checkbox-empty.png");
            this.imlObject.Images.SetKeyName(12, "checkbox.png");
            this.imlObject.Images.SetKeyName(13, "attachment.png");
            this.imlObject.Images.SetKeyName(14, "bookmark.png");
            this.imlObject.Images.SetKeyName(15, "calendar-alt-1.png");
            this.imlObject.Images.SetKeyName(16, "padlock-closed.png");
            this.imlObject.Images.SetKeyName(17, "Namespace_Error.gif");
            this.imlObject.Images.SetKeyName(18, "Class_Error.gif");
            this.imlObject.Images.SetKeyName(19, "Class_Commented.gif");
            this.imlObject.Images.SetKeyName(20, "FieldOrVariable_Commented.gif");
            this.imlObject.Images.SetKeyName(21, "MethodOrFunction_Commented.gif");
            this.imlObject.Images.SetKeyName(22, "Namespace_Commented.gif");
            this.imlObject.Images.SetKeyName(23, "Property_Commented.gif");
            this.imlObject.Images.SetKeyName(24, "MethodOrFunction_Error.gif");
            this.imlObject.Images.SetKeyName(25, "Property_Error.gif");
            // 
            // lblClasses
            // 
            this.lblClasses.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblClasses.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblClasses.Location = new System.Drawing.Point(0, 0);
            this.lblClasses.Name = "lblClasses";
            this.lblClasses.Size = new System.Drawing.Size(189, 33);
            this.lblClasses.TabIndex = 0;
            this.lblClasses.Text = "Classes";
            this.lblClasses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // split2
            // 
            this.split2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.split2.BackColor = System.Drawing.SystemColors.Control;
            this.split2.Location = new System.Drawing.Point(0, 0);
            this.split2.Name = "split2";
            this.split2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split2.Panel1
            // 
            this.split2.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.split2.Panel1.Controls.Add(this.rtbDocumentation);
            this.split2.Panel1.Controls.Add(this.tvwMethodsPropertiesFields);
            this.split2.Panel1.Controls.Add(this.lblMethodsPropertiesFields);
            // 
            // split2.Panel2
            // 
            this.split2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.split2.Panel2.Controls.Add(this.rtbClassComment);
            this.split2.Panel2.Controls.Add(this.tlpCommentSnippets);
            this.split2.Size = new System.Drawing.Size(705, 339);
            this.split2.SplitterDistance = 167;
            this.split2.SplitterWidth = 5;
            this.split2.TabIndex = 0;
            // 
            // rtbDocumentation
            // 
            this.rtbDocumentation.Location = new System.Drawing.Point(1555, 1500);
            this.rtbDocumentation.Name = "rtbDocumentation";
            this.rtbDocumentation.Size = new System.Drawing.Size(147, 37);
            this.rtbDocumentation.TabIndex = 1;
            this.rtbDocumentation.Text = "";
            this.rtbDocumentation.Visible = false;
            // 
            // cmsMPF
            // 
            this.cmsMPF.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsMPF.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyNameToolStripMenuItem1,
            this.CopyMPFText,
            this.CopyFullPathToolStripMenuItem,
            this.searchB4xSiteToolStripMenuItem1});
            this.cmsMPF.Name = "cmsRightClick";
            this.cmsMPF.ShowImageMargin = false;
            this.cmsMPF.Size = new System.Drawing.Size(129, 92);
            this.cmsMPF.Text = "Right Click";
            // 
            // copyNameToolStripMenuItem1
            // 
            this.copyNameToolStripMenuItem1.Name = "copyNameToolStripMenuItem1";
            this.copyNameToolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.copyNameToolStripMenuItem1.Text = "Copy Name";
            this.copyNameToolStripMenuItem1.Click += new System.EventHandler(this.copyNameToolStripMenuItem1_Click);
            // 
            // CopyMPFText
            // 
            this.CopyMPFText.Name = "CopyMPFText";
            this.CopyMPFText.Size = new System.Drawing.Size(128, 22);
            this.CopyMPFText.Text = "Copy Names";
            this.CopyMPFText.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // CopyFullPathToolStripMenuItem
            // 
            this.CopyFullPathToolStripMenuItem.Name = "CopyFullPathToolStripMenuItem";
            this.CopyFullPathToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.CopyFullPathToolStripMenuItem.Text = "Copy Full Path";
            this.CopyFullPathToolStripMenuItem.Click += new System.EventHandler(this.copyFullPathToolStripMenuItem_Click);
            // 
            // searchB4xSiteToolStripMenuItem1
            // 
            this.searchB4xSiteToolStripMenuItem1.Name = "searchB4xSiteToolStripMenuItem1";
            this.searchB4xSiteToolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.searchB4xSiteToolStripMenuItem1.Text = "Search B4x Site";
            this.searchB4xSiteToolStripMenuItem1.Click += new System.EventHandler(this.searchB4xSiteToolStripMenuItem1_Click);
            // 
            // lblMethodsPropertiesFields
            // 
            this.lblMethodsPropertiesFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMethodsPropertiesFields.BackColor = System.Drawing.SystemColors.Control;
            this.lblMethodsPropertiesFields.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblMethodsPropertiesFields.Location = new System.Drawing.Point(0, 0);
            this.lblMethodsPropertiesFields.Name = "lblMethodsPropertiesFields";
            this.lblMethodsPropertiesFields.Size = new System.Drawing.Size(701, 33);
            this.lblMethodsPropertiesFields.TabIndex = 0;
            this.lblMethodsPropertiesFields.Text = "Methods, Properties, Fields";
            this.lblMethodsPropertiesFields.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtbClassComment
            // 
            this.rtbClassComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbClassComment.BackColor = System.Drawing.Color.White;
            this.rtbClassComment.ContextMenuStrip = this.cmsComment;
            this.rtbClassComment.Enabled = false;
            this.rtbClassComment.Location = new System.Drawing.Point(5, 0);
            this.rtbClassComment.Margin = new System.Windows.Forms.Padding(0);
            this.rtbClassComment.Name = "rtbClassComment";
            this.rtbClassComment.Size = new System.Drawing.Size(697, 172);
            this.rtbClassComment.TabIndex = 4;
            this.rtbClassComment.Text = "";
            this.rtbClassComment.DragEnter += new System.Windows.Forms.DragEventHandler(this.rtbClassComment_DragEnter);
            this.rtbClassComment.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbClassComment_LinkClicked);
            this.rtbClassComment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbClassComment_KeyDown);
            // 
            // cmsComment
            // 
            this.cmsComment.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsComment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CommentCopyText,
            this.copyRTFToolStripMenuItem,
            this.editToolStripMenuItem2,
            this.CommentSearchB4xSite});
            this.cmsComment.Name = "cmsRightClick";
            this.cmsComment.ShowImageMargin = false;
            this.cmsComment.Size = new System.Drawing.Size(129, 92);
            this.cmsComment.Text = "Right Click";
            // 
            // CommentCopyText
            // 
            this.CommentCopyText.Name = "CommentCopyText";
            this.CommentCopyText.Size = new System.Drawing.Size(128, 22);
            this.CommentCopyText.Text = "Copy";
            this.CommentCopyText.Click += new System.EventHandler(this.CommentCopyText_Click);
            // 
            // copyRTFToolStripMenuItem
            // 
            this.copyRTFToolStripMenuItem.Name = "copyRTFToolStripMenuItem";
            this.copyRTFToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.copyRTFToolStripMenuItem.Text = "Copy RTF";
            this.copyRTFToolStripMenuItem.Click += new System.EventHandler(this.copyRTFToolStripMenuItem_Click_1);
            // 
            // editToolStripMenuItem2
            // 
            this.editToolStripMenuItem2.Name = "editToolStripMenuItem2";
            this.editToolStripMenuItem2.Size = new System.Drawing.Size(128, 22);
            this.editToolStripMenuItem2.Text = "Edit";
            this.editToolStripMenuItem2.Visible = false;
            // 
            // CommentSearchB4xSite
            // 
            this.CommentSearchB4xSite.Name = "CommentSearchB4xSite";
            this.CommentSearchB4xSite.Size = new System.Drawing.Size(128, 22);
            this.CommentSearchB4xSite.Text = "Search B4x Site";
            this.CommentSearchB4xSite.Click += new System.EventHandler(this.CommentSearchB4xSite_Click);
            // 
            // tlpCommentSnippets
            // 
            this.tlpCommentSnippets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpCommentSnippets.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpCommentSnippets.ColumnCount = 5;
            this.tlpCommentSnippets.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpCommentSnippets.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCommentSnippets.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpCommentSnippets.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpCommentSnippets.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpCommentSnippets.Controls.Add(this.cmbSnippets, 1, 0);
            this.tlpCommentSnippets.Controls.Add(this.picExtraComments, 0, 0);
            this.tlpCommentSnippets.Controls.Add(this.btnRemoveSnippet, 4, 0);
            this.tlpCommentSnippets.Controls.Add(this.btnAddSnippet, 3, 0);
            this.tlpCommentSnippets.Controls.Add(this.btnEditSnippet, 2, 0);
            this.tlpCommentSnippets.Location = new System.Drawing.Point(3, 3);
            this.tlpCommentSnippets.Name = "tlpCommentSnippets";
            this.tlpCommentSnippets.RowCount = 1;
            this.tlpCommentSnippets.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tlpCommentSnippets.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tlpCommentSnippets.Size = new System.Drawing.Size(698, 37);
            this.tlpCommentSnippets.TabIndex = 0;
            this.tlpCommentSnippets.DragDrop += new System.Windows.Forms.DragEventHandler(this.tlpCommentSnippets_DragDrop);
            this.tlpCommentSnippets.DragEnter += new System.Windows.Forms.DragEventHandler(this.tlpCommentSnippets_DragEnter);
            // 
            // cmbSnippets
            // 
            this.cmbSnippets.BackColor = System.Drawing.SystemColors.Window;
            this.cmbSnippets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSnippets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSnippets.FormattingEnabled = true;
            this.cmbSnippets.Items.AddRange(new object[] {
            "Standard"});
            this.cmbSnippets.Location = new System.Drawing.Point(38, 3);
            this.cmbSnippets.Name = "cmbSnippets";
            this.cmbSnippets.Size = new System.Drawing.Size(552, 23);
            this.cmbSnippets.TabIndex = 0;
            this.cmbSnippets.SelectedIndexChanged += new System.EventHandler(this.cmbSnippets_SelectedIndexChanged);
            // 
            // picExtraComments
            // 
            this.picExtraComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picExtraComments.BackgroundImage = global::Browser.Properties.Resources.beta_general_next_16;
            this.picExtraComments.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picExtraComments.Location = new System.Drawing.Point(8, 3);
            this.picExtraComments.Name = "picExtraComments";
            this.picExtraComments.Size = new System.Drawing.Size(24, 24);
            this.picExtraComments.TabIndex = 8;
            this.picExtraComments.TabStop = false;
            this.picExtraComments.Visible = false;
            this.picExtraComments.Click += new System.EventHandler(this.picExtraComments_Click);
            // 
            // btnRemoveSnippet
            // 
            this.btnRemoveSnippet.BackgroundImage = global::Browser.Properties.Resources.beta_general_delete_16;
            this.btnRemoveSnippet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveSnippet.Enabled = false;
            this.btnRemoveSnippet.Location = new System.Drawing.Point(666, 2);
            this.btnRemoveSnippet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.btnRemoveSnippet.Name = "btnRemoveSnippet";
            this.btnRemoveSnippet.Size = new System.Drawing.Size(27, 27);
            this.btnRemoveSnippet.TabIndex = 3;
            this.btnRemoveSnippet.UseVisualStyleBackColor = true;
            this.btnRemoveSnippet.Click += new System.EventHandler(this.btnRemoveSnippet_Click);
            // 
            // btnAddSnippet
            // 
            this.btnAddSnippet.BackgroundImage = global::Browser.Properties.Resources.beta_general_add_16;
            this.btnAddSnippet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddSnippet.Enabled = false;
            this.btnAddSnippet.Location = new System.Drawing.Point(631, 2);
            this.btnAddSnippet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.btnAddSnippet.Name = "btnAddSnippet";
            this.btnAddSnippet.Size = new System.Drawing.Size(27, 27);
            this.btnAddSnippet.TabIndex = 2;
            this.btnAddSnippet.UseVisualStyleBackColor = true;
            this.btnAddSnippet.Click += new System.EventHandler(this.btnAddSnippet_Click);
            this.btnAddSnippet.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnAddSnippet_DragDrop);
            this.btnAddSnippet.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnAddSnippet_DragEnter);
            // 
            // btnEditSnippet
            // 
            this.btnEditSnippet.BackgroundImage = global::Browser.Properties.Resources.beta_general_edit_16;
            this.btnEditSnippet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditSnippet.Enabled = false;
            this.btnEditSnippet.Location = new System.Drawing.Point(596, 2);
            this.btnEditSnippet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.btnEditSnippet.Name = "btnEditSnippet";
            this.btnEditSnippet.Size = new System.Drawing.Size(27, 27);
            this.btnEditSnippet.TabIndex = 1;
            this.btnEditSnippet.UseVisualStyleBackColor = true;
            this.btnEditSnippet.Click += new System.EventHandler(this.btnEditSnippet_Click);
            // 
            // cmsDetails
            // 
            this.cmsDetails.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyRTF,
            this.CopyDetails,
            this.editToolStripMenuItem3});
            this.cmsDetails.Name = "cmsRightClick";
            this.cmsDetails.ShowImageMargin = false;
            this.cmsDetails.Size = new System.Drawing.Size(102, 70);
            this.cmsDetails.Text = "Right Click";
            // 
            // copyRTF
            // 
            this.copyRTF.Name = "copyRTF";
            this.copyRTF.Size = new System.Drawing.Size(101, 22);
            this.copyRTF.Text = "Copy RTF";
            this.copyRTF.Click += new System.EventHandler(this.copyRTFToolStripMenuItem_Click);
            // 
            // CopyDetails
            // 
            this.CopyDetails.Name = "CopyDetails";
            this.CopyDetails.Size = new System.Drawing.Size(101, 22);
            this.CopyDetails.Text = "Copy Text";
            this.CopyDetails.Click += new System.EventHandler(this.CopyDetails_Click);
            // 
            // editToolStripMenuItem3
            // 
            this.editToolStripMenuItem3.Name = "editToolStripMenuItem3";
            this.editToolStripMenuItem3.Size = new System.Drawing.Size(101, 22);
            this.editToolStripMenuItem3.Text = "Edit";
            this.editToolStripMenuItem3.Visible = false;
            // 
            // mnuMain
            // 
            this.mnuMain.AutoSize = false;
            this.mnuMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new System.Windows.Forms.Padding(5, 1, 0, 1);
            this.mnuMain.Size = new System.Drawing.Size(908, 27);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 25);
            this.toolStripMenuItem1.Text = "File";
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Image = global::Browser.Properties.Resources.beta_general_reload_16;
            this.reloadToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.reloadToolStripMenuItem.Text = "Reload Libraries";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(154, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::Browser.Properties.Resources.beta_general_door_outside_16;
            this.exitToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classDetailsToolStripMenuItem,
            this.DesignerPropertiesToolStripMenuItem,
            this.FieldsToolStripMenuItem,
            this.HideBAObjectIfFirstParameterToolStripMenuItem,
            this.LoadXMLOnDemandToolStripMenuItem,
            this.MethodsToolStripMenuItem,
            this.PropertiesToolStripMenuItem,
            this.ShowClassGlobalToolStripMenuItem,
            this.ShowDesignerCreateViewToolStripMenuItem,
            this.ShowEmptyParenthesesToolStripMenuItem,
            this.ShowFullTypenameToolStripMenuItem,
            this.ShowLabelsToolStripMenuItem,
            this.ShowPropertyGetAndSetToolStripMenuItem,
            this.ShowSearchResultsInClassAndLibraryTreeViewToolStripMenuItem,
            this.ShowVoidInUsageToolStripMenuItem,
            this.StayOnTopToolStripMenuItem,
            this.FontSizeToolStripMenuItem});
            this.viewToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 25);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // classDetailsToolStripMenuItem
            // 
            this.classDetailsToolStripMenuItem.CheckOnClick = true;
            this.classDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.classDetailsToolStripMenuItem.Name = "classDetailsToolStripMenuItem";
            this.classDetailsToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.classDetailsToolStripMenuItem.Text = "Class Details";
            this.classDetailsToolStripMenuItem.Click += new System.EventHandler(this.classDetailsToolStripMenuItem_Click);
            // 
            // DesignerPropertiesToolStripMenuItem
            // 
            this.DesignerPropertiesToolStripMenuItem.CheckOnClick = true;
            this.DesignerPropertiesToolStripMenuItem.Image = global::Browser.Properties.Resources.checkbox;
            this.DesignerPropertiesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DesignerPropertiesToolStripMenuItem.Name = "DesignerPropertiesToolStripMenuItem";
            this.DesignerPropertiesToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.DesignerPropertiesToolStripMenuItem.Text = "Designer Properties";
            this.DesignerPropertiesToolStripMenuItem.Click += new System.EventHandler(this.DesignerPropertiesToolStripMenuItem_Click);
            // 
            // FieldsToolStripMenuItem
            // 
            this.FieldsToolStripMenuItem.CheckOnClick = true;
            this.FieldsToolStripMenuItem.Image = global::Browser.Properties.Resources.FieldOrVariable;
            this.FieldsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.FieldsToolStripMenuItem.Name = "FieldsToolStripMenuItem";
            this.FieldsToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.FieldsToolStripMenuItem.Text = "Fields";
            this.FieldsToolStripMenuItem.Click += new System.EventHandler(this.FieldsToolStripMenuItem_Click);
            // 
            // HideBAObjectIfFirstParameterToolStripMenuItem
            // 
            this.HideBAObjectIfFirstParameterToolStripMenuItem.CheckOnClick = true;
            this.HideBAObjectIfFirstParameterToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HideBAObjectIfFirstParameterToolStripMenuItem.Name = "HideBAObjectIfFirstParameterToolStripMenuItem";
            this.HideBAObjectIfFirstParameterToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.HideBAObjectIfFirstParameterToolStripMenuItem.Text = "Hide BA object if first parameter";
            this.HideBAObjectIfFirstParameterToolStripMenuItem.Click += new System.EventHandler(this.HideB4xObjectIfFirstParameterToolStripMenuItem_Click);
            // 
            // LoadXMLOnDemandToolStripMenuItem
            // 
            this.LoadXMLOnDemandToolStripMenuItem.CheckOnClick = true;
            this.LoadXMLOnDemandToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.LoadXMLOnDemandToolStripMenuItem.Name = "LoadXMLOnDemandToolStripMenuItem";
            this.LoadXMLOnDemandToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.LoadXMLOnDemandToolStripMenuItem.Text = "Load XML on demand";
            this.LoadXMLOnDemandToolStripMenuItem.Click += new System.EventHandler(this.LoadXMLOnDemandToolStripMenuItem_Click);
            // 
            // MethodsToolStripMenuItem
            // 
            this.MethodsToolStripMenuItem.CheckOnClick = true;
            this.MethodsToolStripMenuItem.Image = global::Browser.Properties.Resources.MethodOrFunction;
            this.MethodsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MethodsToolStripMenuItem.Name = "MethodsToolStripMenuItem";
            this.MethodsToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.MethodsToolStripMenuItem.Text = "Methods";
            this.MethodsToolStripMenuItem.Click += new System.EventHandler(this.MethodsToolStripMenuItem_Click);
            // 
            // PropertiesToolStripMenuItem
            // 
            this.PropertiesToolStripMenuItem.CheckOnClick = true;
            this.PropertiesToolStripMenuItem.Image = global::Browser.Properties.Resources.Property;
            this.PropertiesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem";
            this.PropertiesToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.PropertiesToolStripMenuItem.Text = "Properties";
            this.PropertiesToolStripMenuItem.Click += new System.EventHandler(this.PropertiesToolStripMenuItem_Click);
            // 
            // ShowClassGlobalToolStripMenuItem
            // 
            this.ShowClassGlobalToolStripMenuItem.CheckOnClick = true;
            this.ShowClassGlobalToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowClassGlobalToolStripMenuItem.Name = "ShowClassGlobalToolStripMenuItem";
            this.ShowClassGlobalToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.ShowClassGlobalToolStripMenuItem.Text = "Show Class_Globals";
            this.ShowClassGlobalToolStripMenuItem.Click += new System.EventHandler(this.ShowClassGlobalToolStripMenuItem_Click);
            // 
            // ShowDesignerCreateViewToolStripMenuItem
            // 
            this.ShowDesignerCreateViewToolStripMenuItem.CheckOnClick = true;
            this.ShowDesignerCreateViewToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowDesignerCreateViewToolStripMenuItem.Name = "ShowDesignerCreateViewToolStripMenuItem";
            this.ShowDesignerCreateViewToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.ShowDesignerCreateViewToolStripMenuItem.Text = "Show DesignerCreateView";
            this.ShowDesignerCreateViewToolStripMenuItem.Click += new System.EventHandler(this.ShowDesignerCreateViewToolStripMenuItem_Click);
            // 
            // ShowEmptyParenthesesToolStripMenuItem
            // 
            this.ShowEmptyParenthesesToolStripMenuItem.CheckOnClick = true;
            this.ShowEmptyParenthesesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowEmptyParenthesesToolStripMenuItem.Name = "ShowEmptyParenthesesToolStripMenuItem";
            this.ShowEmptyParenthesesToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.ShowEmptyParenthesesToolStripMenuItem.Text = "Show empty parentheses";
            this.ShowEmptyParenthesesToolStripMenuItem.Click += new System.EventHandler(this.ShowEmptyParenthesesToolStripMenuItem_Click);
            // 
            // ShowFullTypenameToolStripMenuItem
            // 
            this.ShowFullTypenameToolStripMenuItem.CheckOnClick = true;
            this.ShowFullTypenameToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowFullTypenameToolStripMenuItem.Name = "ShowFullTypenameToolStripMenuItem";
            this.ShowFullTypenameToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.ShowFullTypenameToolStripMenuItem.Text = "Show full typename";
            this.ShowFullTypenameToolStripMenuItem.Click += new System.EventHandler(this.ShowFullTypenameToolStripMenuItem_Click);
            // 
            // ShowLabelsToolStripMenuItem
            // 
            this.ShowLabelsToolStripMenuItem.CheckOnClick = true;
            this.ShowLabelsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowLabelsToolStripMenuItem.Name = "ShowLabelsToolStripMenuItem";
            this.ShowLabelsToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.ShowLabelsToolStripMenuItem.Text = "Show Labels";
            this.ShowLabelsToolStripMenuItem.Click += new System.EventHandler(this.ShowLabelsToolStripMenuItem_Click);
            // 
            // ShowPropertyGetAndSetToolStripMenuItem
            // 
            this.ShowPropertyGetAndSetToolStripMenuItem.CheckOnClick = true;
            this.ShowPropertyGetAndSetToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowPropertyGetAndSetToolStripMenuItem.Name = "ShowPropertyGetAndSetToolStripMenuItem";
            this.ShowPropertyGetAndSetToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.ShowPropertyGetAndSetToolStripMenuItem.Text = "Show Property Get and Set";
            this.ShowPropertyGetAndSetToolStripMenuItem.Click += new System.EventHandler(this.ShowPropertyGetAndSetToolStripMenuItem_Click);
            // 
            // ShowSearchResultsInClassAndLibraryTreeViewToolStripMenuItem
            // 
            this.ShowSearchResultsInClassAndLibraryTreeViewToolStripMenuItem.CheckOnClick = true;
            this.ShowSearchResultsInClassAndLibraryTreeViewToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowSearchResultsInClassAndLibraryTreeViewToolStripMenuItem.Name = "ShowSearchResultsInClassAndLibraryTreeViewToolStripMenuItem";
            this.ShowSearchResultsInClassAndLibraryTreeViewToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.ShowSearchResultsInClassAndLibraryTreeViewToolStripMenuItem.Text = "Show Search Results in Class and Library TreeView";
            this.ShowSearchResultsInClassAndLibraryTreeViewToolStripMenuItem.Click += new System.EventHandler(this.ShowSearchResultsInClassAndLibraryTreeViewToolStripMenuItem_Click);
            // 
            // ShowVoidInUsageToolStripMenuItem
            // 
            this.ShowVoidInUsageToolStripMenuItem.CheckOnClick = true;
            this.ShowVoidInUsageToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowVoidInUsageToolStripMenuItem.Name = "ShowVoidInUsageToolStripMenuItem";
            this.ShowVoidInUsageToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.ShowVoidInUsageToolStripMenuItem.Text = "Show Void in usage";
            this.ShowVoidInUsageToolStripMenuItem.Click += new System.EventHandler(this.ShowVoidInUsageToolStripMenuItem_Click);
            // 
            // StayOnTopToolStripMenuItem
            // 
            this.StayOnTopToolStripMenuItem.CheckOnClick = true;
            this.StayOnTopToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.StayOnTopToolStripMenuItem.Name = "StayOnTopToolStripMenuItem";
            this.StayOnTopToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.StayOnTopToolStripMenuItem.Text = "Stay on top";
            this.StayOnTopToolStripMenuItem.Click += new System.EventHandler(this.StayOnTopToolStripMenuItem_Click);
            // 
            // FontSizeToolStripMenuItem
            // 
            this.FontSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FontSize8ToolStripMenuItem,
            this.FontSize9ToolStripMenuItem,
            this.FontSize10ToolStripMenuItem,
            this.FontSize12ToolStripMenuItem,
            this.FontSize14ToolStripMenuItem,
            this.FontSize16ToolStripMenuItem});
            this.FontSizeToolStripMenuItem.Name = "FontSizeToolStripMenuItem";
            this.FontSizeToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.FontSizeToolStripMenuItem.Text = "Font Size";
            // 
            // FontSize8ToolStripMenuItem
            // 
            this.FontSize8ToolStripMenuItem.CheckOnClick = true;
            this.FontSize8ToolStripMenuItem.Name = "FontSize8ToolStripMenuItem";
            this.FontSize8ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.FontSize8ToolStripMenuItem.Text = "8";
            this.FontSize8ToolStripMenuItem.Click += new System.EventHandler(this.FontSize8ToolStripMenuItem_Click);
            // 
            // FontSize9ToolStripMenuItem
            // 
            this.FontSize9ToolStripMenuItem.CheckOnClick = true;
            this.FontSize9ToolStripMenuItem.Name = "FontSize9ToolStripMenuItem";
            this.FontSize9ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.FontSize9ToolStripMenuItem.Text = "9";
            this.FontSize9ToolStripMenuItem.Click += new System.EventHandler(this.FontSize9ToolStripMenuItem_Click);
            // 
            // FontSize10ToolStripMenuItem
            // 
            this.FontSize10ToolStripMenuItem.CheckOnClick = true;
            this.FontSize10ToolStripMenuItem.Name = "FontSize10ToolStripMenuItem";
            this.FontSize10ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.FontSize10ToolStripMenuItem.Text = "10";
            this.FontSize10ToolStripMenuItem.Click += new System.EventHandler(this.FontSize10ToolStripMenuItem_Click);
            // 
            // FontSize12ToolStripMenuItem
            // 
            this.FontSize12ToolStripMenuItem.CheckOnClick = true;
            this.FontSize12ToolStripMenuItem.Name = "FontSize12ToolStripMenuItem";
            this.FontSize12ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.FontSize12ToolStripMenuItem.Text = "12";
            this.FontSize12ToolStripMenuItem.Click += new System.EventHandler(this.FontSize12ToolStripMenuItem_Click);
            // 
            // FontSize14ToolStripMenuItem
            // 
            this.FontSize14ToolStripMenuItem.CheckOnClick = true;
            this.FontSize14ToolStripMenuItem.Name = "FontSize14ToolStripMenuItem";
            this.FontSize14ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.FontSize14ToolStripMenuItem.Text = "14";
            this.FontSize14ToolStripMenuItem.Click += new System.EventHandler(this.FontSize14ToolStripMenuItem_Click);
            // 
            // FontSize16ToolStripMenuItem
            // 
            this.FontSize16ToolStripMenuItem.CheckOnClick = true;
            this.FontSize16ToolStripMenuItem.Name = "FontSize16ToolStripMenuItem";
            this.FontSize16ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.FontSize16ToolStripMenuItem.Text = "16";
            this.FontSize16ToolStripMenuItem.Click += new System.EventHandler(this.FontSize16ToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CheckForUpdateToolStripMenuItem,
            this.DonateToolStripMenuItem,
            this.enableEditsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.enableSnippetDragDropToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 25);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // CheckForUpdateToolStripMenuItem
            // 
            this.CheckForUpdateToolStripMenuItem.Image = global::Browser.Properties.Resources.beta_general_check_mark_16;
            this.CheckForUpdateToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CheckForUpdateToolStripMenuItem.Name = "CheckForUpdateToolStripMenuItem";
            this.CheckForUpdateToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.CheckForUpdateToolStripMenuItem.Text = "Check for update";
            this.CheckForUpdateToolStripMenuItem.Click += new System.EventHandler(this.CheckForUpdateToolStripMenuItem_Click);
            // 
            // DonateToolStripMenuItem
            // 
            this.DonateToolStripMenuItem.Image = global::Browser.Properties.Resources.beta_general_shopping_cart_16;
            this.DonateToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DonateToolStripMenuItem.Name = "DonateToolStripMenuItem";
            this.DonateToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.DonateToolStripMenuItem.Text = "Donate";
            this.DonateToolStripMenuItem.Click += new System.EventHandler(this.DonateToolStripMenuItem_Click);
            // 
            // enableEditsToolStripMenuItem
            // 
            this.enableEditsToolStripMenuItem.CheckOnClick = true;
            this.enableEditsToolStripMenuItem.Image = global::Browser.Properties.Resources.realvista_general_edit_16;
            this.enableEditsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.enableEditsToolStripMenuItem.Name = "enableEditsToolStripMenuItem";
            this.enableEditsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.enableEditsToolStripMenuItem.Text = "Enable edits";
            this.enableEditsToolStripMenuItem.Visible = false;
            this.enableEditsToolStripMenuItem.Click += new System.EventHandler(this.enableEditsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(206, 6);
            // 
            // enableSnippetDragDropToolStripMenuItem
            // 
            this.enableSnippetDragDropToolStripMenuItem.CheckOnClick = true;
            this.enableSnippetDragDropToolStripMenuItem.Image = global::Browser.Properties.Resources.beta_general_attachment_16;
            this.enableSnippetDragDropToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.enableSnippetDragDropToolStripMenuItem.Name = "enableSnippetDragDropToolStripMenuItem";
            this.enableSnippetDragDropToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.enableSnippetDragDropToolStripMenuItem.Text = "Enable Snippet Drag Drop";
            this.enableSnippetDragDropToolStripMenuItem.Click += new System.EventHandler(this.enableSnippetDragDropToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Image = global::Browser.Properties.Resources.beta_general_gear_16;
            this.optionsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 25);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::Browser.Properties.Resources.beta_general_help_16;
            this.aboutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // lvwDetails
            // 
            this.lvwDetails.BackColor = System.Drawing.SystemColors.Window;
            this.lvwDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Annotation,
            this.Value});
            this.lvwDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwDetails.FullRowSelect = true;
            this.lvwDetails.HideSelection = false;
            this.lvwDetails.Location = new System.Drawing.Point(3, 36);
            this.lvwDetails.MultiSelect = false;
            this.lvwDetails.Name = "lvwDetails";
            this.lvwDetails.ShowGroups = false;
            this.lvwDetails.ShowItemToolTips = true;
            this.lvwDetails.Size = new System.Drawing.Size(294, 76);
            this.lvwDetails.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwDetails.TabIndex = 1;
            this.lvwDetails.UseCompatibleStateImageBehavior = false;
            this.lvwDetails.View = System.Windows.Forms.View.Details;
            this.lvwDetails.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lvwDetails_ColumnWidthChanged);
            this.lvwDetails.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvwDetails_ColumnWidthChanging);
            this.lvwDetails.SizeChanged += new System.EventHandler(this.lvwDetails_SizeChanged);
            // 
            // Annotation
            // 
            this.Annotation.Text = "Annotation";
            this.Annotation.Width = 92;
            // 
            // Value
            // 
            this.Value.Text = "Value";
            this.Value.Width = 172;
            // 
            // lblClassDetails
            // 
            this.lblClassDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblClassDetails.Location = new System.Drawing.Point(0, 0);
            this.lblClassDetails.Name = "lblClassDetails";
            this.lblClassDetails.Size = new System.Drawing.Size(296, 29);
            this.lblClassDetails.TabIndex = 0;
            this.lblClassDetails.Text = "Class Details";
            this.lblClassDetails.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lvwEvents
            // 
            this.lvwEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EventName});
            this.lvwEvents.ContextMenuStrip = this.cmsEvents;
            this.lvwEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwEvents.FullRowSelect = true;
            this.lvwEvents.HideSelection = false;
            this.lvwEvents.Location = new System.Drawing.Point(303, 36);
            this.lvwEvents.MultiSelect = false;
            this.lvwEvents.Name = "lvwEvents";
            this.lvwEvents.ShowGroups = false;
            this.lvwEvents.ShowItemToolTips = true;
            this.lvwEvents.Size = new System.Drawing.Size(295, 76);
            this.lvwEvents.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwEvents.TabIndex = 1;
            this.lvwEvents.UseCompatibleStateImageBehavior = false;
            this.lvwEvents.View = System.Windows.Forms.View.Details;
            this.lvwEvents.SizeChanged += new System.EventHandler(this.lvwEvents_SizeChanged);
            // 
            // EventName
            // 
            this.EventName.Text = "Name";
            this.EventName.Width = 262;
            // 
            // cmsEvents
            // 
            this.cmsEvents.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsEvents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EventCopyText,
            this.EventSearch});
            this.cmsEvents.Name = "cmsRightClick";
            this.cmsEvents.ShowImageMargin = false;
            this.cmsEvents.Size = new System.Drawing.Size(129, 48);
            this.cmsEvents.Text = "Right Click";
            // 
            // EventCopyText
            // 
            this.EventCopyText.Name = "EventCopyText";
            this.EventCopyText.Size = new System.Drawing.Size(128, 22);
            this.EventCopyText.Text = "Copy";
            this.EventCopyText.Click += new System.EventHandler(this.EventCopyText_Click);
            // 
            // EventSearch
            // 
            this.EventSearch.Name = "EventSearch";
            this.EventSearch.Size = new System.Drawing.Size(128, 22);
            this.EventSearch.Text = "Search B4x Site";
            this.EventSearch.Click += new System.EventHandler(this.EventSearch_Click);
            // 
            // lblEvents
            // 
            this.lblEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblEvents.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblEvents.Location = new System.Drawing.Point(0, 0);
            this.lblEvents.Name = "lblEvents";
            this.lblEvents.Size = new System.Drawing.Size(297, 29);
            this.lblEvents.TabIndex = 0;
            this.lblEvents.Text = "Events";
            this.lblEvents.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lvwPermissions
            // 
            this.lvwPermissions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PermissionName});
            this.lvwPermissions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwPermissions.FullRowSelect = true;
            this.lvwPermissions.HideSelection = false;
            this.lvwPermissions.Location = new System.Drawing.Point(604, 36);
            this.lvwPermissions.MultiSelect = false;
            this.lvwPermissions.Name = "lvwPermissions";
            this.lvwPermissions.ShowGroups = false;
            this.lvwPermissions.ShowItemToolTips = true;
            this.lvwPermissions.Size = new System.Drawing.Size(296, 76);
            this.lvwPermissions.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwPermissions.TabIndex = 1;
            this.lvwPermissions.UseCompatibleStateImageBehavior = false;
            this.lvwPermissions.View = System.Windows.Forms.View.Details;
            this.lvwPermissions.SizeChanged += new System.EventHandler(this.lvwPermissions_SizeChanged);
            this.lvwPermissions.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lvwPermissions_MouseMove);
            // 
            // PermissionName
            // 
            this.PermissionName.Text = "Name";
            this.PermissionName.Width = 258;
            // 
            // lblPermissions
            // 
            this.lblPermissions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPermissions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblPermissions.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPermissions.Location = new System.Drawing.Point(0, 0);
            this.lblPermissions.Name = "lblPermissions";
            this.lblPermissions.Size = new System.Drawing.Size(298, 29);
            this.lblPermissions.TabIndex = 0;
            this.lblPermissions.Text = "Permissions";
            this.lblPermissions.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tools
            // 
            this.tools.AutoSize = false;
            this.tools.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolstripExit,
            this.ToolstripReload,
            this.toolStripSeparator1,
            this.toolStripButtonB4a,
            this.toolStripButtonB4i,
            this.toolStripButtonB4j,
            this.toolStripButtonB4r,
            this.toolStripSeparator5,
            this.ToolstripOptions,
            this.toolStripSeparator2,
            this.ToolstripAbout,
            this.Search,
            this.toolStripSeparator3,
            this.B4xHelp,
            this.B4xForum,
            this.SiteSearch,
            this.LanguageAPI});
            this.tools.Location = new System.Drawing.Point(0, 27);
            this.tools.Name = "tools";
            this.tools.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tools.Size = new System.Drawing.Size(908, 37);
            this.tools.TabIndex = 0;
            // 
            // ToolstripExit
            // 
            this.ToolstripExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolstripExit.Image = global::Browser.Properties.Resources.beta_general_door_outside_16;
            this.ToolstripExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolstripExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolstripExit.Name = "ToolstripExit";
            this.ToolstripExit.Size = new System.Drawing.Size(23, 34);
            this.ToolstripExit.Text = "toolStripButton2";
            this.ToolstripExit.ToolTipText = "Exit";
            this.ToolstripExit.Click += new System.EventHandler(this.ToolstripExit_Click);
            // 
            // ToolstripReload
            // 
            this.ToolstripReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolstripReload.Image = global::Browser.Properties.Resources.beta_general_reload_16;
            this.ToolstripReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolstripReload.Name = "ToolstripReload";
            this.ToolstripReload.Size = new System.Drawing.Size(24, 34);
            this.ToolstripReload.Text = "toolStripButton1";
            this.ToolstripReload.ToolTipText = "Reload Libraries";
            this.ToolstripReload.Click += new System.EventHandler(this.ToolstripReload_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripButtonB4a
            // 
            this.toolStripButtonB4a.Checked = true;
            this.toolStripButtonB4a.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonB4a.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonB4a.Image = global::Browser.Properties.Resources.B4a;
            this.toolStripButtonB4a.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonB4a.Name = "toolStripButtonB4a";
            this.toolStripButtonB4a.Size = new System.Drawing.Size(24, 34);
            this.toolStripButtonB4a.Text = "B4a";
            this.toolStripButtonB4a.Visible = false;
            this.toolStripButtonB4a.Click += new System.EventHandler(this.toolStripButtonB4a_Click);
            // 
            // toolStripButtonB4i
            // 
            this.toolStripButtonB4i.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonB4i.Image = global::Browser.Properties.Resources.B4i;
            this.toolStripButtonB4i.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonB4i.Name = "toolStripButtonB4i";
            this.toolStripButtonB4i.Size = new System.Drawing.Size(24, 34);
            this.toolStripButtonB4i.Text = "B4i";
            this.toolStripButtonB4i.Visible = false;
            this.toolStripButtonB4i.Click += new System.EventHandler(this.toolStripButtonB4i_Click);
            // 
            // toolStripButtonB4j
            // 
            this.toolStripButtonB4j.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonB4j.Image = global::Browser.Properties.Resources.B4j;
            this.toolStripButtonB4j.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonB4j.Name = "toolStripButtonB4j";
            this.toolStripButtonB4j.Size = new System.Drawing.Size(24, 34);
            this.toolStripButtonB4j.Text = "B4j";
            this.toolStripButtonB4j.Visible = false;
            this.toolStripButtonB4j.Click += new System.EventHandler(this.toolStripButtonB4j_Click);
            // 
            // toolStripButtonB4r
            // 
            this.toolStripButtonB4r.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStripButtonB4r.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonB4r.Image = global::Browser.Properties.Resources.B4R;
            this.toolStripButtonB4r.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonB4r.Name = "toolStripButtonB4r";
            this.toolStripButtonB4r.Size = new System.Drawing.Size(24, 34);
            this.toolStripButtonB4r.Text = "B4r";
            this.toolStripButtonB4r.Visible = false;
            this.toolStripButtonB4r.Click += new System.EventHandler(this.toolStripButtonB4r_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 37);
            // 
            // ToolstripOptions
            // 
            this.ToolstripOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolstripOptions.Image = global::Browser.Properties.Resources.beta_general_gear_16;
            this.ToolstripOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolstripOptions.Name = "ToolstripOptions";
            this.ToolstripOptions.Size = new System.Drawing.Size(24, 34);
            this.ToolstripOptions.Text = "toolStripButton3";
            this.ToolstripOptions.ToolTipText = "Options";
            this.ToolstripOptions.Click += new System.EventHandler(this.ToolstripOptions_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 37);
            // 
            // ToolstripAbout
            // 
            this.ToolstripAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolstripAbout.Image = global::Browser.Properties.Resources.beta_general_info_16;
            this.ToolstripAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolstripAbout.Name = "ToolstripAbout";
            this.ToolstripAbout.Size = new System.Drawing.Size(24, 34);
            this.ToolstripAbout.Text = "toolStripButton4";
            this.ToolstripAbout.ToolTipText = "About";
            this.ToolstripAbout.Click += new System.EventHandler(this.ToolstripAbout_Click);
            // 
            // Search
            // 
            this.Search.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Search.Image = global::Browser.Properties.Resources.beta_general_binoculars_16;
            this.Search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(24, 34);
            this.Search.Text = "Search";
            this.Search.ToolTipText = "Search";
            this.Search.Visible = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 37);
            // 
            // B4xHelp
            // 
            this.B4xHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.B4xHelp.Image = global::Browser.Properties.Resources.beta_general_help_16;
            this.B4xHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B4xHelp.Name = "B4xHelp";
            this.B4xHelp.Size = new System.Drawing.Size(24, 34);
            this.B4xHelp.Text = "B4x Help";
            this.B4xHelp.ToolTipText = "B4x Help";
            this.B4xHelp.Click += new System.EventHandler(this.B4xHelp_Click);
            // 
            // B4xForum
            // 
            this.B4xForum.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.B4xForum.Image = global::Browser.Properties.Resources.beta_general_world_16;
            this.B4xForum.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B4xForum.Name = "B4xForum";
            this.B4xForum.Size = new System.Drawing.Size(24, 34);
            this.B4xForum.Text = "B4x Forum";
            this.B4xForum.ToolTipText = "B4x Forum";
            this.B4xForum.Click += new System.EventHandler(this.B4xForum_Click);
            // 
            // SiteSearch
            // 
            this.SiteSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SiteSearch.Image = global::Browser.Properties.Resources.beta_general_zoom_16;
            this.SiteSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SiteSearch.Name = "SiteSearch";
            this.SiteSearch.Size = new System.Drawing.Size(24, 34);
            this.SiteSearch.Text = "B4x Site Search";
            this.SiteSearch.ToolTipText = "B4x Site Search";
            this.SiteSearch.Click += new System.EventHandler(this.SiteSearch_Click);
            // 
            // LanguageAPI
            // 
            this.LanguageAPI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LanguageAPI.Image = global::Browser.Properties.Resources.beta_general_preview_16;
            this.LanguageAPI.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LanguageAPI.Name = "LanguageAPI";
            this.LanguageAPI.Size = new System.Drawing.Size(24, 34);
            this.LanguageAPI.Click += new System.EventHandler(this.AndroidPackages_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackgroundImage = global::Browser.Properties.Resources.beta_general_zoom_green_16;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSearch.Location = new System.Drawing.Point(835, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(28, 27);
            this.btnSearch.TabIndex = 0;
            this.tips.SetToolTip(this.btnSearch, "Search");
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearSearch.BackgroundImage = global::Browser.Properties.Resources.beta_general_button_cancel_16;
            this.btnClearSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClearSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClearSearch.Location = new System.Drawing.Point(869, 3);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(28, 27);
            this.btnClearSearch.TabIndex = 1;
            this.tips.SetToolTip(this.btnClearSearch, "Clear");
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.AutoSize = false;
            this.StatusBar.ImageScalingSize = new System.Drawing.Size(10, 10);
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status});
            this.StatusBar.Location = new System.Drawing.Point(0, 574);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.StatusBar.Size = new System.Drawing.Size(908, 24);
            this.StatusBar.Stretch = false;
            this.StatusBar.TabIndex = 3;
            // 
            // Status
            // 
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(26, 19);
            this.Status.Text = "Idle";
            this.Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitMain
            // 
            this.splitMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitMain.BackColor = System.Drawing.SystemColors.Control;
            this.splitMain.Location = new System.Drawing.Point(0, 102);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.tlpClassInfo);
            this.splitMain.Panel1MinSize = 16;
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.pnlMain);
            this.splitMain.Size = new System.Drawing.Size(903, 468);
            this.splitMain.SplitterDistance = 115;
            this.splitMain.SplitterWidth = 5;
            this.splitMain.TabIndex = 2;
            // 
            // tlpClassInfo
            // 
            this.tlpClassInfo.ColumnCount = 3;
            this.tlpClassInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpClassInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpClassInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpClassInfo.Controls.Add(this.lvwPermissions, 2, 1);
            this.tlpClassInfo.Controls.Add(this.lvwEvents, 1, 1);
            this.tlpClassInfo.Controls.Add(this.lvwDetails, 0, 1);
            this.tlpClassInfo.Controls.Add(this.pnlDetails1, 0, 0);
            this.tlpClassInfo.Controls.Add(this.pnlDetails2, 1, 0);
            this.tlpClassInfo.Controls.Add(this.pnlDetails3, 2, 0);
            this.tlpClassInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpClassInfo.Location = new System.Drawing.Point(0, 0);
            this.tlpClassInfo.Margin = new System.Windows.Forms.Padding(2);
            this.tlpClassInfo.Name = "tlpClassInfo";
            this.tlpClassInfo.RowCount = 2;
            this.tlpClassInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tlpClassInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClassInfo.Size = new System.Drawing.Size(903, 115);
            this.tlpClassInfo.TabIndex = 1;
            // 
            // pnlDetails1
            // 
            this.pnlDetails1.Controls.Add(this.lblClassDetails);
            this.pnlDetails1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetails1.Location = new System.Drawing.Point(2, 2);
            this.pnlDetails1.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDetails1.Name = "pnlDetails1";
            this.pnlDetails1.Size = new System.Drawing.Size(296, 29);
            this.pnlDetails1.TabIndex = 0;
            // 
            // pnlDetails2
            // 
            this.pnlDetails2.Controls.Add(this.lblEvents);
            this.pnlDetails2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetails2.Location = new System.Drawing.Point(302, 2);
            this.pnlDetails2.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDetails2.Name = "pnlDetails2";
            this.pnlDetails2.Size = new System.Drawing.Size(297, 29);
            this.pnlDetails2.TabIndex = 1;
            // 
            // pnlDetails3
            // 
            this.pnlDetails3.Controls.Add(this.lblPermissions);
            this.pnlDetails3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetails3.Location = new System.Drawing.Point(603, 2);
            this.pnlDetails3.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDetails3.Name = "pnlDetails3";
            this.pnlDetails3.Size = new System.Drawing.Size(298, 29);
            this.pnlDetails3.TabIndex = 2;
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlMain.Controls.Add(this.split1);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(903, 348);
            this.pnlMain.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(3, 6);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(826, 23);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TabStop = false;
            this.txtSearch.Text = "<Search>";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "B4x Object Browser";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "B4x Object Browser";
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // tlpSearch
            // 
            this.tlpSearch.ColumnCount = 3;
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpSearch.Controls.Add(this.txtSearch, 0, 0);
            this.tlpSearch.Controls.Add(this.btnSearch, 1, 0);
            this.tlpSearch.Controls.Add(this.btnClearSearch, 2, 0);
            this.tlpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpSearch.Location = new System.Drawing.Point(0, 64);
            this.tlpSearch.Margin = new System.Windows.Forms.Padding(2);
            this.tlpSearch.Name = "tlpSearch";
            this.tlpSearch.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.tlpSearch.RowCount = 1;
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch.Size = new System.Drawing.Size(908, 35);
            this.tlpSearch.TabIndex = 5;
            // 
            // tvwClasses
            // 
            this.tvwClasses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvwClasses.ContextMenuStrip = this.cmsDocumentation;
            this.tvwClasses.HideSelection = false;
            this.tvwClasses.ImageIndex = 0;
            this.tvwClasses.ImageList = this.imlObject;
            this.tvwClasses.Location = new System.Drawing.Point(0, 33);
            this.tvwClasses.Margin = new System.Windows.Forms.Padding(0);
            this.tvwClasses.Name = "tvwClasses";
            this.tvwClasses.SelectedImageIndex = 0;
            this.tvwClasses.ShowNodeToolTips = true;
            this.tvwClasses.Size = new System.Drawing.Size(186, 311);
            this.tvwClasses.TabIndex = 1;
            this.tvwClasses.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwClasses_AfterSelect);
            this.tvwClasses.Click += new System.EventHandler(this.tvwClasses_Click);
            // 
            // tvwMethodsPropertiesFields
            // 
            this.tvwMethodsPropertiesFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvwMethodsPropertiesFields.ContextMenuStrip = this.cmsMPF;
            this.tvwMethodsPropertiesFields.ImageIndex = 0;
            this.tvwMethodsPropertiesFields.ImageList = this.imlObject;
            this.tvwMethodsPropertiesFields.Location = new System.Drawing.Point(5, 33);
            this.tvwMethodsPropertiesFields.Name = "tvwMethodsPropertiesFields";
            this.tvwMethodsPropertiesFields.SelectedImageIndex = 0;
            this.tvwMethodsPropertiesFields.Size = new System.Drawing.Size(698, 131);
            this.tvwMethodsPropertiesFields.TabIndex = 1;
            this.tvwMethodsPropertiesFields.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwMethodsPropertiesFields_AfterSelect);
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 598);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.tlpSearch);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.mnuMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.MinimumSize = new System.Drawing.Size(924, 637);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "B4X Object Browser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.split1.Panel1.ResumeLayout(false);
            this.split1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split1)).EndInit();
            this.split1.ResumeLayout(false);
            this.cmsDocumentation.ResumeLayout(false);
            this.split2.Panel1.ResumeLayout(false);
            this.split2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split2)).EndInit();
            this.split2.ResumeLayout(false);
            this.cmsMPF.ResumeLayout(false);
            this.cmsComment.ResumeLayout(false);
            this.tlpCommentSnippets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picExtraComments)).EndInit();
            this.cmsDetails.ResumeLayout(false);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.cmsEvents.ResumeLayout(false);
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.tlpClassInfo.ResumeLayout(false);
            this.pnlDetails1.ResumeLayout(false);
            this.pnlDetails2.ResumeLayout(false);
            this.pnlDetails3.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.tlpSearch.ResumeLayout(false);
            this.tlpSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer split1;
        private System.Windows.Forms.SplitContainer split2;
        private System.Windows.Forms.ImageList imlObject;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsMPF;
        private System.Windows.Forms.ToolStripMenuItem CopyMPFText;
        private System.Windows.Forms.ContextMenuStrip cmsDetails;
        private System.Windows.Forms.ToolStripMenuItem CopyDetails;
        private System.Windows.Forms.ToolStripMenuItem copyRTF;
        private System.Windows.Forms.ContextMenuStrip cmsDocumentation;
        private System.Windows.Forms.ToolStripMenuItem DocumentSelectedLibrary;
        private System.Windows.Forms.ToolStripMenuItem DocumentSelectedClass;
        private System.Windows.Forms.ToolStripMenuItem DocumentAll;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.ToolStripButton ToolstripReload;
        private System.Windows.Forms.ToolStripButton ToolstripExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ToolstripOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton ToolstripAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton B4xHelp;
        private System.Windows.Forms.ToolStripButton B4xForum;
        private System.Windows.Forms.ToolStripButton LanguageAPI;
        private System.Windows.Forms.ToolStripButton SiteSearch;
        private System.Windows.Forms.ToolStripButton Search;
        private System.Windows.Forms.ToolStripMenuItem searchB4xSiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchB4xSiteToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip cmsComment;
        private System.Windows.Forms.ToolStripMenuItem CommentCopyText;
        private System.Windows.Forms.ToolStripMenuItem CommentSearchB4xSite;
        private System.Windows.Forms.ToolStripMenuItem copyRTFToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsEvents;
        private System.Windows.Forms.ToolStripMenuItem EventCopyText;
        private System.Windows.Forms.ToolStripMenuItem EventSearch;
        private System.Windows.Forms.ToolStripMenuItem copyNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyNameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CopyFullPathToolStripMenuItem;
        private System.Windows.Forms.ToolTip tips;
        private System.Windows.Forms.ListView lvwDetails;
        private System.Windows.Forms.ColumnHeader Annotation;
        private System.Windows.Forms.ColumnHeader Value;
        private System.Windows.Forms.ToolTip PermissionsTips;
        private BufferedTreeView tvwClasses;
        private System.Windows.Forms.Label lblClasses;
        private BufferedTreeView tvwMethodsPropertiesFields;
        private System.Windows.Forms.Label lblMethodsPropertiesFields;
        private HtmlRichText.HtmlRichTextBox rtbClassComment;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FieldsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HideBAObjectIfFirstParameterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadXMLOnDemandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MethodsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowEmptyParenthesesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowFullTypenameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowLabelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowSearchResultsInClassAndLibraryTreeViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowVoidInUsageToolStripMenuItem;
        private System.Windows.Forms.Label lblEvents;
        private System.Windows.Forms.Label lblPermissions;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.ToolStripMenuItem ShowPropertyGetAndSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowClassGlobalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowDesignerCreateViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CheckForUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem DonateToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem StayOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButtonB4a;
        private System.Windows.Forms.ToolStripButton toolStripButtonB4i;
        private System.Windows.Forms.ToolStripButton toolStripButtonB4j;
        private System.Windows.Forms.Label lblClassDetails;
        private System.Windows.Forms.ListView lvwEvents;
        private System.Windows.Forms.ColumnHeader EventName;
        private System.Windows.Forms.ListView lvwPermissions;
        private System.Windows.Forms.ColumnHeader PermissionName;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem enableEditsToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tlpCommentSnippets;
        private System.Windows.Forms.ComboBox cmbSnippets;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button btnAddSnippet;
        private System.Windows.Forms.ToolStripMenuItem enableSnippetDragDropToolStripMenuItem;
        private System.Windows.Forms.Button btnRemoveSnippet;
        private System.Windows.Forms.PictureBox picExtraComments;
        private System.Windows.Forms.Button btnEditSnippet;
        private System.Windows.Forms.ToolStripButton toolStripButtonB4r;
        private System.Windows.Forms.TableLayoutPanel tlpSearch;
        private System.Windows.Forms.TableLayoutPanel tlpClassInfo;
        private System.Windows.Forms.Panel pnlDetails1;
        private System.Windows.Forms.Panel pnlDetails2;
        private System.Windows.Forms.Panel pnlDetails3;
        private HtmlRichText.HtmlRichTextBox rtbDocumentation;
        private System.Windows.Forms.ToolStripStatusLabel Status;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripMenuItem OpenFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editXMLFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DesignerPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FontSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FontSize8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FontSize9ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FontSize10ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FontSize12ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FontSize14ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FontSize16ToolStripMenuItem;
    }
}

