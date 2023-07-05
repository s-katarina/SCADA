﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CORE.Models
{
	[DataContract]
	public class DigitalOutput
	{
		[DataMember]
		public string TagName { get; set; }
		[DataMember]
		public string Description { get; set; }
		[DataMember]
		public string IOAddress { get; set; }
		[DataMember]
		public int InitialValue { get; set; }
	}
}