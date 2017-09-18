using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCI
{
    class Device
    {
        private string VendorId;
        private string DeviceId;
        private string VendorName;
        private string DeviceName;

        public string GetVendorId()
        {
            return VendorId;
        }

        public string GetDeviceId()
        {
            return DeviceId;
        }

        public string GetVendorName()
        {
            return VendorName;
        }

        public string GetDeviceName()
        {
            return DeviceName;
        }

        public void SetVendorId(string vendorId)
        {
            this.VendorId = vendorId;
        }

        public void SetDeviceId(string deviceId)
        {
            this.DeviceId = deviceId;
        }

        public void SetVendorName(string vendorName)
        {
            this.VendorName = vendorName;
        }

        public void SetDeviceName(string deviceName)
        {
            this.DeviceName = deviceName;
        }
    }
}
