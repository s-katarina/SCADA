﻿using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Interfaces
{
    [ServiceContract]
    public interface IDigitalInputService
    {
        [OperationContract]
        IEnumerable<DigitalInput> GetAll();

        [OperationContract]
        void SendFromRTU(string IOAdress, bool value);
        [OperationContract]
        void Add(DigitalInput digitalInput);
        [OperationContract]
        void Delete(string tagName);
        [OperationContract]
        void Edit(string tagName, bool scanning);
    }
}
