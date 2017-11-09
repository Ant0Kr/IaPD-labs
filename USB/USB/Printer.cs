using System.Collections.Generic;
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
                    "Name:" + device.Volumes[i].Name + "\n" +
                    "Total: " + device.Volumes[i].Total / BytesInMegabyte + " MB\n" +
                     "Free: " + device.Volumes[i].Free / BytesInMegabyte + " MB\n" +
                         "Used: " + device.Volumes[i].Used / BytesInMegabyte + " MB\n";
            }
            return volumes;
        }
    }
}
