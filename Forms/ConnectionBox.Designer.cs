namespace SQLIndexManager {
  partial class ConnectionBox {
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
      this.boxServer = new DevExpress.XtraEditors.ComboBoxEdit();
      this.boxAuthType = new DevExpress.XtraEditors.ComboBoxEdit();
      this.boxUser = new DevExpress.XtraEditors.TextEdit();
      this.boxPassword = new DevExpress.XtraEditors.TextEdit();
      this.label1 = new DevExpress.XtraEditors.LabelControl();
      this.label2 = new DevExpress.XtraEditors.LabelControl();
      this.label3 = new DevExpress.XtraEditors.LabelControl();
      this.label4 = new DevExpress.XtraEditors.LabelControl();
      this.boxSavePassword = new DevExpress.XtraEditors.CheckEdit();
      this.progressBar = new DevExpress.XtraEditors.MarqueeProgressBarControl();
      ((System.ComponentModel.ISupportInitialize)(this.boxServer.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.boxAuthType.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.boxUser.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.boxPassword.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.boxSavePassword.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // buttonCancel
      // 
      this.buttonCancel.AllowFocus = false;
      this.buttonCancel.Location = new System.Drawing.Point(283, 163);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 7;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
      // 
      // buttonOK
      // 
      this.buttonOK.AllowFocus = false;
      this.buttonOK.Location = new System.Drawing.Point(202, 163);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new System.Drawing.Size(75, 23);
      this.buttonOK.TabIndex = 6;
      this.buttonOK.Text = "OK";
      this.buttonOK.Click += new System.EventHandler(this.ButtonOkClick);
      // 
      // boxServer
      // 
      this.boxServer.Location = new System.Drawing.Point(95, 15);
      this.boxServer.Name = "boxServer";
      this.boxServer.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
      this.boxServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[]
      {
        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)
      });
      this.boxServer.Properties.ButtonClick +=
        new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.BoxServerPropertiesClick);
      this.boxServer.Size = new System.Drawing.Size(263, 20);
      this.boxServer.TabIndex = 1;
      this.boxServer.SelectedIndexChanged += new System.EventHandler(this.BoxServerSelectionChanged);
      this.boxServer.EditValueChanged += new System.EventHandler(this.EditValueChanged);
      // 
      // boxAuthType
      // 
      this.boxAuthType.Location = new System.Drawing.Point(95, 42);
      this.boxAuthType.Name = "boxAuthType";
      this.boxAuthType.Properties.AutoComplete = false;
      this.boxAuthType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[]
      {
        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
      });
      this.boxAuthType.Properties.Items.AddRange(new object[]
      {
        "Windows Authentication",
        "SQL Server Authentication"
      });
      this.boxAuthType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
      this.boxAuthType.Size = new System.Drawing.Size(263, 20);
      this.boxAuthType.TabIndex = 2;
      this.boxAuthType.SelectedIndexChanged += new System.EventHandler(this.BoxAuthTypeSelectionChanged);
      this.boxAuthType.EditValueChanged += new System.EventHandler(this.EditValueChanged);
      // 
      // boxUser
      // 
      this.boxUser.Location = new System.Drawing.Point(95, 68);
      this.boxUser.Name = "boxUser";
      this.boxUser.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
      this.boxUser.Size = new System.Drawing.Size(263, 20);
      this.boxUser.TabIndex = 3;
      this.boxUser.EditValueChanged += new System.EventHandler(this.EditValueChanged);
      // 
      // boxPassword
      // 
      this.boxPassword.Location = new System.Drawing.Point(95, 94);
      this.boxPassword.Name = "boxPassword";
      this.boxPassword.Properties.UseSystemPasswordChar = true;
      this.boxPassword.Size = new System.Drawing.Size(263, 20);
      this.boxPassword.TabIndex = 4;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(12, 18);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(32, 13);
      this.label1.TabIndex = 10;
      this.label1.Text = "Server";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(11, 44);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(70, 13);
      this.label2.TabIndex = 11;
      this.label2.Text = "Authentication";
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(12, 71);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(22, 13);
      this.label3.TabIndex = 12;
      this.label3.Text = "User";
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(12, 97);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(46, 13);
      this.label4.TabIndex = 13;
      this.label4.Text = "Password";
      // 
      // boxSavePassword
      // 
      this.boxSavePassword.Location = new System.Drawing.Point(95, 120);
      this.boxSavePassword.Name = "boxSavePassword";
      this.boxSavePassword.Properties.Caption = " Save password";
      this.boxSavePassword.Size = new System.Drawing.Size(102, 19);
      this.boxSavePassword.TabIndex = 5;
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
      this.progressBar.Size = new System.Drawing.Size(346, 4);
      this.progressBar.TabIndex = 14;
      this.progressBar.Visible = false;
      // 
      // ConnectionBox
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(370, 197);
      this.Controls.Add(this.progressBar);
      this.Controls.Add(this.boxSavePassword);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.boxPassword);
      this.Controls.Add(this.boxUser);
      this.Controls.Add(this.boxAuthType);
      this.Controls.Add(this.boxServer);
      this.Controls.Add(this.buttonCancel);
      this.Controls.Add(this.buttonOK);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.LookAndFeel.SkinName = "Office 2016 Dark";
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ConnectionBox";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "New Connection";
      ((System.ComponentModel.ISupportInitialize)(this.boxServer.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.boxAuthType.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.boxUser.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.boxPassword.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.boxSavePassword.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraEditors.SimpleButton buttonCancel;
    private DevExpress.XtraEditors.SimpleButton buttonOK;
    private DevExpress.XtraEditors.ComboBoxEdit boxServer;
    private DevExpress.XtraEditors.ComboBoxEdit boxAuthType;
    private DevExpress.XtraEditors.TextEdit boxUser;
    private DevExpress.XtraEditors.TextEdit boxPassword;
    private DevExpress.XtraEditors.LabelControl label1;
    private DevExpress.XtraEditors.LabelControl label2;
    private DevExpress.XtraEditors.LabelControl label3;
    private DevExpress.XtraEditors.LabelControl label4;
    private DevExpress.XtraEditors.CheckEdit boxSavePassword;
    private DevExpress.XtraEditors.MarqueeProgressBarControl progressBar;
  }
}