using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CORE.Interfaces;

namespace CORE.Impl
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PubSubService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select PubSubService.svc or PubSubService.svc.cs at the Solution Explorer and start debugging.
	public class PubSubService : IPub, ISub
	{
		//static ICallBack proxy;
		delegate void MessageArrivedDelegatte(string IOAdress, double value);
		static event MessageArrivedDelegatte onMessageArrived;
		public void DoWork(string IOAdress, double value)
		{
			//proxy.MessageArrived("aaaaaaaaaa", 1);
			onMessageArrived?.Invoke("Message arived " + IOAdress, 9);
		}

		public void InitSub()
		{
			//proxy = OperationContext.Current.GetCallbackChannel<ICallBack>();
			onMessageArrived += OperationContext.Current.GetCallbackChannel<ICallBack>().MessageArrived;
		}
	}
}
