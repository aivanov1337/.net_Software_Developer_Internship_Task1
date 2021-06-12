using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web_Application26034863.Data
{
    public class Web_Application26034863Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Web_Application26034863Context() : base("name=Web_Application26034863Context")
        {
        }

        public System.Data.Entity.DbSet<Web_Application26034863.Models.Person> People { get; set; }
    }
}
