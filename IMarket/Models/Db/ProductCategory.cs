using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMarket.Models.Db
{
    public class ProductCategory:BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}