using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SQLIndexManager.Properties;

namespace SQLIndexManager {

  public partial class ConnectionBox : XtraForm {

    public ConnectionBox() {
      InitializeComponent();

      boxServer.Properties.Items.AddRange(Settings.Hosts.Select(p => p.Server).ToList());
      boxServer.SelectedIndex = 0;
    }

    public Host GetHost() {
      return new Host {
        Server = _server,
        AuthType = _authType,
        User = _user,
        Password = _password,
        SavePassword = _savePassword,
        Databases = _databases,
        IsUserConnection = true,
        ServerInfo = _serverInfo
      };
    }

    #region Connection

    private ThreadWorker _worker;

    private void TryOpenConnection() {
      UpdateControlUsage(false);

      _worker = new ThreadWorker();
      _worker.DoWork += OpenConnection;
      _worker.RunWorkerCompleted += CheckConnection;
      _worker.RunWorkerAsync();
    }

    private void CancelConnection() {
      if (_worker != null && _worker.IsBusy) {
        _worker.RunWorkerCompleted -= CheckConnection;
        _worker.Abort();
        _worker.Dispose();
        UpdateControlUsage(true);
        boxServer.Focus();
      }
      else {
        DialogResult = DialogResult.Cancel;
      }
    }

    private void OpenConnection(object sender, DoWorkEventArgs e) {
      SqlConnection connection = Connection.Create(GetHost());
      connection.Open();
      e.Result = connection;
    }

    private void CheckConnection(object sender, RunWorkerCompletedEventArgs e) {
      UpdateControlUsage(true);

      if (e.Error != null) {
        string errorMsg = e.Error.Message.Replace(". ", "." + Environment.NewLine);
        Output.Current.Add("Error", errorMsg);
        XtraMessageBox.Show(this, errorMsg, e.Error.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
        boxServer.Focus();
        return;
      }

      using (SqlConnection connection = (SqlConnection)e.Result) {
        try {
          _serverInfo = QueryEngine.GetServerInfo(connection);
        }
        catch (Exception ex) {
          string errorMsg = ex.Message.Replace(". ", "." + Environment.NewLine);
          Output.Current.Add("Error", errorMsg);
          XtraMessageBox.Show(errorMsg, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Warning);
          return;
        }
        finally {
          connection.Close();
        }
      }

      if (_serverInfo.MajorVersion < ServerVersion.Sql2008) {
        XtraMessageBox.Show(Resources.MinVersionMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        boxServer.Focus();
      }
      else {
        DialogResult = DialogResult.OK;
      }
    }

    #endregion

    #region Properties

    private string _server {
      get => boxServer.Text;
      set => boxServer.Text = value;
    }

    private AuthTypes _authType {
      get => (AuthTypes)boxAuthType.SelectedIndex;
      set => boxAuthType.SelectedIndex = (int)value;
    }

    private string _user {
      get => boxUser.Text;
      set => boxUser.Text = value;
    }

    private string _password {
      get => boxPassword.Text;
      set => boxPassword.Text = value;
    }

    private bool _savePassword {
      get => boxSavePassword.Checked;
      set => boxSavePassword.Checked = value;
    }

    private List<string> _databases;
    private ServerInfo _serverInfo;

    #endregion

    #region Controls

    private void ButtonOkClick(object sender, EventArgs e) {
      TryOpenConnection();
    }

    private void ButtonCancelClick(object sender, EventArgs e) {
      CancelConnection();
    }

    private void BoxServerSelectionChanged(object sender, EventArgs e) {
      if (boxServer.SelectedIndex != -1) {

        Host host = Settings.Hosts[boxServer.SelectedIndex];

        _server = host.Server;
        _authType = host.AuthType;
        _user = host.User;
        _password = host.Password;
        _savePassword = host.SavePassword;
        _databases = host.Databases;
      }
    }

    private void BoxAuthTypeSelectionChanged(object sender, EventArgs e) {
      bool sqlAuth = (_authType == AuthTypes.SQLSERVER);
      boxUser.Enabled =
          boxPassword.Enabled =
              boxSavePassword.Enabled = sqlAuth;

      if (!sqlAuth) {
        _user = _password = null;
        _savePassword = false;
      }
      else {
        _user = "sa";
      }
    }

    private void UpdateControlUsage(bool enabled) {

      foreach(Control c in Controls) {
        c.Enabled = enabled;
      }

      progressBar.Visible = !enabled;
      buttonCancel.Enabled = true;

      if (enabled) {
        boxUser.Enabled =
            boxPassword.Enabled =
                boxSavePassword.Enabled = (_authType == AuthTypes.SQLSERVER);
      }
    }

    private void EditValueChanged(object sender, EventArgs e) {
      buttonOK.Enabled =
          !string.IsNullOrEmpty(_server) && !(string.IsNullOrEmpty(_user) && _authType == AuthTypes.SQLSERVER);
    }

    #endregion

    #region Override Methods

    protected override bool ProcessDialogKey(Keys keyData) {
      if (keyData == Keys.Escape) {
        CancelConnection();
        return true;
      }

      if (keyData == Keys.Enter && buttonOK.Enabled) {
        TryOpenConnection();
        return true;
      }

      return base.ProcessDialogKey(keyData);
    }

    #endregion

  }

}
