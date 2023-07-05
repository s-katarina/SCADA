using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CORE.Models
{
	[DataContract]
	public class CompositeType
	{
		bool boolValue = true;
		string stringValue = "Hello ";

		[DataMember]
		public bool BoolValue
		{
			get { return boolValue; }
			set { boolValue = value; }
		}

		[DataMember]
		public string StringValue
		{
			get { return stringValue; }
			set { stringValue = value; }
		}
	}
	[DataContract]
	public class User
	{
		int id;
		string name;
		string surname;
		string username;
		string password;

		[DataMember]
		public int Id { get => id; set => id = value; }
		[DataMember]
		public string Name { get => name; set => name = value; }
		[DataMember]
		public string Surname { get => surname; set => surname = value; }
		[DataMember]
		public string Username { get => username; set => username = value; }
		[DataMember]
		public string Password { get => password; set => password = value; }
	}
}