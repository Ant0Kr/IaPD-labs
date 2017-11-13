using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceManager
{
    public partial class Form1 : Form
    {
        private readonly DeviceController _deviceController = new DeviceController();
        private readonly Printer _printer = new Printer();

        public Form1()
        {
            InitializeComponent();
            InitBox();
        }

        private void InitBox()
        {
            deviceBox.Items.AddRange(_printer.GetDevicesList(_deviceController.Devices));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string devName = deviceBox.SelectedItems[0].SubItems[0].Text;
            Device device = _deviceController.Devices.FirstOrDefault(p => p.Name == devName);
            if (device.State)
            {
                _deviceController.DisableDevice(device);
            }
            else
            {
                _deviceController.EnableDevice(device);
            }
            device.State = !device.State;
            offBtn.Text = device.State ? "Switch off" : "Turn on";
            offBtn.Enabled = false;
        }

        private void deviceBox_MouseClick(object sender, MouseEventArgs e)
        {
            string devName = deviceBox.SelectedItems[0].SubItems[0].Text;
            label3.Text = devName + ":";
            Device device = _deviceController.Devices.FirstOrDefault(p => p.Name == devName);
            infoBox.Text = _printer.PrintDeviceInfo(device);
            offBtn.Text = device.State ? "Switch off" : "Turn on";
            offBtn.Enabled = true;
        }
    }
}
