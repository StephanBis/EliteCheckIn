using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Backend
{
    public class EliteCheckInDB : DbContext
    {
        public EliteCheckInDB()
            : base("EliteCheckInDB")
        {

        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Systems> Systems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}