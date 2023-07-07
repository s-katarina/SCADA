using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Interfaces
{
    [ServiceContract(CallbackContract = typeof(IScanCallback))]
    public interface IScanService
    {
    }

    public interface IScanCallback
    {
        [OperationContract(IsOneWay = true)]
        void ScanDone(Dictionary<string, double> current);
    }
}
