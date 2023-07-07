using CORE.Database;
using CORE.Interfaces;
using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CORE.Impl
{
    public class DigitalInputService : IDigitalInputService
    {
        public IEnumerable<DigitalInput> GetAll()
        {
            using (IODatabase db = new IODatabase())
            {
                //DigitalInput digitalInput = new DigitalInput()
                //{
                //    TagName = "tag20",
                //    Driver = DriverType.REAL,
                //    IOAddress = "5",
                //    Description = "opis",
                //    ScanTime = 5000,
                //    IsScanning = true
                //};
                //db.DigitalInputs.Add(digitalInput);
                //db.SaveChanges();
                return db.DigitalInputs.ToList();
            }
        }

        public void SendFromRTU(string IOAdress, bool value)
        {
            System.Diagnostics.Debug.WriteLine($"Adress {IOAdress}, Value {value}");

            if (CurrentValues.current.ContainsKey(IOAdress))
                CurrentValues.current[IOAdress] = value ? 1 : 0;
            else
                CurrentValues.current.Add(IOAdress, value ? 1 : 0);

            using (RecordDatabase db = new RecordDatabase())
            {
                db.Records.Add(new Record() { IOAdress = IOAdress, Timestamp = DateTime.Now, Value = value ? 1 : 0 });
                db.SaveChanges();
            }
        }
    }
}
