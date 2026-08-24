namespace Browser
{
    partial class frmSnippet
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
            this.lblLabel = new System.Windows.Forms.Label();
            this.textBoxSnippetLabel = new System.Windows.Forms.TextBox();
            this.lblSnippetText = new System.Windows.Forms.Label();
            this.htmlSnippet = new HtmlRichText.HtmlRichTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblObject = new System.Windows.Forms.Label();
            this.txtObject = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblLabel
            // 
            this.lblLabel.Location = new System.Drawing.Point(20, 65);
            this.lblLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(112, 28);
            this.lblLabel.TabIndex = 3;
            this.lblLabel.Text = "Label";
            // 
            // textBoxSnippetLabel
            // 
            this.textBoxSnippetLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSnippetLabel.Location = new System.Drawing.Point(142, 60);
            this.textBoxSnippetLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxSnippetLabel.Name = "textBoxSnippetLabel";
            this.textBoxSnippetLabel.Size = new System.Drawing.Size(607, 26);
            this.textBoxSnippetLabel.TabIndex = 2;
            this.textBoxSnippetLabel.TextChanged += new System.EventHandler(this.textBoxSnippetLabel_TextChanged);
            // 
            // lblSnippetText
            // 
            this.lblSnippetText.Location = new System.Drawing.Point(18, 95);
            this.lblSnippetText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSnippetText.Name = "lblSnippetText";
            this.lblSnippetText.Size = new System.Drawing.Size(116, 28);
            this.lblSnippetText.TabIndex = 4;
            this.lblSnippetText.Text = "Snippet Text";
            // 
            // htmlSnippet
            // 
            this.htmlSnippet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.htmlSnippet.EnableAutoDragDrop = true;
            this.htmlSnippet.Location = new System.Drawing.Point(22, 128);
            this.htmlSnippet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.htmlSnippet.Name = "htmlSnippet";
            this.htmlSnippet.Size = new System.Drawing.Size(727, 446);
            this.htmlSnippet.TabIndex = 5;
            this.htmlSnippet.Text = "";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(518, 585);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(112, 35);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(639, 585);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblObject
            // 
            this.lblObject.Location = new System.Drawing.Point(21, 25);
            this.lblObject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblObject.Name = "lblObject";
            this.lblObject.Size = new System.Drawing.Size(112, 26);
            this.lblObject.TabIndex = 0;
            this.lblObject.Text = "Object";
            // 
            // txtObject
            // 
            this.txtObject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObject.Location = new System.Drawing.Point(142, 20);
            this.txtObject.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtObject.Name = "txtObject";
            this.txtObject.ReadOnly = true;
            this.txtObject.Size = new System.Drawing.Size(607, 26);
            this.txtObject.TabIndex = 1;
            // 
            // frmSnippet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 638);
            this.Controls.Add(this.txtObject);
            this.Controls.Add(this.lblObject);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.htmlSnippet);
            this.Controls.Add(this.lblSnippetText);
            this.Controls.Add(this.textBoxSnippetLabel);
            this.Controls.Add(this.lblLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(589, 462);
            this.Name = "frmSnippet";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Snippets";
            this.Load += new System.EventHandler(this.frmSnippet_Load);
            this.Shown += new System.EventHandler(this.frmSnippet_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.TextBox textBoxSnippetLabel;
        private System.Windows.Forms.Label lblSnippetText;
        private HtmlRichText.HtmlRichTextBox htmlSnippet;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblObject;
        private System.Windows.Forms.TextBox txtObject;
    }
}