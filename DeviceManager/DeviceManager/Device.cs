using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManager
{
    public class Device
    {
        public string Name { get; set; }
        public string ClassGuid { get; set; }
        public string[] HardwareID { get; set; }
        public string Manufacturer { get; set; }
        public List<SysFile> SysFiles { get; set; }
        public string DeviceID { get; set; }
        public bool State { get; set; }
    }
}
