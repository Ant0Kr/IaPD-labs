using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USB
{
    public class Volume
    {
        public string Name { get; set; }
        public long Free { get; set; }
        public long Total { get; set; }
        public long Used { get; set; }
    }
}
