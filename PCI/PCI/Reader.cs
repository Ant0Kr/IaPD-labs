using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.IO;

namespace PCI
{
    class Reader
    {
        public ManagementObjectSearcher GetDevicesList()
        {
            return new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity");
        }

        public string[] GetFile(string fileName)
        {
            return File.ReadAllLines(fileName, Encoding.Default);
        }
    }
}
