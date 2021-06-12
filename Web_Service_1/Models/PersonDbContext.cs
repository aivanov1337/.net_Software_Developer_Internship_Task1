using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web_Service_1.Models
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext() : base("name=PersonDb")
        {

        } 

        public DbSet<Person> people { get; set; }
    }
}