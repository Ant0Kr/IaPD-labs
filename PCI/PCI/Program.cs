using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Management;
namespace PCI
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader();
            Printer printer = new Printer();
            ManagementObjectSearcher devices = reader.GetDevicesList();
            string fileName = @"../../pci.ids.txt";
            string[] file = reader.GetFile(fileName);          
            printer.ShowDevices(DevicesHandler(devices,file));
        }

        private static List<Device> DevicesHandler(ManagementObjectSearcher devices,string[] file)
        {
            Parser parser = new Parser();
            List<Device> deviceList = new List<Device>();
            foreach (ManagementObject deviceObj in devices.Get())
            {
                if (parser.CheckContain(deviceObj, "DeviceID", "PCI"))
                {
                    Device newDevice = new Device();
                    newDevice.SetVendorId(parser.GetVendorId(deviceObj));
                    newDevice.SetDeviceId(parser.GetDeviceId(deviceObj));
                    SetDevVenName(file, newDevice,parser);
                    deviceList.Add(newDevice);
                }
            }
            return deviceList;
        }

        private static void SetDevVenName(string[] file, Device newDevice,Parser parser)
        {
            parser.InitRegex(newDevice.GetVendorId(), newDevice.GetDeviceId());
            for (int i = 0; i < file.Count(); i++)
            {
                var venName = parser.CheckStringIsVendor(file[i]);
                if (venName != "")
                {
                    newDevice.SetVendorName(venName);
                    for (int j = i + 1; j < file.Count(); j++)
                    {
                        var devName = parser.CheckStringIsDevice(file[j]);
                        if (devName != "")
                        {
                            newDevice.SetDeviceName(devName);
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }
}
