using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USB
{
    class Printer
    {
        private const long BytesInMegabyte = 1048576;
        public ListViewItem[] GetDevicesList(List<Device> devices)
        {
            List<ListViewItem> list = new List<ListViewItem>();
            foreach (var device in devices)
            {
                list.Add(new ListViewItem(device.Name));
            };
            return list.ToArray();
        }

        public string PrintVolumes(Device device)
        {
            string volumes = "";
            for (int i = 0; i < device.Volumes.Count; i++)
            {
                volumes += "- - - - - - - - - -\n" +
                    "\tName:" + device.Volumes[i].Name + "\n" +
                    "\tTotal: " + device.Volumes[i].Total / BytesInMegabyte + " MB\n" +
                     "\tFree: " + device.Volumes[i].Free / BytesInMegabyte + " MB\n" +
                         "\tUsed: " + device.Volumes[i].Used / BytesInMegabyte + " MB\n";
            }

            return volumes;

        }
    }
}
