using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CORE.Models;

namespace CORE.Interfaces
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDigitalOutputService" in both code and config file together.
	[ServiceContract]
	public interface IDigitalOutputService
	{
		[OperationContract]
		IEnumerable<DigitalOutput> GetAll();
		[OperationContract]
		void Add(DigitalOutput digitalOutput);
		[OperationContract]
		void Delete(string tagName);
		[OperationContract]
		void Edit(string tagName, int initialValue);
	}
}
