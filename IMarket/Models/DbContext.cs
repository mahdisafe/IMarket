using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using IMarket.Models.Db;

namespace IMarket.Models
{
    public class DbContext:System.Data.Entity.DbContext
    {
        public DbContext()
            : base("DefaultConnection" )
        {

        }

         public virtual DbSet<User> Users { get; set; }
         public virtual DbSet<Product> Product { get; set; }
         public virtual DbSet<ProductCategory> ProductCategory { get; set; }

         public virtual DbSet<Customer>Customers { get; set; }



    }
}