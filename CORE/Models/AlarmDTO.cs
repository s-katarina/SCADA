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
	public class AlarmDTO
	{
        [DataMember]
		public int Id { get; set; }
        [DataMember]
		public string Priority { get; set; }
        [DataMember]
		public string Type { get; set; }
        [DataMember]
		public double Limit { get; set; }

        [DataMember]
        public string InputTagName { get; set; }

	}
}