using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battery
{
    class Battery
    {
        public bool Type { get; set; }
        public int ChargeLevel { get; set; }
        public int TimeToDischarge { get; set; }
        public string Status { get; set; }
    }
}
