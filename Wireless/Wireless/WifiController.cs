using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SimpleWifi;
using SimpleWifi.Win32;
using SimpleWifi.Win32.Interop;

namespace Wireless
{
    class WifiController
    {
        private readonly Wifi _wifi = new Wifi();
        private readonly WlanClient _wlanClient = new WlanClient();

        public List<WifiModel> Scan()
        { 
            List<WifiModel> networks = new List<WifiModel>();
            try
            {
                IEnumerable<AccessPoint> accessPoints = _wifi.GetAccessPoints();
                foreach (var accessPoint in accessPoints)
                {
                    if (!string.IsNullOrEmpty(accessPoint.Name))
                    {
                        networks.Add(AccessPointToWifiInfo(accessPoint));
                    }
                }
            }          
            catch (Exception)
            {
                return new List<WifiModel>();
            }
            return networks;
        }

        private WifiModel AccessPointToWifiInfo(AccessPoint accessPoint)
        {
            return new WifiModel
            {
                Ssid = accessPoint.Name,
                AuthType = GetAuthTypeFromAccesPoint(accessPoint),
                Bssids = GetBssidsToAccessPoint(accessPoint),
                SignalQuality = (int)accessPoint.SignalStrength,
                IsConnected = accessPoint.IsConnected
            };
        }

        private Dot11AuthAlgorithm GetAuthTypeFromAccesPoint(AccessPoint accessPoint)
        {
            return ((WlanAvailableNetwork)accessPoint?.GetType()
                .GetProperty("Network", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.GetValue(accessPoint, null)).dot11DefaultAuthAlgorithm;
        }

        private List<string> GetBssidsToAccessPoint(AccessPoint accessPoint)
        {
            var wlanInterface = _wlanClient.Interfaces.FirstOrDefault();
            return wlanInterface?.GetNetworkBssList()
                .Where(x => Dot11SsidToString(x.dot11Ssid).Equals(accessPoint.Name))
                .Select(x => Dot11BssidToString(x.dot11Bssid)).ToList();
        }

        private string Dot11SsidToString(Dot11Ssid ssid)
        {
            return Encoding.ASCII.GetString(ssid.SSID, 0, (int)ssid.SSIDLength);
        }

        private string Dot11BssidToString(byte[] dot11Bssid)
        {
            byte[] macAddress = dot11Bssid;
            var macAddressLength = (uint)macAddress.Length;
            var str = new string[(int)macAddressLength];
            for (int i = 0; i < macAddressLength; i++)
            {
                str[i] = macAddress[i].ToString("x2");
            }
            return string.Join(":", str);
        }
    }
}
