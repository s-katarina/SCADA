using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTU.Model.Interfaces
{
    interface RealTimeUnitI
    {
        long Id { get; set; }
        double LowLimit { get; set; }
        double HighLimit { get; set; }
        string Address { get; set; }

        void Work();
    }
}
