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
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PubSubService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select PubSubService.svc or PubSubService.svc.cs at the Solution Explorer and start debugging.
	public class PubSubService : IPub, ISub
	{
		//static ICallBack proxy;
		delegate void MessageArrivedDelegatte(Dictionary<string, double> currente);
		static event MessageArrivedDelegatte onMessageArrived;
		public void DoWork(string IOAdress, double value)
		{
            //proxy.MessageArrived("aaaaaaaaaa", 1);
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

            onMessageArrived?.Invoke(CurrentValues.current);
		}

		public void InitSub()
		{
			//proxy = OperationContext.Current.GetCallbackChannel<ICallBack>();
			onMessageArrived += OperationContext.Current.GetCallbackChannel<ICallBack>().MessageArrived;
		}
	}
}
