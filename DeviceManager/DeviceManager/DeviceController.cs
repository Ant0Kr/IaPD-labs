using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace DeviceManager
{
    public class DeviceController
    {
        private const string SelectRequest = "SELECT * FROM Win32_PNPEntity";
        public List<Device> Devices;

        public DeviceController()
        {
            Devices = new List<Device>();
            var devices = new ManagementObjectSearcher(SelectRequest);

            foreach (var o in devices.Get())
            {
                var device = (ManagementObject)o;
                var sysFiles = new List<SysFile>();
                foreach (var sys in device.GetRelated("Win32_SystemDriver"))
                {
                    sysFiles.Add(new SysFile()
                    {
                        PathName = sys["PathName"]?.ToString(),
                        Description = sys["Description"]?.ToString()
                    });
                }
                Devices.Add(new Device
                {
                    Name = device["Name"]?.ToString() ?? "",
                    ClassGuid = device["ClassGuid"]?.ToString() ?? "",
                    HardwareId = (string[])device["HardwareID"],
                    Manufacturer = device["Manufacturer"]?.ToString() ?? "",
                    DeviceId = device["DeviceID"]?.ToString() ?? "",
                    SysFiles = sysFiles,
                    State = device["Status"].ToString() == "OK"
                });
            }
        }

        public void DisableDevice(Device device)
        {
            var localDevice = new ManagementObjectSearcher(SelectRequest).Get()
                .OfType<ManagementObject>()
                .FirstOrDefault(x => x.Properties["DeviceID"].Value.ToString().Equals(device.DeviceId));
                localDevice?.InvokeMethod("Disable", new object[] { false });
        }

        public void EnableDevice(Device device)
        {
            var localDevice = new ManagementObjectSearcher(SelectRequest).Get()
                 .OfType<ManagementObject>()
                 .FirstOrDefault(x => x["DeviceID"].ToString().Equals(device.DeviceId));
            localDevice?.InvokeMethod("Enable", new object[] { false });
        }
    }
}
