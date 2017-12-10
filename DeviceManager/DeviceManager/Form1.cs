using System;
using System.Linq;
using System.Windows.Forms;

namespace DeviceManager
{
    public partial class Form1 : Form
    {
        private readonly DeviceController _deviceController = new DeviceController();
        private readonly Printer _printer = new Printer();
        private const string SwitchOff = "Switch off";
        private const string TurnOn = "Turn on";

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
            var devName = deviceBox.SelectedItems[0].SubItems[0].Text;
            var device = _deviceController.Devices.FirstOrDefault(p => p.Name == devName);
            if (device != null && device.State)
            {
                _deviceController.SetDeviceState(device,"Disable");
            }
            else
            {
                _deviceController.SetDeviceState(device,"Enable");
            }
            if (device != null)
            {
                device.State = !device.State;
                offBtn.Text = device.State ? SwitchOff : TurnOn;
            }
            offBtn.Enabled = false;
        }

        private void deviceBox_MouseClick(object sender, MouseEventArgs e)
        {
            var devName = deviceBox.SelectedItems[0].SubItems[0].Text;
            label3.Text = $@"{devName}:";
            var device = _deviceController.Devices.FirstOrDefault(p => p.Name == devName);
            infoBox.Text = _printer.PrintDeviceInfo(device);
            offBtn.Text = device != null && device.State ? SwitchOff : TurnOn;
            offBtn.Enabled = true;
        }
    }
}
