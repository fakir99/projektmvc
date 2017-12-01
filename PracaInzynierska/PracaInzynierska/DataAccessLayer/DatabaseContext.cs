using PracaInzynierska.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PracaInzynierska.DataAccessLayer
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext() : base("DatabaseContext")
        {

        }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Order> Orders { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}