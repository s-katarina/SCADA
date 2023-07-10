using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CORE.Database;
using CORE.Interfaces;
using CORE.Models;

namespace CORE.Impl
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DigitalOutputService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select DigitalOutputService.svc or DigitalOutputService.svc.cs at the Solution Explorer and start debugging.
	public class DigitalOutputService : IDigitalOutputService
	{
		public void Add(DigitalOutput digitalOutput)
		{
			using (IODatabase db = new IODatabase())
			{
				db.DigitalOutputs.Add(digitalOutput);
				db.SaveChanges();
			}
		}

		public void Delete(string tagName)
		{
			DigitalOutput analogOutput;
			using (IODatabase db = new IODatabase())
			{
				db.Database.Log = Console.WriteLine;
				analogOutput = db.DigitalOutputs.Where(d => d.TagName == tagName).First();
				db.DigitalOutputs.Remove(analogOutput);
				db.SaveChanges();

			}
		}

		public void Edit(string tagName, int initialValue)
		{
			DigitalOutput analogInput;
			using (IODatabase db = new IODatabase())
			{
				analogInput = db.DigitalOutputs.Where(d => d.TagName == tagName).First();
				if (analogInput != null)
				{
					analogInput.InitialValue = initialValue;
					db.SaveChanges();
				}

			}
		}

		public IEnumerable<DigitalOutput> GetAll()
		{
			using (IODatabase db = new IODatabase())
			{
				return db.DigitalOutputs.ToList();
			}
		}
	}
}
