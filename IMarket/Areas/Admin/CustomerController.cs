using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMarket.Models;

namespace IMarket.Areas.Admin
{
    public class CustomerController : Controller
    {
        private  DbContext db  = new DbContext();
        // GET: Admin/Customer
        public ActionResult Index()
        {
            var customer = db.Customers.Where(x => x.IsDeleted == false).ToList();

            return View(customer);
        }
    }
}