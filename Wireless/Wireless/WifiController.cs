using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading;
using SimpleWifi;
using SimpleWifi.Win32;
using SimpleWifi.Win32.Interop;

namespace Wireless
{
    class WifiController
    {
        private readonly Wifi _wifi = new Wifi();
        private readonly WlanClient _wlanClient = new WlanClient();
        private readonly List<WifiModel> _networks = new List<WifiModel>();

        public delegate void ScanNetworksHandler(List<WifiModel> networks);
        public delegate void PingHostHandler(string response);

        public event ScanNetworksHandler InitializeTable;
        public event PingHostHandler DisplayPing;

        public void Scan()
        {
            while (true)
            {
                _networks.Clear();
                try
                {
                    IEnumerable<AccessPoint> accessPoints = _wifi.GetAccessPoints();
                    foreach (var accessPoint in accessPoints)
                    {
                        if (!string.IsNullOrEmpty(accessPoint.Name))
                        {
                            _networks.Add(new WifiModel
                            {
                                Ssid = accessPoint.Name,
                                AuthType = GetAuthType(accessPoint),
                                Bssids = GetBssids(accessPoint),
                                SignalQuality = (int)accessPoint.SignalStrength,
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    InitializeTable?.Invoke(new List<WifiModel>());
                }
                InitializeTable?.Invoke(_networks);
                Thread.Sleep(5000);
            }
        }

        private Dot11AuthAlgorithm GetAuthType(AccessPoint accessPoint)
        {
            return ((WlanAvailableNetwork)accessPoint?.GetType()
                .GetProperty("Network", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.GetValue(accessPoint, null)).dot11DefaultAuthAlgorithm;
        }

        private List<string> GetBssids(AccessPoint accessPoint)
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
            return string.Join("", str);
        }

        public AccessPoint GetAccessPoint(string ssid, string authType)
        {
            return _wifi.GetAccessPoints().FirstOrDefault(x =>
                x.Name.Equals(ssid) && GetAuthType(x).ToString().Equals(authType));
        }

        public void ConnectToNetwork(AccessPoint accessPoint, string password)
        {
            var authRequest = new AuthRequest(accessPoint);
            if (accessPoint.IsSecure)
            {
                authRequest.Password = password;
            }
            accessPoint.ConnectAsync(authRequest);
        }

        public void Ping(object hostUrl)
        {
            try
            {
                var pingReply = new Ping().Send((string)hostUrl);
                DisplayPing?.Invoke($"Response status:{pingReply?.Status}" +
                                    $" | Response time:{pingReply?.RoundtripTime} ms" +
                                    $" | Host address:{pingReply?.Address}");
            }
            catch (Exception)
            {
                DisplayPing?.Invoke("Error!");
            }
        }
    }
}
