using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CORE.Database
{
    public class CurrentValues
    {
        public static Dictionary<string, double> current = new Dictionary<string, double>();
        public static Dictionary<Alarm, double> alarms = new Dictionary<Alarm, double>();
    }
}