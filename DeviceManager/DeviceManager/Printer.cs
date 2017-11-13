using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceManager
{
    class Printer
    {
        public ListViewItem[] GetDevicesList(List<Device> devices)
        {
            List<ListViewItem> list = new List<ListViewItem>();
            foreach (var device in devices)
            {
                list.Add(new ListViewItem(device.Name));
            };
            return list.ToArray();
        }

        public string PrintDeviceInfo(Device device)
        {
            string info = "GUID: " + device.ClassGuid +
                "\n\nManufacturer: " + device.Manufacturer +
                "\n\nDeviceID: " + device.DeviceID;
            if (device.HardwareID != null)
            {
                info += "\n\nHardwareID: ";
                for (int i = 0; i < device.HardwareID.Length; i++)
                {
                    info += "\n" + device.HardwareID[i];
                }
            }
            for (int i = 0; i < device.SysFiles.Count; i++)
            {
                info += "\n\nPathName: " + device.SysFiles.ElementAt(i).PathName +
                    "\n\nDescription: " + device.SysFiles.ElementAt(i).Description;
            }
            return info;

        }
    }
}
