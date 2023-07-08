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
    public class AnalogInputService : IAnalogInputService, IScanService
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

        public void SendFromRTU(string IOAdress, double value)
        {
            System.Diagnostics.Debug.WriteLine($"Adress {IOAdress}, Value {value}");

            List<Alarm> alarms = new List<Alarm>();

            foreach (AnalogInput analogInput in GetAll())
                if (analogInput.IOAddress.Equals(IOAdress))
                {
                    alarms = analogInput.Alarms;

                    if (value > analogInput.HighLimit)
                        value = analogInput.HighLimit;
                    if (value < analogInput.LowLimit)
                        value = analogInput.LowLimit;
                    break;
                }

            if (CurrentValues.current.ContainsKey(IOAdress))
                CurrentValues.current[IOAdress] = value;
            else
                CurrentValues.current.Add(IOAdress, value);

            using (RecordDatabase db = new RecordDatabase())
            {
                db.Records.Add(new Record() { IOAdress = IOAdress, Timestamp = DateTime.Now, Value = value });

                db.SaveChanges();
            }

            //IScanCallback proxy = OperationContext.Current.GetCallbackChannel<IScanCallback>();
            //proxy.ScanDone(CurrentValues.current);
        }
    }
}
