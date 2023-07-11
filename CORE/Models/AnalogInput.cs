using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CORE.Models
{
	[DataContract]
	public class AnalogInput
	{
		[Key]
		[DataMember]
		public string TagName { get; set; }
		[DataMember]
		public string Description { get; set; }
		[DataMember]
        public DriverType Driver { get; set; }
        [DataMember]
        public string IOAddress { get; set; }
        [DataMember]
        public int ScanTime { get; set; }
        [DataMember]
        public bool IsScanning { get; set; }
        [DataMember]
        public List<Alarm> Alarms { get; set; }
        [DataMember]
        public string Units { get; set; }
        [DataMember]
        public int LowLimit { get; set; }
        [DataMember]
        public int HighLimit { get; set; }
	}
}