using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Peoples.Models;
using System.Data.Entity;

namespace Peoples
{
    public class PeopleContext: DbContext
    {
        public PeopleContext() : base("PeopleDatabase")
        {

        }
        public DbSet<People> Peoples { get; set; }
        public DbSet<Person> Persons { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}