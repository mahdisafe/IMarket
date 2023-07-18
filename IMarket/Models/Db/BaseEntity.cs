using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMarket.Models.Db
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? Create { get; set; }
        public DateTime? LastUpdate { get; set; }
        public bool IsDeleted { get; set; }
    }
}