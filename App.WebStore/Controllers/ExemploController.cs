using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.WebStore.Models;

namespace App.WebStore.Controllers
{
    public class ExemploController : Controller
    {
        // GET: Exemplo
        public ActionResult Index()
        {
            IList<Exemplo> exemplos = new List<Exemplo>();
            exemplos.Add(new Exemplo {Id = 1, Nome = "Nome 1"});
            exemplos.Add(new Exemplo { Id = 2, Nome = "Nome 2" });
            return View(exemplos);
        }

        [HttpPost]
        public ActionResult Resgatar(IEnumerable<int> Ids)
        {
            if (Ids == null) throw new ArgumentNullException(nameof(Ids));
            return View();
        }
    }
}