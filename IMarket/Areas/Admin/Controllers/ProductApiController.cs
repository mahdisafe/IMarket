using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Web.Mvc;
using IMarket.Models;
using IMarket.Models.Db;
using DbContext = IMarket.Models.DbContext;

namespace IMarket.Areas.Admin.Controllers
{
     
    [System.Web.Http.RoutePrefix("api/ProductApi")]
    public class ProductApiController : ApiController
    {
        private DbContext db = new DbContext();



        [System.Web.Http.Route("GetListProduct")]
        public object GetListProduct()
        {
            var le = db.Product.Where(a => a.IsDeleted == false).Select(a => new 
                
                { Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    SKU=a.SKU,
                    Price=a.Price,
                    Model=a.Model

                }
            ).ToList();
            return Json(le);
        }



 

        [System.Web.Http.Route("GetProduct")]
        [System.Web.Http.HttpGet]
        public object GetProduct(int id)
        {
            var Pro = db.Product
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.Name,
                    Category = p.ProductCategory.Name,
                    Price=p.Price,
                    SKU=p.SKU,
                    Qty=p.Qty,
                    Model=p.Model,
                    IsDelete=p.IsDeleted

                }).OrderByDescending(a => a.Id).FirstOrDefault(a => a.Id == id && a.IsDelete==false);

            if (Pro == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
                 
            }
            else
            {
                return Pro;
            }
        }


        // PUT: api/ProductApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProductApi
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct([FromUri]
             Product product)
        {
            product.Create=DateTime.Now;
            product.LastUpdate=DateTime.Now;
            product.IsDeleted = false;

            db.Product.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // DELETE: api/ProductApi/5
        [ResponseType(typeof(Product))]
        [System.Web.Http.Route("DeleteProduct")]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Product.FirstOrDefault(x=>x.Id==id);
            if (product == null)
            {
                return NotFound();
            }
            product.IsDeleted=true;
            db.Product.AddOrUpdate(product);
            db.SaveChanges();

            return Ok($"Product Has been Removed {product.Name}");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Product.Count(e => e.Id == id) > 0;
        }
    }
}