using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USB
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            DeviceController a = new DeviceController();
            a.GetDevices();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }
    }
}
