using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Web.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet()]
        public ActionResult Index()
        {
            return View(Product.FindAll(NHibernate.Criterion.Order.Asc("Description")).AsEnumerable());
        }

        [HttpGet()]
        public ActionResult Create()
        {
            RenderViewBag();
            return View();
        }

        [HttpPost()]
        public ActionResult Create(Product model, long CategoryId)
        {
            model.Category = Category.TryFind(CategoryId);
            model.CreateAndFlush();

            return RedirectToAction("Index");
        }

        [HttpGet()]
        public ActionResult Edit(long? id)
        {            
            if (id.HasValue)
            {
                Product model = Product.TryFind(id.Value);
                if (model != null)
                {
                    RenderViewBag(model?.Category?.Id);
                    return View(model);
                }

            }
            return RedirectToAction("Index");
        }

        [HttpPost()]
        public ActionResult Edit(Product model, long CategoryId)
        {            
            Product modelUpdate = Product.TryFind(model.Id);
            modelUpdate.Description = model.Description;
            modelUpdate.Category = Category.TryFind(CategoryId);
            modelUpdate.UpdateAndFlush();

            return RedirectToAction("Index");
        }

        protected void RenderViewBag(long? selectValue = null)
        {
            Category[] items = Category.FindAll(NHibernate.Criterion.Order.Asc("Description"));
            ViewBag.CategoryId = new SelectList(items, "Id", "Description", selectValue);
        }
    }
}