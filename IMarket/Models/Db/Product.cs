using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMarket.Models.Db
{
    public class Product:BaseEntity 
    {
        [Required(ErrorMessage = "Please Enter Product Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Enter SKU")]
        public string SKU { get; set; }
        public string Image { get; set; }


        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual ProductCategory ProductCategory { get; set; }
    }
}