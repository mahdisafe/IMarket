using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMarket.Models.Db
{
    public class UsersRole:BaseEntity
    {
        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}