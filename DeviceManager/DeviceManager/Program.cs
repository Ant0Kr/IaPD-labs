using System;
using System.Management;
using System.Windows.Forms;
namespace DeviceManager
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var a = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity");
            foreach (var test in a.Get())
            {
                var c = test["DeviceID"];
                var d = test["HardwareID"];
                //var e = test["GUID"];
                var f = test["Manufacturer"];
                var g = test["Provider"];
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }
    }
}
