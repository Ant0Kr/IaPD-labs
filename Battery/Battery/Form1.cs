using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Battery
{
    public partial class Form1 : Form
    {
        private BatteryController batteryController;
        private Thread batteryControllerThread;
        public Form1()
        {
            InitializeComponent();
            batteryController = new BatteryController();
            batteryController.UpdateBatteryEvent += UpdateBatteryForm;
            batteryController.SetEnableButtonEvent += SetButtonEnable ;
            batteryController.SetDisableButtonEvent +=SetButtonDisable ;
            batteryControllerThread = new Thread(batteryController.UpdateBatteryController); 
            batteryControllerThread.Start();
        }

        private void UpdateBatteryForm(Battery battery)
        {
            if (!InvokeRequired)
            {
                typeLabel.Text = battery.Type ? "AC" : "Battery";
                progressBar.Value = battery.ChargeLevel;
                percentLabel.Text = battery.ChargeLevel.ToString() + "%";
                statusLabel.Text = battery.Status;
                if (battery.Status == "Discharging")
                {
                    statusLabel.Text += ": "+(battery.TimeToDischarge / 60).ToString() + "h " +
                                        (battery.TimeToDischarge % 60).ToString() + "m.";
                }
            }
            else
            {
                Invoke(new Action<Battery>(UpdateBatteryForm), battery);
            }      
        }

        private void SetButtonEnable()
        {
            if (!InvokeRequired)
            {
                numericUpDown1.Enabled = true;
                button1.Enabled = true;
            }
            else
            {
                Invoke(new Action(SetButtonEnable));
            }
        }

        private void SetButtonDisable()
        {
            if (!InvokeRequired)
            {
                numericUpDown1.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                Invoke(new Action(SetButtonDisable));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            batteryController.SetScreenTimeToShutdown((int)numericUpDown1.Value);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            batteryControllerThread.Abort();
            batteryController.SetScreenTimeToShutdown(batteryController._Battery.OldScreenTimeToShutdown);
        }
    }
}
