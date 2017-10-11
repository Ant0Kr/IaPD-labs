using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battery
{
    class BatteryController
    {
        public Battery _Battery;
        public delegate void UpdateBatteryControllerDelegate(Battery battery);
        public event UpdateBatteryControllerDelegate UpdateBatteryEvent;

        public void UpdateBatteryController()
        {
            Battery battery = new Battery();
            while (true)
            {
                battery.Type = SystemInformation.PowerStatus.PowerLineStatus.ToString().Equals("Online");
                battery.ChargeLevel = (int)(SystemInformation.PowerStatus.BatteryLifePercent * 100);
                if (SystemInformation.PowerStatus.PowerLineStatus.ToString().Equals("Online"))
                {
                    battery.Status = "Charging";
                }
                else if (SystemInformation.PowerStatus.BatteryLifeRemaining == -1)
                {
                    battery.Status = "Loading result...";
                }
                else
                {
                    battery.Status = "DisCharge";
                    battery.TimeToDischarge = SystemInformation.PowerStatus.BatteryLifeRemaining / 60;
                }
                UpdateBatteryEvent?.Invoke(battery);
                Thread.Sleep(500);
                   
            }
        }
    }
}
