using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMarket.Models;

namespace IMarket.Controllers
{
    public class ClientController : Controller
    {
        private readonly DbContext db =new DbContext();
        // GET: Client

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer customer)
        {
            customer.IsDeleted = false;
            customer.Create=DateTime.Now;
            customer.LastUpdate=DateTime.Now;
            db.Customers.Add(customer);
            db.SaveChanges();
            TempData["Customer"]="Customer has been Added";
            return RedirectToAction ("Index","Home");

        }
    }
}