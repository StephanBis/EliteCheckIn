using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Backend
{
    public class EliteCheckInDB : DbContext
    {
        public EliteCheckInDB()
            : base("name=EliteCheckInDB")
        {
        }

        public virtual DbSet<Systems> Systems { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}