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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AlarmCRUDService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AlarmCRUDService.svc or AlarmCRUDService.svc.cs at the Solution Explorer and start debugging.
    public class AlarmCRUDService : IAlarmCRUDService
    {
        public void Add(Alarm alarm)
        {
            using (IODatabase db = new IODatabase())
            {
                db.Alarms.Add(alarm);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Alarm alarm;
            using (IODatabase db = new IODatabase())
            {
                alarm = db.Alarms.Where(d => d.Id == id).First();
                db.Alarms.Remove(alarm);
                db.SaveChanges();

            }
        }

        public IEnumerable<Alarm> GetAll()
        {
            using (IODatabase db = new IODatabase())
            {
                return db.Alarms.ToList();
            }
        }

    }
}
