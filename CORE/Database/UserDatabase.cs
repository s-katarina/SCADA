using CORE.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CORE.Database
{
    public class UserDatabase : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}