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
    public interface IAlarmCRUDService
    {
        [OperationContract]
        void Add(Alarm alarm, string tagName);
        [OperationContract]
        void Delete(int id);
        [OperationContract]
        IEnumerable<AlarmDTO> GetAll();
    }
}
