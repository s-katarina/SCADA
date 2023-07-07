using CORE.Database;
using CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CORE.Impl
{
    public class RecordService : IRecordService
    {
        public Dictionary<string, double> GetCurrent()
        {
            return CurrentValues.current;
        }
    }
}
