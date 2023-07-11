using CORE.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CORE.Database
{
    public class IODatabase : DbContext
    {
        public DbSet<AnalogInput> AnalogInputs { get; set; }
        public DbSet<AnalogOutput> AnalogOutputs { get; set; }
        public DbSet<DigitalInput> DigitalInputs { get; set; }
        public DbSet<DigitalOutput> DigitalOutputs { get; set; }
        public DbSet<Alarm> Alarms { get; set; }
        public DbSet<RecordAlarm> RecordAlarms { get; set; }
    }
}