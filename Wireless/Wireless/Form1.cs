using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wireless
{
    public partial class Form1 : Form
    {
        private readonly WifiController _wifiController = new WifiController();

        public Form1()
        {
            InitializeComponent();
            InitializeTable();
        }

        private void InitializeTable()
        {
            List<WifiModel>  networks = _wifiController.Scan();
            dataGridView1.Rows.Clear();
            foreach (var network in networks)
            {
                var row = dataGridView1.Rows.Add();
                dataGridView1["SSID", row].Value = network.Ssid;
                dataGridView1["SignalQuality", row].Value = network.SignalQuality;
                dataGridView1["BSSID", row].Value = string.Join("\n", network.Bssids);
                dataGridView1["AuthType", row].Value = network.AuthType;
            }
        }
    }
}
