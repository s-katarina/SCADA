﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Interfaces
{
    [ServiceContract]
    public interface IRecordService
    {
        [OperationContract]
        Dictionary<string, double> GetCurrent();
    }
}
