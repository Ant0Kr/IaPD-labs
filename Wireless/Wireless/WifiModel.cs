using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWifi.Win32.Interop;

namespace Wireless
{
    class WifiModel
    {
        public string Ssid { get; set; }
        public int SignalQuality { get; set; }
        public List<string> Bssids { get; set; }
        public Dot11AuthAlgorithm AuthType { get; set; }
    }
}
