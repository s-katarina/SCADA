using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CORE.Interfaces
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPubSubService" in both code and config file together.
	[ServiceContract (CallbackContract = typeof(ICallBack))]
	public interface ISub
	{
		[OperationContract(IsOneWay = true)]
		void InitSub();

	}

	public interface ICallBack {
		[OperationContract (IsOneWay = true)]
		void MessageArrived(string IOAdress, double value);
	}

	[ServiceContract]
	public interface IPub {
		[OperationContract(IsOneWay = true)]
		void DoWork(string IOAdress, double value);
	}
}

