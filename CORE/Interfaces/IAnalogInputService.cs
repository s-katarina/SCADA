using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Interfaces
{
    [ServiceContract]
    public interface IAnalogInputService
    {
        [OperationContract]
        IEnumerable<AnalogInput> GetAll();

        [OperationContract]
        void SendFromRTU(string IOAdress, double value);

        [OperationContract]
        IEnumerable<RecordAlarm> GetAlarmsByTime (DateTime low, DateTime high);

        [OperationContract]
        IEnumerable<RecordAlarm> GetRecordAlarmsByPriority(Priority priority);
    }
}
