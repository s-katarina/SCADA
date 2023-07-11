using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Interfaces
{
	[ServiceContract(CallbackContract = typeof(ICallBackAlarm))]
	public interface ISubAlarm
	{
		[OperationContract(IsOneWay = true)]
		void InitSub();

	}

	public interface ICallBackAlarm
	{
		[OperationContract(IsOneWay = true)]
		void MessageArrived(IEnumerable<TriggeredAlarm> current);
	}

	[ServiceContract]
	public interface IPubAlarm
	{
		[OperationContract(IsOneWay = true)]
		void DoWork(string IOAdress, double value);
	}
}
