using System.Collections.Generic;
using SimpleWifi.Win32.Interop;

namespace Wireless
{
    public class WifiModel
    {
        public string Ssid { get; set; }
        public int SignalQuality { get; set; }
        public List<string> Bssids { get; set; }
        public Dot11AuthAlgorithm AuthType { get; set; }
    }
}
