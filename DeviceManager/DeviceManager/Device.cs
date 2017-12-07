using System.Collections.Generic;

namespace DeviceManager
{
    public class Device
    {
        public string Name { get; set; }
        public string ClassGuid { get; set; }
        public string[] HardwareId { get; set; }
        public string Manufacturer { get; set; }
        public List<SysFile> SysFiles { get; set; }
        public string DeviceId { get; set; }
        public bool State { get; set; }
    }
}
