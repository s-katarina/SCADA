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
    public class RecordAlarm
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime Timestamp { get; set; }

        [ForeignKey("Alarm")]
        public int AlarmId { get; set; }
        [DataMember]
        public Alarm Alarm { get; set; }

        public override string ToString()
        {
            return $"id {Id}, Timestamp {Timestamp}, Alarm {Alarm == null}";
        }
    }
}