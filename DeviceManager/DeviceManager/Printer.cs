using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DeviceManager
{
    public class Printer
    {
        public ListViewItem[] GetDevicesList(List<Device> devices)
        {
            var list = new List<ListViewItem>();
            foreach (var device in devices)
            {
                list.Add(new ListViewItem(device.Name));
            }
            return list.ToArray();
        }

        public string PrintDeviceInfo(Device device)
        {
            var info = $"GUID: {device.ClassGuid}\n\n" +
                       $"Manufacturer: {device.Manufacturer}\n\n" +
                       $"DeviceID: {device.DeviceId}";
            if (device.HardwareId != null)
            {
                info += "\n\nHardwareID: ";
                foreach (var id in device.HardwareId)
                {
                    info += "\n" + id;
                }
            }
            for (var i = 0; i < device.SysFiles.Count; i++)
            {
                var elem = device.SysFiles.ElementAt(i);
                info += $"\n\nPathName: {elem.PathName}" +
                        $"\n\nDescription: {elem.Description}";
            }
            return info;
        }
    }
}
