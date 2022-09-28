namespace SQLIndexManager.Forms {
  partial class ErrorBox {
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
      this.components = new System.ComponentModel.Container();
      this.edError = new DevExpress.XtraEditors.MemoEdit();
      this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.edError.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // edError
      // 
      this.edError.Dock = System.Windows.Forms.DockStyle.Fill;
      this.edError.EditValue = "";
      this.edError.Location = new System.Drawing.Point(0, 0);
      this.edError.Margin = new System.Windows.Forms.Padding(6);
      this.edError.Name = "edError";
      this.edError.Properties.AllowFocused = false;
      this.edError.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      this.edError.Properties.ReadOnly = true;
      this.edError.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.edError.Properties.WordWrap = false;
      this.edError.Size = new System.Drawing.Size(684, 361);
      this.edError.TabIndex = 0;
      // 
      // defaultLookAndFeel
      // 
      this.defaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Dark";
      // 
      // ErrorBox
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(684, 361);
      this.Controls.Add(this.edError);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ErrorBox";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Error";
      ((System.ComponentModel.ISupportInitialize)(this.edError.Properties)).EndInit();
      this.ResumeLayout(false);

    }

    private void BtOk_Click(object sender, System.EventArgs e) {
      this.Close();
    }

    #endregion

    private DevExpress.XtraEditors.MemoEdit edError;
    private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
  }
}