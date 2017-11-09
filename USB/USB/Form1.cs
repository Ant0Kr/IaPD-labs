using MediaDevices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USB
{
    public partial class Form1 : Form
    {
        private readonly DeviceController _deviceController = new DeviceController();
        private readonly Printer printer = new Printer();
        private const int NativeWmDeviceСhange = 0x0219;

        public Form1()
        {
            InitializeComponent();
            InitDeviceList();
        }

        private void InitDeviceList()
        {
            if (!InvokeRequired)
            {
                devicesBox.Items.Clear();
                label2.Text = "";
                infoBox.Text = "";
                devicesBox.Items.AddRange(printer.GetDevicesList(_deviceController.GetDevices()));
            }
            else
            {
                Invoke(new Action(InitDeviceList));
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeWmDeviceСhange)
            {
                InitDeviceList();
            }
            base.WndProc(ref m);
        }

        private void devicesBox_MouseClick(object sender, MouseEventArgs e)
        {
            string devName = devicesBox.SelectedItems[0].SubItems[0].Text;
            label2.Text = devName + " device info:";
            infoBox.Text = printer.PrintVolumes(_deviceController.Devices.FirstOrDefault(p => p.Name == devName));
            ejectBtn.Enabled = true;
        }

        private void ejectBtn_Click(object sender, EventArgs e)
        {
            var devName = label2.Text.Substring(0, label2.Text.Length - 13);
            Device device = _deviceController.Devices.FirstOrDefault(p => p.Name == devName);
            if (device?.DeviceType == DeviceType.Generic)
            {
                if(_deviceController.EjectDevice(device))
                {
                    label3.Text = "Device busy.";
                }
                else
                {
                    label3.Text = "";
                }               
            }
            else
            {
                label3.Text = "This device is not supported for eject.";
            }
        }
    }
}
