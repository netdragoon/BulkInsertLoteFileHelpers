using System.Collections.Generic;
using App.Models;
using System.Web.Mvc;
using App.Models.Abstract;

namespace App.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly RepositoryProductAbstract _product;
        private readonly RepositoryCategoryAbstract _category;

        public ProductsController(RepositoryCategoryAbstract category, RepositoryProductAbstract product)
        {
            _category = category;
            _product = product;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var order = NHibernate.Criterion.Order.Asc("Description");
            return View(_product.All(order));
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
            model.Category = _category.Find(categoryId);
            _product.Insert(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(long? id)
        {            
            if (id.HasValue)
            {
                Product model = _product.Find(id.Value);
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
            Product modelUpdate = _product.Find(model.Id);
            modelUpdate.Description = model.Description;
            modelUpdate.Category = _category.Find(categoryId);
            _product.Update(modelUpdate);

            return RedirectToAction("Index");
        }

        protected void RenderViewBag(long? selectValue = null)
        {
            var order = NHibernate.Criterion.Order.Asc("Description");
            IEnumerable<Category> items = _category.All(order);
            ViewBag.CategoryId = new SelectList(items, "Id", "Description", selectValue);
        }
    }
}