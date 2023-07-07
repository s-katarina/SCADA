using CORE.Interfaces;
using CORE.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CORE.Database;

namespace CORE.Impl
{
    public class AnalogInputService : IAnalogInputService
    {
        public List<AnalogInput> GetAll()
        {
            using (IODatabase db = new IODatabase())
            {
                return db.AnalogInputs.ToList();
            }
        }
    }
}
