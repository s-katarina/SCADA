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
    public interface IRecordService
    {
        [OperationContract]
        Dictionary<string, double> GetCurrent();

        [OperationContract]
        IEnumerable<Record> GetAll();

        [OperationContract]
        IEnumerable<Record> GetAllInPeriod(DateTime low, DateTime high);

        [OperationContract]
        IEnumerable<Record> MostRecentAI();

        [OperationContract]
        IEnumerable<Record> MostRecentDI();

        [OperationContract]
        IEnumerable<Record> GetAllForTag(string tagName);
    }
}
