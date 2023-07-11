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
using System.Runtime.Remoting.Contexts;
using System.Diagnostics;

namespace CORE.Impl
{
    public class AnalogInputService : IAnalogInputService, IScanService
    {
		public void Add(AnalogInput analogInput)
		{
            using (IODatabase db = new IODatabase())
            {
                db.AnalogInputs.Add(analogInput);
                db.SaveChanges();
            }
        }

		public void Delete(string tagName)
		{
            AnalogInput analogInput;
            using (IODatabase db = new IODatabase())
            {
                try
                {
                    var itemsToRemove = db.Alarms.Where(item => item.InputTagName == tagName);
                    foreach (Alarm a in itemsToRemove)
                    {
                        a.AnalogInput = null;
                    }
                    db.SaveChanges();
                } catch (Exception ex) {
                    Debug.WriteLine("Error in deleting alarms from deleting tag: ", ex);
                }
                db.Database.Log = Console.WriteLine;
                analogInput = db.AnalogInputs.Where(d => d.TagName == tagName).First();
                db.AnalogInputs.Remove(analogInput);
                db.SaveChanges();

            }
        }

        public void Edit(string tagName, bool scanning)
        {
            AnalogInput analogInput;
            using (IODatabase db = new IODatabase())
            {
                analogInput = db.AnalogInputs.Where(d => d.TagName == tagName).First();
                if (analogInput != null)
                {
                    analogInput.IsScanning = scanning;
                    db.SaveChanges();
                }

            }
        }

		public IEnumerable<AnalogInput> GetAll()
        {
            using (IODatabase db = new IODatabase())
            {
                //AnalogInput analogInput = new AnalogInput()
                //{
                //    TagName = "tag505",
                //    Description = "opis",
                //    Driver = DriverType.REAL,
                //    HighLimit = 50,
                //    LowLimit = 0,
                //    IOAddress = "22",
                //    IsScanning = true,
                //    ScanTime = 2000,
                //    Units = "ms",
                //    Alarms = new List<Alarm>()
                //};
                //Alarm a1 = new Alarm() { Priority=Priority.FIRST, Type=AlarmType.HIGH, Limit=10, InputTagName="tag505", AnalogInput=analogInput};
                //analogInput.Alarms.Add(a1);
                //db.AnalogInputs.Add(analogInput);
                //db.SaveChanges();
                return db.AnalogInputs.ToList();
            }
        }

        public void SendFromRTU(string IOAdress, double value)
        {
            System.Diagnostics.Debug.WriteLine($"Adress {IOAdress}, Value {value}");

            using (IODatabase db = new IODatabase())
            {
                foreach (AnalogInput analogInput in db.AnalogInputs)
                {
                    if (analogInput.IOAddress.Equals(IOAdress))
                    {
                        if (value > analogInput.HighLimit)
                            value = analogInput.HighLimit;
                        if (value < analogInput.LowLimit)
                            value = analogInput.LowLimit;
                        break;
                    }
                }
            }

            if (CurrentValues.current.ContainsKey(IOAdress))
                CurrentValues.current[IOAdress] = value;
            else
                CurrentValues.current.Add(IOAdress, value);

            using (RecordDatabase db = new RecordDatabase())
            {
                db.Records.Add(new Record() { IOAdress = IOAdress, Timestamp = DateTime.Now, Value = value });

                using (IODatabase iodb = new IODatabase())
                {
                    List<Alarm> alarms = iodb.Alarms.Where(alarm => alarm.AnalogInput.IOAddress.Equals(IOAdress)).ToList();

                    foreach (Alarm alarm in alarms)
                        if (alarm.Type == AlarmType.HIGH && value > alarm.Limit || alarm.Type == AlarmType.LOW && value < alarm.Limit)
                            iodb.RecordAlarms.Add(new RecordAlarm() { Timestamp = DateTime.Now, Alarm = alarm });

                    iodb.SaveChanges();
                }

                db.SaveChanges();
            }

            //IScanCallback proxy = OperationContext.Current.GetCallbackChannel<IScanCallback>();
            //proxy.ScanDone(CurrentValues.current);
        }

        IEnumerable<RecordAlarm> IAnalogInputService.GetAlarmsByTime(DateTime low, DateTime high)
        {
            using (IODatabase db = new IODatabase())
            {
                return db.RecordAlarms.Include(x => x.Alarm).Where(record => (record.Alarm.Priority == Priority.FIRST || record.Alarm.Priority == Priority.SECOND || record.Alarm.Priority == Priority.THIRD) && record.Timestamp <= high && record.Timestamp >= low).ToList();
            }
        }

        IEnumerable<RecordAlarm> IAnalogInputService.GetRecordAlarmsByPriority(Priority priority)
        {
            using (IODatabase db = new IODatabase())
            {
                return db.RecordAlarms.Include(x => x.Alarm).Where(record => record.Alarm.Priority == priority).ToList();
            }
        }
    }
}
