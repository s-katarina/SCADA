using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Trending.Receiving
{
	class Subcriber
	{
		//public class Callback : PubSubService.IPubSubServiceCallback
		//{
		//	public void MessageArrived(string IOAdress, double value)
		//	{
		//		Console.WriteLine(IOAdress);
		//		Debug.WriteLine(IOAdress);
		//	}
		//}
		//public static PubSubService.PubSubServiceClient subclient;

		//static void Main(string[] args)
		//{
		//	InstanceContext ic = new InstanceContext(new Callback());
		//	subclient = new PubSubService.PubSubServiceClient(ic);
		//	subclient.InitSub();
		//	Console.ReadKey();
		//}
	}
}
