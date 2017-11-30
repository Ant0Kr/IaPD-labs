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
        private readonly Thread _scannerThread;

        public Form1()
        {
            InitializeComponent();
            _wifiController.InitializeTable += InitializeTable;
            _wifiController.DisplayPing += DisplayPing;
            _scannerThread = new Thread(_wifiController.Scan);
            _scannerThread.Start();
        }

        private void InitializeTable(List<WifiModel> networks)
        {
            if (!InvokeRequired)
            {
                dataGridView1.Rows.Clear();
                foreach (var network in networks)
                {
                    var row = dataGridView1.Rows.Add();
                    dataGridView1["SSID", row].Value = network.Ssid;
                    dataGridView1["SignalQuality", row].Value = network.SignalQuality;
                    dataGridView1["BSSID", row].Value = string.Join("", network.Bssids);
                    dataGridView1["AuthType", row].Value = network.AuthType;
                }
            }
            else
            {
                Invoke(new Action<List<WifiModel>>(InitializeTable), networks);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string authType = null;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1["SSID", i].Value.ToString() == textBox1.Text)
                {
                    authType = dataGridView1["AuthType", i].Value.ToString();
                    break;
                }
            }
            if (authType != null)
            {
                var accessPoint = _wifiController.GetAccessPoint(textBox1.Text, authType);
                _wifiController.ConnectToNetwork(accessPoint, textBox2.Text);
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _scannerThread.Abort();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Thread(_wifiController.Ping).Start(textBox3.Text);
        }

        private void DisplayPing(string response)
        {
            label4.Text = response;
        }
    }
}
