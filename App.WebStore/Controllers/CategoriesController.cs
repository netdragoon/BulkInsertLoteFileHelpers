using App.WebStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Castle.Components.Validator;
using NHibernate.Criterion;
using App.WebStore.Models.ValidatorExtension;


namespace App.WebStore.Controllers
{
    public class CategoriesController : Controller
    {
        public IValidatorRunner Runner { get; set; }
        public CategoriesController()
        {
            Runner = new ValidatorRunner(new CachedValidationRegistry());
        }
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Category> categories = Category.FindAll(Order.Asc("Description")).ToList();
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
            if (Runner.IsValid(model))
            {
                model.CreateAndFlush();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(Runner.GetErrors(model));
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(long? id)
        {
            if (id.HasValue)
            {
                Category model = Category.TryFind(id);
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
            if (Runner.IsValid(model))
            {
                Category local = Category.TryFind(model.Id);
                local.Description = model.Description;
                local.UpdateAndFlush();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(Runner.GetErrors(model));
            return View(model);
        }
    }
}