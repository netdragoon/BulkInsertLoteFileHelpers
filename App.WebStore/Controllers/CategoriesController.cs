using App.WebStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NHibernate.Criterion;

namespace App.WebStore.Controllers
{
    public class CategoriesController : Controller
    {
        
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
            model.CreateAndFlush();
            return RedirectToAction("Index");
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
            model.Update();
            return RedirectToAction("Index");
        }
    }
}