namespace SQLIndexManager {
  partial class NetworkBox {
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
      this.boxNetwork = new DevExpress.XtraEditors.ListBoxControl();
      this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
      this.buttonOK = new DevExpress.XtraEditors.SimpleButton();
      this.progressBar = new DevExpress.XtraEditors.MarqueeProgressBarControl();
      ((System.ComponentModel.ISupportInitialize)(this.boxNetwork)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // boxNetwork
      // 
      this.boxNetwork.Location = new System.Drawing.Point(12, 15);
      this.boxNetwork.Name = "boxNetwork";
      this.boxNetwork.ShowFocusRect = false;
      this.boxNetwork.Size = new System.Drawing.Size(277, 131);
      this.boxNetwork.SortOrder = System.Windows.Forms.SortOrder.Ascending;
      this.boxNetwork.TabIndex = 1;
      // 
      // buttonCancel
      // 
      this.buttonCancel.AllowFocus = false;
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Location = new System.Drawing.Point(214, 152);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 9;
      this.buttonCancel.Text = "Cancel";
      // 
      // buttonOK
      // 
      this.buttonOK.AllowFocus = false;
      this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonOK.Location = new System.Drawing.Point(133, 152);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new System.Drawing.Size(75, 23);
      this.buttonOK.TabIndex = 8;
      this.buttonOK.Text = "OK";
      // 
      // progressBar
      // 
      this.progressBar.EditValue = 0;
      this.progressBar.Location = new System.Drawing.Point(12, 4);
      this.progressBar.Name = "progressBar";
      this.progressBar.Properties.AllowFocused = false;
      this.progressBar.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
      this.progressBar.Properties.Appearance.BackColor2 = System.Drawing.Color.Transparent;
      this.progressBar.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      this.progressBar.Properties.MarqueeAnimationSpeed = 25;
      this.progressBar.Properties.MarqueeWidth = 200;
      this.progressBar.Size = new System.Drawing.Size(277, 4);
      this.progressBar.TabIndex = 15;
      this.progressBar.Visible = false;
      // 
      // NetworkBox
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(301, 186);
      this.Controls.Add(this.progressBar);
      this.Controls.Add(this.buttonCancel);
      this.Controls.Add(this.buttonOK);
      this.Controls.Add(this.boxNetwork);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "NetworkBox";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Network Servers";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NetworkBox_FormClosed);
      ((System.ComponentModel.ISupportInitialize)(this.boxNetwork)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.ListBoxControl boxNetwork;
    private DevExpress.XtraEditors.SimpleButton buttonCancel;
    private DevExpress.XtraEditors.SimpleButton buttonOK;
    private DevExpress.XtraEditors.MarqueeProgressBarControl progressBar;
  }
}