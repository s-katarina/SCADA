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
    public class RecordService : IRecordService
    {
        public Dictionary<string, double> GetCurrent()
        {
            return CurrentValues.current;
        }

        public IEnumerable<Record> GetAll()
        {
            using (RecordDatabase db = new RecordDatabase())
            {
                return db.Records.ToList();
            }
        }

        IEnumerable<Record> IRecordService.GetAllInPeriod(DateTime low, DateTime high)
        {
            using (RecordDatabase db = new RecordDatabase())
            {
                return db.Records.Where(record => record.Timestamp >= low && record.Timestamp <= high).ToList();
            }
        }

        IEnumerable<Record> IRecordService.MostRecentAI()
        {
            List<Record> ret = new List<Record>();
            using (IODatabase ioDb = new IODatabase())
            {
                foreach (AnalogInput a in ioDb.AnalogInputs)
                {
                    using (RecordDatabase recDb = new RecordDatabase())
                    {
                        Record filtered = recDb.Records.Where(record => record.IOAdress.Equals(a.IOAddress)).OrderByDescending(record => record.Timestamp).FirstOrDefault();

                        if (filtered != default)
                            ret.Add(filtered);
                    }
                }
            }

            return ret;
        }

        IEnumerable<Record> IRecordService.MostRecentDI()
        {
            List<Record> ret = new List<Record>();
            using (IODatabase ioDb = new IODatabase())
            {
                foreach (DigitalInput d in ioDb.DigitalInputs)
                {
                    using (RecordDatabase recDb = new RecordDatabase())
                    {
                        Record filtered = recDb.Records.Where(record => record.IOAdress.Equals(d.IOAddress)).OrderByDescending(record => record.Timestamp).FirstOrDefault();

                        if (filtered != default)
                            ret.Add(filtered);
                    }
                }
            }

            return ret;
        }

        IEnumerable<Record> IRecordService.GetAllForTag(string tagName)
        {
            AnalogInput analogInput = null;
            
            using (IODatabase db = new IODatabase())
            {
                foreach (AnalogInput a in db.AnalogInputs)
                    if (a.TagName.Equals(tagName))
                    {
                        analogInput = a;
                        break;
                    }
            }

            if (analogInput == null)
                return new List<Record>();

            using (RecordDatabase db = new RecordDatabase())
            {
                return db.Records.Where(record => record.IOAdress.Equals(analogInput.IOAddress)).ToList();
            }
        }
    }
}
