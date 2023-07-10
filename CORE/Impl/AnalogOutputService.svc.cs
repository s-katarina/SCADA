using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CORE.Database;
using CORE.Interfaces;

namespace CORE.Impl
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AnalogOutput" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select AnalogOutput.svc or AnalogOutput.svc.cs at the Solution Explorer and start debugging.
	public class AnalogOutputService : IAnalogOutputService
	{
		public void Add(Models.AnalogOutput analogOutput)
		{
			using (IODatabase db = new IODatabase())
			{
				db.AnalogOutputs.Add(analogOutput);
				db.SaveChanges();
			}
		}

		public void Delete(string tagName)
		{
			Models.AnalogOutput analogOutput;
			using (IODatabase db = new IODatabase())
			{
				db.Database.Log = Console.WriteLine;
				analogOutput = db.AnalogOutputs.Where(d => d.TagName == tagName).First();
				db.AnalogOutputs.Remove(analogOutput);
				db.SaveChanges();

			}
		}

		public void Edit(string tagName, int initialValue)
		{
			Models.AnalogOutput analogInput;
			using (IODatabase db = new IODatabase())
			{
				analogInput = db.AnalogOutputs.Where(d => d.TagName == tagName).First();
				if (analogInput != null)
				{
					analogInput.InitialValue = initialValue;
					db.SaveChanges();
				}

			}
		}

		public IEnumerable<Models.AnalogOutput> GetAll()
		{
			using (IODatabase db = new IODatabase())
			{
				return db.AnalogOutputs.ToList();
			}
		}
	}
}
