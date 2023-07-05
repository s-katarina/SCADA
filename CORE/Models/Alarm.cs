using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CORE.Models
{
	[DataContract]
	public class Alarm
	{
		[DataMember]
		public int Id{ get; set; }
		[DataMember]
		public Priority Priority { get; set; }
		[DataMember]
		public AlarmType Type { get; set; }
		[DataMember]
		public double Limit { get; set; }
		[DataMember]
		public AnalogInput AnalogInput { get; set; }

	}

	public enum Priority { 
		FIRST,
		SECOND,
		THIRD
	}

	public enum AlarmType { 
		HIGH,
		LOW
	}
}