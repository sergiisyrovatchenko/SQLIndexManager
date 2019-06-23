namespace SQLIndexManager {
  partial class AboutBox {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }

      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.labelProductName = new DevExpress.XtraEditors.LabelControl();
      this.label1 = new DevExpress.XtraEditors.LabelControl();
      this.label2 = new DevExpress.XtraEditors.LabelControl();
      this.labelVersion = new DevExpress.XtraEditors.LabelControl();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.labelProductDescription = new DevExpress.XtraEditors.LabelControl();
      this.labelGitHubControl = new DevExpress.XtraEditors.HyperlinkLabelControl();
      this.labelCopyright = new DevExpress.XtraEditors.HyperlinkLabelControl();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.labelMail = new DevExpress.XtraEditors.HyperlinkLabelControl();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // labelProductName
      // 
      this.labelProductName.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
      this.labelProductName.Appearance.Options.UseFont = true;
      this.labelProductName.Location = new System.Drawing.Point(149, 18);
      this.labelProductName.Name = "labelProductName";
      this.labelProductName.Size = new System.Drawing.Size(84, 17);
      this.labelProductName.TabIndex = 0;
      this.labelProductName.Text = "ProductName";
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(149, 65);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(39, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Version:";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(149, 84);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(51, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Copyright:";
      // 
      // labelVersion
      // 
      this.labelVersion.Location = new System.Drawing.Point(225, 65);
      this.labelVersion.Name = "labelVersion";
      this.labelVersion.Size = new System.Drawing.Size(26, 13);
      this.labelVersion.TabIndex = 6;
      this.labelVersion.Text = "Value";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::SQLIndexManager.Properties.Resources.icon;
      this.pictureBox1.Location = new System.Drawing.Point(12, 7);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(128, 128);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox1.TabIndex = 9;
      this.pictureBox1.TabStop = false;
      // 
      // labelProductDescription
      // 
      this.labelProductDescription.Location = new System.Drawing.Point(149, 38);
      this.labelProductDescription.Name = "labelProductDescription";
      this.labelProductDescription.Size = new System.Drawing.Size(90, 13);
      this.labelProductDescription.TabIndex = 10;
      this.labelProductDescription.Text = "ProductDescription";
      // 
      // labelGitHubControl
      // 
      this.labelGitHubControl.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
      this.labelGitHubControl.Appearance.ForeColor = System.Drawing.Color.White;
      this.labelGitHubControl.Appearance.LinkColor = System.Drawing.Color.White;
      this.labelGitHubControl.Appearance.Options.UseFont = true;
      this.labelGitHubControl.Appearance.Options.UseForeColor = true;
      this.labelGitHubControl.Appearance.Options.UseLinkColor = true;
      this.labelGitHubControl.Cursor = System.Windows.Forms.Cursors.Hand;
      this.labelGitHubControl.LineColor = System.Drawing.Color.White;
      this.labelGitHubControl.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.labelGitHubControl.Location = new System.Drawing.Point(149, 158);
      this.labelGitHubControl.Name = "labelGitHubControl";
      this.labelGitHubControl.Size = new System.Drawing.Size(116, 13);
      this.labelGitHubControl.TabIndex = 11;
      this.labelGitHubControl.Text = "Git Hub Project Page";
      this.labelGitHubControl.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.GitHub_HyperlinkClick);
      // 
      // labelCopyright
      // 
      this.labelCopyright.Appearance.ForeColor = System.Drawing.Color.White;
      this.labelCopyright.Appearance.LinkColor = System.Drawing.Color.White;
      this.labelCopyright.Appearance.Options.UseForeColor = true;
      this.labelCopyright.Appearance.Options.UseLinkColor = true;
      this.labelCopyright.Cursor = System.Windows.Forms.Cursors.Hand;
      this.labelCopyright.LineColor = System.Drawing.Color.White;
      this.labelCopyright.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.labelCopyright.Location = new System.Drawing.Point(225, 84);
      this.labelCopyright.Name = "labelCopyright";
      this.labelCopyright.Size = new System.Drawing.Size(26, 13);
      this.labelCopyright.TabIndex = 12;
      this.labelCopyright.Text = "Value";
      this.labelCopyright.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.Copyright_HyperlinkClick);
      // 
      // labelControl1
      // 
      this.labelControl1.Location = new System.Drawing.Point(149, 139);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(211, 13);
      this.labelControl1.TabIndex = 13;
      this.labelControl1.Text = "Please visit for updates and documentation:";
      // 
      // labelControl2
      // 
      this.labelControl2.Location = new System.Drawing.Point(149, 103);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(50, 13);
      this.labelControl2.TabIndex = 14;
      this.labelControl2.Text = "Feedback:";
      // 
      // labelMail
      // 
      this.labelMail.Appearance.ForeColor = System.Drawing.Color.White;
      this.labelMail.Appearance.LinkColor = System.Drawing.Color.White;
      this.labelMail.Appearance.Options.UseForeColor = true;
      this.labelMail.Appearance.Options.UseLinkColor = true;
      this.labelMail.Cursor = System.Windows.Forms.Cursors.Hand;
      this.labelMail.LineColor = System.Drawing.Color.White;
      this.labelMail.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.labelMail.Location = new System.Drawing.Point(225, 103);
      this.labelMail.Name = "labelMail";
      this.labelMail.Size = new System.Drawing.Size(26, 13);
      this.labelMail.TabIndex = 15;
      this.labelMail.Text = "Value";
      this.labelMail.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.labelMail_HyperlinkClick);
      // 
      // AboutBox
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(511, 191);
      this.Controls.Add(this.labelMail);
      this.Controls.Add(this.labelControl2);
      this.Controls.Add(this.labelControl1);
      this.Controls.Add(this.labelCopyright);
      this.Controls.Add(this.labelGitHubControl);
      this.Controls.Add(this.labelProductDescription);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.labelVersion);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.labelProductName);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AboutBox";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "About";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraEditors.LabelControl labelProductName;
    private DevExpress.XtraEditors.LabelControl label1;
    private DevExpress.XtraEditors.LabelControl label2;
    private DevExpress.XtraEditors.LabelControl labelVersion;
    private System.Windows.Forms.PictureBox pictureBox1;
    private DevExpress.XtraEditors.LabelControl labelProductDescription;
    private DevExpress.XtraEditors.HyperlinkLabelControl labelGitHubControl;
    private DevExpress.XtraEditors.HyperlinkLabelControl labelCopyright;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.HyperlinkLabelControl labelMail;
  }
}