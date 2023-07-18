using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IMarket.Models;
using IMarket.Models.Db;
using DbContext = IMarket.Models.DbContext;

namespace IMarket.Areas.Admin.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private DbContext db = new DbContext();

        // GET: Admin/ProductCategories
        public ActionResult Index()
        {
            return View(db.ProductCategory.Where(x=>x.IsDeleted==false).ToList());
        }

        // GET: Admin/ProductCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = db.ProductCategory.Find(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // GET: Admin/ProductCategories/Create
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                productCategory.IsDeleted = false;
                productCategory.Create=DateTime.Now;
                productCategory.LastUpdate=DateTime.Now;
                db.ProductCategory.Add(productCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productCategory);
        }

        // GET: Admin/ProductCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = db.ProductCategory.Find(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                productCategory.LastUpdate=DateTime.Now;
                db.Entry(productCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productCategory);
        }

        // GET: Admin/ProductCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = db.ProductCategory.Find(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // POST: Admin/ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductCategory productCategory = db.ProductCategory.Find(id);
            db.ProductCategory.Remove(productCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
