using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CORE.Models
{
    [DataContract]
    public class Record
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string IOAdress { get; set; }
        [DataMember]
        public DateTime Timestamp { get; set; }
        [DataMember]
        public double Value { get; set; }
    }
}