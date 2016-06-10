using System.Collections.Generic;
using System.Web.Mvc;
using App.WebStore.Models;

namespace App.WebStore.Controllers
{
    public class ProductsController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            var order = NHibernate.Criterion.Order.Asc("Description");
            return View(Product.FindAll(order));
        }

        [HttpGet]
        public ActionResult Create()
        {
            RenderViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product model, long categoryId)
        {
            model.Category = Category.TryFind(categoryId);
            model.CreateAndFlush();
            return RedirectToAction("Index");
        }

        [HttpGet]
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

        [HttpPost]
        public ActionResult Edit(Product model, long categoryId)
        {
            model.Category = Category.TryFind(categoryId);
            model.UpdateAndFlush();
            return RedirectToAction("Index");
        }

        protected void RenderViewBag(long? selectValue = null)
        {
            var order = NHibernate.Criterion.Order.Asc("Description");
            IEnumerable<Category> items = Category.FindAll(order);
            ViewBag.CategoryId = new SelectList(items, "Id", "Description", selectValue);
        }
    }
}