namespace SQLIndexManager {
  partial class ActionBox {
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
      this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
      this.buttonOK = new DevExpress.XtraEditors.SimpleButton();
      this.boxFixAction = new DevExpress.XtraEditors.ComboBoxEdit();
      ((System.ComponentModel.ISupportInitialize)(this.boxFixAction.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // buttonCancel
      // 
      this.buttonCancel.AllowFocus = false;
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Location = new System.Drawing.Point(200, 40);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 7;
      this.buttonCancel.Text = "Cancel";
      // 
      // buttonOK
      // 
      this.buttonOK.AllowFocus = false;
      this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonOK.Location = new System.Drawing.Point(119, 40);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new System.Drawing.Size(75, 23);
      this.buttonOK.TabIndex = 6;
      this.buttonOK.Text = "OK";
      // 
      // boxFixAction
      // 
      this.boxFixAction.Location = new System.Drawing.Point(12, 10);
      this.boxFixAction.Name = "boxFixAction";
      this.boxFixAction.Properties.AllowFocused = false;
      this.boxFixAction.Properties.AutoComplete = false;
      this.boxFixAction.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.boxFixAction.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
      this.boxFixAction.Size = new System.Drawing.Size(263, 20);
      this.boxFixAction.TabIndex = 2;
      // 
      // ActionBox
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 75);
      this.Controls.Add(this.boxFixAction);
      this.Controls.Add(this.buttonCancel);
      this.Controls.Add(this.buttonOK);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.LookAndFeel.SkinName = "Office 2016 Dark";
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ActionBox";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Change Fix Action";
      ((System.ComponentModel.ISupportInitialize)(this.boxFixAction.Properties)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.SimpleButton buttonCancel;
    private DevExpress.XtraEditors.SimpleButton buttonOK;
    private DevExpress.XtraEditors.ComboBoxEdit boxFixAction;
  }
}