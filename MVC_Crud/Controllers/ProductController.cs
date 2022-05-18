using MVC_Crud.Models;
using MVC_Crud.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Crud.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Product
        public ActionResult Index()
        {
            //var product = dbContext.Products.ToList();

            var products = (from p in dbContext.Products
                            join
                            c in dbContext.Categories
                            on p.category.Id equals c.Id

                            select new ProductListViewModel()
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Quantity = p.Quantity,
                                Price = p.Price,
                                Description = p.Description,
                                category = c.Name
                            });
            return View(products);
        }



        public ActionResult Create()
        {
            var cats = dbContext.Categories.ToList();
            ViewBag.cats = cats;
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductviewModel product)
        {
            var cat = dbContext.Categories.SingleOrDefault(a => a.Id == product.category);
            var objproduct = new Product()
            {
                Name = product.Name,
                Quantity = product.Quantity,
                Description=product.Description,
                Price=product.Price,
                category=cat
            };
            dbContext.Products.Add(objproduct);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var cats = dbContext.Categories.ToList();
            ViewBag.cats = cats;
            var product = dbContext.Products.SingleOrDefault(a => a.Id == id);
            return View(product);
        }
        [HttpPost]             
        public ActionResult Edit(ProductviewModel product)
        {

            var cat = dbContext.Categories.SingleOrDefault(a => a.Id == product.category);
            var objproduct = new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
                Description = product.Description,
                Price = product.Price,
                category = cat
            };
            dbContext.Entry(objproduct).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var product = dbContext.Products.SingleOrDefault(a => a.Id == id);
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}