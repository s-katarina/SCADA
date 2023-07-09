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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AlarmService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AlarmService.svc or AlarmService.svc.cs at the Solution Explorer and start debugging.
    public class AlarmService : IPubAlarm, ISubAlarm
    {
        delegate void MessageArrivedDelegate(Dictionary<Alarm, double> alarms);
        static event MessageArrivedDelegate onMessageArrived;

        public void DoWork(string IOAdress, double value)
        {
            using (IODatabase iodb = new IODatabase())
            {
                List<Alarm> alarms = iodb.Alarms.Where(alarm => alarm.AnalogInput.IOAddress.Equals(IOAdress)).ToList();

                foreach (Alarm alarm in alarms)
                    if (alarm.Type == AlarmType.HIGH && value > alarm.Limit || alarm.Type == AlarmType.LOW && value < alarm.Limit)
                    {
                        CurrentValues.alarms.Add(alarm, value);
                        Console.WriteLine(value);
                        onMessageArrived?.Invoke(CurrentValues.alarms);
                    }
            }
        }

        public void InitSub()
        {
            onMessageArrived += OperationContext.Current.GetCallbackChannel<ICallBackAlarm>().MessageArrived;
        }
    }
}
