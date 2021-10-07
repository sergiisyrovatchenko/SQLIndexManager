using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SQLIndexManager.Properties;

namespace SQLIndexManager {

  public partial class ConnectionBox : XtraForm {

    public ConnectionBox() {
      InitializeComponent();

      boxServer.Properties.DataSource = Settings.Hosts;
      UpdateServerInfo(0);
    }

    public Host GetHost() {
      return new Host {
        Server = _server,
        AuthType = _authType,
        User = _user,
        Password = _password,
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
      get => (string)boxServer.EditValue;
      set => boxServer.EditValue = value;
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
      UpdateServerInfo(boxServer.ItemIndex);
    }

    private void UpdateServerInfo(int index) {
      if (index == -1) return;

      Host host = Settings.Hosts[index];

      _server = host.Server;
      _authType = host.AuthType;
      _user = host.User;
      _password = host.Password;
      _databases = host.Databases;
    }

    private void BoxAuthTypeSelectionChanged(object sender, EventArgs e) {
      bool sqlAuth = (_authType == AuthTypes.Sql);
      boxUser.Enabled =
          boxPassword.Enabled = sqlAuth;

      if (!sqlAuth) {
        _user = _password = null;
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
            boxPassword.Enabled = (_authType == AuthTypes.Sql);
      }
    }

    private void EditValueChanged(object sender, EventArgs e) {
      buttonOK.Enabled =
          !string.IsNullOrEmpty(_server) && !(string.IsNullOrEmpty(_user) && _authType == AuthTypes.Sql);
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
