using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLIndexManager {

  public partial class NetworkBox : XtraForm {
    readonly CancellationTokenSource _cancel = new CancellationTokenSource(500);

    public NetworkBox() {
      InitializeComponent();

      if (Settings.NetworkHosts.Count == 0) {
        NetworkScanAsync();
      }
      else {
        boxNetwork.Items.AddRange(Settings.NetworkHosts.ToArray());
        UpdateControlUsage(true);
      }
    }

    private async void NetworkScanAsync() {
      boxNetwork.Items.Clear();
      UpdateControlUsage(false);
      
      List<string> localNetworks = await Task.Run(() => StartNetworkScan(_cancel.Token));
      boxNetwork.Items.AddRange(localNetworks.ToArray());
      Settings.NetworkHosts = localNetworks;

      UpdateControlUsage(true);
    }

    private List<string> StartNetworkScan(CancellationToken ct) {
      List<string> localNetworks = new List<string>();

      if (ct.IsCancellationRequested)
        return localNetworks;

      using (OleDbDataReader reader = OleDbEnumerator.GetEnumerator(Type.GetTypeFromProgID("SQLOLEDB Enumerator"))) {
        while (reader.Read()) {
          if (ct.IsCancellationRequested)
            return localNetworks;
          object[] row = new object[reader.FieldCount];
          reader.GetValues(row);
          string networkHost = (string)row[0];

          if (!localNetworks.Contains(networkHost))
            localNetworks.Add(networkHost);
        }
      }

      return localNetworks;
    }

    private void UpdateControlUsage(bool enabled) {
      progressBar.Visible = !enabled;
      buttonOK.Enabled = enabled && boxNetwork.Items.Count > 0;
      boxNetwork.SelectedIndex = 0;
    }

    public string GetNetworkHost() {
      return boxNetwork.SelectedValue.ToString();
    }

    private void NetworkBox_FormClosed(object sender, FormClosedEventArgs e) {
      _cancel.Cancel();
    }

    #region Override Methods

    protected override bool ProcessDialogKey(Keys keyData) {
      if (keyData == Keys.Escape) {
        DialogResult = DialogResult.Cancel;
        return true;
      }

      if (keyData == Keys.Enter && buttonOK.Enabled && boxNetwork.SelectedValue != null) {
        DialogResult = DialogResult.OK;
        return true;
      }

      return base.ProcessDialogKey(keyData);
    }

    #endregion
  }

}
