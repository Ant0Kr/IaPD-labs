using MediaDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USB
{
    public class Device
    {
        public string Name { get; set; }
        public DeviceType DeviceType { get; set; }
        public List<Volume> Volumes { get; set; }
    }
}
