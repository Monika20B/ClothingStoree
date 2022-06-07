using ClothingStoree.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ClothingStoree.Data
{
    public class DBConnection: DbContext
    {
        public DBConnection() : base("ClothesStoreDBContext")
        {
        }

        public DbSet<Jewels> Jewels { get; set; }
        public DbSet<Clothes> Clothes { get; set; }
        public DbSet<Customers> Customers { get; set; }

        public DbSet<BoughtJewels> BoughtJewels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}