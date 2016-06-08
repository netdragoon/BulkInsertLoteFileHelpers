using App.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using App.Models.Abstract;
namespace App.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly RepositoryCategoryAbstract _category;

        public CategoriesController(RepositoryCategoryAbstract category)
        {
            _category = category;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var order = OrderList.Create(OrderItem.Create("Description", OrderType.Asc));
            IEnumerable<Category> categories = _category.All(order);
            return View(categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category model)
        {
            _category.Insert(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(long? id)
        {
            if (id.HasValue)
            {
                Category model = _category.Find(id.Value);
                if (model != null)
                {
                    return View(model);
                }
                
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Category model)
        {
            Category modelUpdate = _category.Find(model.Id);
            modelUpdate.Description = model.Description;
            _category.Update(modelUpdate);

            return RedirectToAction("Index");
        }


    }
}