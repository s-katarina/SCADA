using ReportManager.AnalogInputServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager
{
    public class AlarmRecordTable
    {
        public DateTime Timestamp { get; set; }
        public Priority Priority { get; set; }
        public AlarmType Type { get; set; }
        public double Limit { get; set; }
    }
}
