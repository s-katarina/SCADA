using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CORE.Models
{
	[DataContract]
	public class User
	{
		[Key]
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public string Surname { get; set; }
		[DataMember]
		public string Username { get; set; }
		[DataMember]
		public string Password { get; set; }
	}
}