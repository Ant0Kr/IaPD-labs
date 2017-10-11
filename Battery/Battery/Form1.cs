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

namespace Battery
{
    public partial class Form1 : Form
    {
        private BatteryController batteryController;
        private Thread batteryControllerThread;
        public Form1()
        {
            batteryController = new BatteryController();
            batteryController.UpdateBatteryEvent += UpdateBatteryForm;
            batteryControllerThread = new Thread(batteryController.UpdateBatteryController);
            InitializeComponent();
            batteryControllerThread.Start();
        }

        private void UpdateBatteryForm(Battery battery)
        {
            TypeLabel.Text = battery.Type ? "AC" : "Battery";
            progressBar.Value = battery.ChargeLevel;
            percentLabel.Text = battery.ChargeLevel.ToString()+"%";
            if(battery.Status == "DisCharge")
            {
                statusLabel.Text = (battery.TimeToDischarge / 60).ToString() + "h " +
                                    (battery.TimeToDischarge % 60).ToString() + "m";
            }
            else
            {
                statusLabel.Text = battery.Status;
            }
                
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            batteryControllerThread.Abort();
        }
    }
}
