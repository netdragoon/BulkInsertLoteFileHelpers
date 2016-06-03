using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Web.Controllers
{
    public class CategoriesController : Controller
    {
        public CategoriesController()
        {

        }

        [HttpGet()]
        public ActionResult Index()
        {
            IEnumerable<Category> categories =
                Category.FindAll(NHibernate.Criterion.Order.Asc("Description")).ToList();
            return View(categories);
        }

        [HttpGet()]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public ActionResult Create(Category model)
        {
            model.CreateAndFlush();

            return RedirectToAction("Index");
        }

        [HttpGet()]
        public ActionResult Edit(long? id)
        {
            if (id.HasValue)
            {
                Category model = Category.TryFind(id.Value);
                if (model != null)
                {
                    return View(model);
                }
                
            }
            return RedirectToAction("Index");
        }

        [HttpPost()]
        public ActionResult Edit(Category model)
        {
            Category modelUpdate = Category.TryFind(model.Id);
            modelUpdate.Description = model.Description;
            modelUpdate.UpdateAndFlush();

            return RedirectToAction("Index");
        }


    }
}