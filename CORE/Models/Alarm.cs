using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CORE.Models
{
	[DataContract]
	public class Alarm
	{
		[Key]
		[DataMember]
		public int Id{ get; set; }
		[DataMember]
		public Priority Priority { get; set; }
		[DataMember]
		public AlarmType Type { get; set; }
		[DataMember]
		public double Limit { get; set; }
		[DataMember]
		public DateTime Timestamp { get; set; }

		[ForeignKey("AnalogInput")]
		public string InputTagName { get; set; }
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