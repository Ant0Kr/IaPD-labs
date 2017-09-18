using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PCI
{
    class Parser
    {
        private Regex deviceIdExp;
        private Regex vendorIdExp;
        private Regex deviceNameExp;
        private Regex vendorNameExp;

        public Parser()
        {
            deviceIdExp = new Regex("(?<=DEV_)(.{4})");
            vendorIdExp = new Regex("(?<=VEN_)(.{4})");
        }

        public bool CheckContain(ManagementObject device, string key, string name)
        {
            return device[key].ToString().Contains(name);
        }

        public string GetVendorId(ManagementObject device)
        {
            return vendorIdExp.Match(device["DeviceID"].ToString()).ToString().ToLower();
        }

        public string GetDeviceId(ManagementObject device)
        {
            return deviceIdExp.Match(device["DeviceID"].ToString()).ToString().ToLower();
        }

        public void InitRegex(string vendorId, string deviceId)
        {
            vendorNameExp = new Regex("(?<=^" + vendorId + "  )(.+)");
            deviceNameExp = new Regex("(?<=^\t" + deviceId + "  )(.+)");
        }

        public string CheckStringIsVendor(string str)
        {
            return vendorNameExp.Match(str).ToString();
        }

        public string CheckStringIsDevice(string str)
        {
            return deviceNameExp.Match(str).ToString();
        }
    }
}
