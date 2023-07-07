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
        public IEnumerable<AnalogInput> GetAll()
        {
            using (IODatabase db = new IODatabase())
            {
                //AnalogInput analogInput = new AnalogInput()
                //{
                //    TagName = "tag12",
                //    Description = "opis",
                //    Driver = DriverType.REAL,
                //    HighLimit = 100,
                //    LowLimit = 0,
                //    IOAddress = "1",
                //    IsScanning = true,
                //    ScanTime = 2000,
                //    Units = "ms",
                //    Alarms = new List<Alarm>()
                //};
                //db.AnalogInputs.Add(analogInput);
                //db.SaveChanges();
                return db.AnalogInputs.ToList();
            }
        }

        void IAnalogInputService.SendFromRTU(string IOAdress, double value)
        {
            System.Diagnostics.Debug.WriteLine($"Adress {IOAdress}, Value {value}");

            using (RecordDatabase db = new RecordDatabase())
            {
                db.Records.Add(new Record() { IOAdress = IOAdress, Timestamp = DateTime.Now, Value = value });
                db.SaveChanges();
            }
        }
    }
}
