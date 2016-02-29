using HCPeopleSearchApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace HCPeopleSearchApplication.Context
{
    public class PeopleDBContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Database.SetInitializer<PeopleDBContext>(null);
        }

    }
}