using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCI
{
    class Printer
    {
        public void ShowDevices(List<Device> deviceList)
        {
            foreach(Device device in deviceList)
            {
                Console.WriteLine("{0} {1}", device.GetVendorName(), device.GetDeviceName());
                Console.WriteLine("VendorID:{0}", device.GetVendorId());
                Console.WriteLine("DeviceID:{0}", device.GetDeviceId());
                Console.WriteLine("*************");
            }          
        }
    }
}
