using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace DeviceManager
{
    public class DeviceController
    {
        private const string SelectRequest = "SELECT * FROM Win32_PNPEntity";
        private const string SystemDriver = "Win32_SystemDriver";
        public List<Device> Devices;

        public DeviceController()
        {
            Devices = new List<Device>();
            var devices = new ManagementObjectSearcher(SelectRequest);

            foreach (var o in devices.Get())
            {
                var device = (ManagementObject)o;
                var sysFiles = new List<SysFile>();
                foreach (var sys in device.GetRelated(SystemDriver))
                {
                    sysFiles.Add(new SysFile
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

        public void SetDeviceState(Device device, string state)
        {
            var localDevice = new ManagementObjectSearcher(SelectRequest).Get()
                .OfType<ManagementObject>()
                .FirstOrDefault(x => x.Properties["DeviceID"].Value.ToString().Equals(device.DeviceId));
            localDevice?.InvokeMethod(state, new object[] { false });
        }
    }
}
