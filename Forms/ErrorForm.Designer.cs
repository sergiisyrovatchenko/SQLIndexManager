namespace SQLIndexManager {
  partial class ErrorForm {
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
      this.edError = new DevExpress.XtraEditors.MemoEdit();
      this.btOk = new DevExpress.XtraEditors.CloseButton();
      this.SuspendLayout();
      // 
      // edError
      // 
      this.edError.Location = new System.Drawing.Point(12, 0);
      this.edError.Name = "edError";
      this.edError.Properties.ReadOnly = true;
      this.edError.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.edError.Size = new System.Drawing.Size(427, 260);
      this.edError.Text = "";
      this.edError.Properties.WordWrap = false;
      this.edError.TabIndex = 0;
      // 
      // btOk
      // 
      this.btOk.Location = new System.Drawing.Point(210, 267);
      this.btOk.Name = "btOk";
      this.btOk.Size = new System.Drawing.Size(60, 24);
      this.btOk.Click += BtOk_Click;
      this.btOk.Text = "Close";
      // 
      // ErrorForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(461, 296);
      this.Controls.Add(this.edError);
      this.Controls.Add(this.btOk);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ErrorForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Unexpected error";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    private void BtOk_Click(object sender, System.EventArgs e) {

      this.Close();
    }

    #endregion

    private DevExpress.XtraEditors.MemoEdit edError;
    private DevExpress.XtraEditors.CloseButton btOk;
  }
}