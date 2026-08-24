namespace Browser
{
    partial class frmSearch
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
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearch));
            this.lblSearchText = new System.Windows.Forms.Label();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.chkParameters = new System.Windows.Forms.CheckBox();
            this.chkAnnotations = new System.Windows.Forms.CheckBox();
            this.chkLibraries = new System.Windows.Forms.CheckBox();
            this.chkClasses = new System.Windows.Forms.CheckBox();
            this.chkMethods = new System.Windows.Forms.CheckBox();
            this.chkProperties = new System.Windows.Forms.CheckBox();
            this.chkFields = new System.Windows.Forms.CheckBox();
            this.imlObject = new System.Windows.Forms.ImageList(this.components);
            this.flpSearchOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.tvwResults = new BufferedTreeView();
            this.grpFilter.SuspendLayout();
            this.flpSearchOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSearchText
            // 
            this.lblSearchText.Location = new System.Drawing.Point(12, 9);
            this.lblSearchText.Name = "lblSearchText";
            this.lblSearchText.Size = new System.Drawing.Size(64, 17);
            this.lblSearchText.TabIndex = 0;
            this.lblSearchText.Text = "Search text";
            // 
            // txtSearchText
            // 
            this.txtSearchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchText.Location = new System.Drawing.Point(82, 6);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(208, 20);
            this.txtSearchText.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(296, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grpFilter
            // 
            this.grpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFilter.Controls.Add(this.flpSearchOptions);
            this.grpFilter.Location = new System.Drawing.Point(12, 29);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(359, 71);
            this.grpFilter.TabIndex = 3;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter";
            // 
            // chkParameters
            // 
            this.chkParameters.AutoSize = true;
            this.chkParameters.Checked = true;
            this.chkParameters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkParameters.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkParameters.Location = new System.Drawing.Point(91, 26);
            this.chkParameters.Name = "chkParameters";
            this.chkParameters.Size = new System.Drawing.Size(79, 17);
            this.chkParameters.TabIndex = 7;
            this.chkParameters.Text = "Parameters";
            this.chkParameters.UseVisualStyleBackColor = true;
            this.chkParameters.CheckedChanged += new System.EventHandler(this.chkParameters_CheckedChanged);
            // 
            // chkAnnotations
            // 
            this.chkAnnotations.AutoSize = true;
            this.chkAnnotations.Checked = true;
            this.chkAnnotations.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAnnotations.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkAnnotations.Location = new System.Drawing.Point(3, 26);
            this.chkAnnotations.Name = "chkAnnotations";
            this.chkAnnotations.Size = new System.Drawing.Size(82, 17);
            this.chkAnnotations.TabIndex = 6;
            this.chkAnnotations.Text = "Annotations";
            this.chkAnnotations.UseVisualStyleBackColor = true;
            this.chkAnnotations.CheckedChanged += new System.EventHandler(this.chkAnnotations_CheckedChanged);
            // 
            // chkLibraries
            // 
            this.chkLibraries.AutoSize = true;
            this.chkLibraries.Checked = true;
            this.chkLibraries.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLibraries.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkLibraries.Location = new System.Drawing.Point(3, 3);
            this.chkLibraries.Name = "chkLibraries";
            this.chkLibraries.Size = new System.Drawing.Size(65, 17);
            this.chkLibraries.TabIndex = 5;
            this.chkLibraries.Text = "Libraries";
            this.chkLibraries.UseVisualStyleBackColor = true;
            this.chkLibraries.CheckedChanged += new System.EventHandler(this.chkLibraries_CheckedChanged);
            // 
            // chkClasses
            // 
            this.chkClasses.AutoSize = true;
            this.chkClasses.Checked = true;
            this.chkClasses.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClasses.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkClasses.Location = new System.Drawing.Point(74, 3);
            this.chkClasses.Name = "chkClasses";
            this.chkClasses.Size = new System.Drawing.Size(62, 17);
            this.chkClasses.TabIndex = 0;
            this.chkClasses.Text = "Classes";
            this.chkClasses.UseVisualStyleBackColor = true;
            this.chkClasses.CheckedChanged += new System.EventHandler(this.chkClasses_CheckedChanged);
            // 
            // chkMethods
            // 
            this.chkMethods.AutoSize = true;
            this.chkMethods.Checked = true;
            this.chkMethods.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMethods.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkMethods.Location = new System.Drawing.Point(142, 3);
            this.chkMethods.Name = "chkMethods";
            this.chkMethods.Size = new System.Drawing.Size(67, 17);
            this.chkMethods.TabIndex = 1;
            this.chkMethods.Text = "Methods";
            this.chkMethods.UseVisualStyleBackColor = true;
            this.chkMethods.CheckedChanged += new System.EventHandler(this.chkMethods_CheckedChanged);
            // 
            // chkProperties
            // 
            this.chkProperties.AutoSize = true;
            this.chkProperties.Checked = true;
            this.chkProperties.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProperties.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkProperties.Location = new System.Drawing.Point(215, 3);
            this.chkProperties.Name = "chkProperties";
            this.chkProperties.Size = new System.Drawing.Size(73, 17);
            this.chkProperties.TabIndex = 2;
            this.chkProperties.Text = "Properties";
            this.chkProperties.UseVisualStyleBackColor = true;
            this.chkProperties.CheckedChanged += new System.EventHandler(this.chkProperties_CheckedChanged);
            // 
            // chkFields
            // 
            this.chkFields.AutoSize = true;
            this.chkFields.Checked = true;
            this.chkFields.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFields.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkFields.Location = new System.Drawing.Point(294, 3);
            this.chkFields.Name = "chkFields";
            this.chkFields.Size = new System.Drawing.Size(53, 17);
            this.chkFields.TabIndex = 3;
            this.chkFields.Text = "Fields";
            this.chkFields.UseVisualStyleBackColor = true;
            this.chkFields.CheckedChanged += new System.EventHandler(this.chkFields_CheckedChanged);
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
            // 
            // flpSearchOptions
            // 
            this.flpSearchOptions.Controls.Add(this.chkLibraries);
            this.flpSearchOptions.Controls.Add(this.chkClasses);
            this.flpSearchOptions.Controls.Add(this.chkMethods);
            this.flpSearchOptions.Controls.Add(this.chkProperties);
            this.flpSearchOptions.Controls.Add(this.chkFields);
            this.flpSearchOptions.Controls.Add(this.chkAnnotations);
            this.flpSearchOptions.Controls.Add(this.chkParameters);
            this.flpSearchOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSearchOptions.Location = new System.Drawing.Point(3, 16);
            this.flpSearchOptions.Name = "flpSearchOptions";
            this.flpSearchOptions.Size = new System.Drawing.Size(353, 52);
            this.flpSearchOptions.TabIndex = 5;
            // 
            // tvwResults
            // 
            this.tvwResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvwResults.ImageIndex = 0;
            this.tvwResults.ImageList = this.imlObject;
            this.tvwResults.Location = new System.Drawing.Point(15, 103);
            this.tvwResults.Name = "tvwResults";
            this.tvwResults.SelectedImageIndex = 0;
            this.tvwResults.Size = new System.Drawing.Size(353, 126);
            this.tvwResults.TabIndex = 5;
            this.tvwResults.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwResults_NodeMouseDoubleClick);
            // 
            // frmSearch
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 241);
            this.Controls.Add(this.tvwResults);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchText);
            this.Controls.Add(this.lblSearchText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(339, 275);
            this.Name = "frmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.TopMost = true;
            this.grpFilter.ResumeLayout(false);
            this.flpSearchOptions.ResumeLayout(false);
            this.flpSearchOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearchText;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.CheckBox chkMethods;
        private System.Windows.Forms.CheckBox chkProperties;
        private System.Windows.Forms.CheckBox chkFields;
        private System.Windows.Forms.ImageList imlObject;
        private System.Windows.Forms.CheckBox chkClasses;
        private System.Windows.Forms.CheckBox chkLibraries;
        private System.Windows.Forms.CheckBox chkAnnotations;
        private System.Windows.Forms.CheckBox chkParameters;
        private System.Windows.Forms.FlowLayoutPanel flpSearchOptions;
        private BufferedTreeView tvwResults;
    }
}