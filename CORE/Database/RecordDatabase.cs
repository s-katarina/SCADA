using CORE.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CORE.Database
{
    public class RecordDatabase : DbContext
    {
        public DbSet<Record> Records { get; set; }
    }
}