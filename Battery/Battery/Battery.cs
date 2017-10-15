using System;
using System.Collections.Generic;
namespace Battery
{
    class Battery
    {
        public bool Type { get; set; }
        public int ChargeLevel { get; set; }
        public int TimeToDischarge { get; set; }
        public string Status { get; set; }
        public int OldScreenTimeToShutdown { get; set; }
    }
}
