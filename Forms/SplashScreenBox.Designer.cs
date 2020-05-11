namespace SQLIndexManager {
  partial class SplashScreenBox {
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
      this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
      this.labelVersion = new DevExpress.XtraEditors.LabelControl();
      this.labelProductName = new DevExpress.XtraEditors.LabelControl();
      this.labelCopyright = new DevExpress.XtraEditors.LabelControl();
      this.labelProductDescription = new DevExpress.XtraEditors.LabelControl();
      ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureEdit2
      // 
      this.pictureEdit2.EditValue = global::SQLIndexManager.Properties.Resources.icon;
      this.pictureEdit2.Location = new System.Drawing.Point(12, 12);
      this.pictureEdit2.Name = "pictureEdit2";
      this.pictureEdit2.Properties.AllowFocused = false;
      this.pictureEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
      this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
      this.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      this.pictureEdit2.Properties.ShowMenu = false;
      this.pictureEdit2.Size = new System.Drawing.Size(374, 141);
      this.pictureEdit2.TabIndex = 9;
      // 
      // labelVersion
      // 
      this.labelVersion.Location = new System.Drawing.Point(251, 144);
      this.labelVersion.Name = "labelVersion";
      this.labelVersion.Size = new System.Drawing.Size(35, 13);
      this.labelVersion.TabIndex = 15;
      this.labelVersion.Text = "Version";
      // 
      // labelProductName
      // 
      this.labelProductName.Appearance.Font = new System.Drawing.Font("Tahoma", 12.5F);
      this.labelProductName.Appearance.Options.UseFont = true;
      this.labelProductName.Appearance.Options.UseTextOptions = true;
      this.labelProductName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      this.labelProductName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
      this.labelProductName.Location = new System.Drawing.Point(12, 152);
      this.labelProductName.Name = "labelProductName";
      this.labelProductName.Size = new System.Drawing.Size(374, 29);
      this.labelProductName.TabIndex = 13;
      this.labelProductName.Text = "ProductName";
      // 
      // labelCopyright
      // 
      this.labelCopyright.Appearance.Options.UseTextOptions = true;
      this.labelCopyright.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      this.labelCopyright.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
      this.labelCopyright.Location = new System.Drawing.Point(12, 214);
      this.labelCopyright.Name = "labelCopyright";
      this.labelCopyright.Size = new System.Drawing.Size(374, 13);
      this.labelCopyright.TabIndex = 18;
      this.labelCopyright.Text = "Copyright";
      // 
      // labelProductDescription
      // 
      this.labelProductDescription.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
      this.labelProductDescription.Appearance.Options.UseFont = true;
      this.labelProductDescription.Appearance.Options.UseTextOptions = true;
      this.labelProductDescription.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      this.labelProductDescription.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
      this.labelProductDescription.Location = new System.Drawing.Point(12, 187);
      this.labelProductDescription.Name = "labelProductDescription";
      this.labelProductDescription.Size = new System.Drawing.Size(374, 13);
      this.labelProductDescription.TabIndex = 17;
      this.labelProductDescription.Text = "ProductDescription";
      // 
      // SplashScreenBox
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(401, 251);
      this.Controls.Add(this.labelCopyright);
      this.Controls.Add(this.labelProductDescription);
      this.Controls.Add(this.labelVersion);
      this.Controls.Add(this.labelProductName);
      this.Controls.Add(this.pictureEdit2);
      this.Name = "SplashScreenBox";
      this.ShowIcon = false;
      ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private DevExpress.XtraEditors.PictureEdit pictureEdit2;
    private DevExpress.XtraEditors.LabelControl labelVersion;
    private DevExpress.XtraEditors.LabelControl labelProductName;
    private DevExpress.XtraEditors.LabelControl labelCopyright;
    private DevExpress.XtraEditors.LabelControl labelProductDescription;
  }
}
