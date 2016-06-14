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
            //IList<Dados> dados = new List<Dados>();
            //dados.Add(new Dados
            //{
            //    Comentarios = "c",
            //    Duracao = "1",
            //    Id = 1, 
            //    Nome = "N",
            //    Nota    ="10",
            //    NotaAlunos = "9.5",
            //    Periodo = "Integral",
            //    Tipo = "Tipo A",
            //    Valor = 250
            //});
            //dados.Add(new Dados
            //{
            //    Comentarios = "b",
            //    Duracao = "2",
            //    Id = 2,
            //    Nome = "A",
            //    Nota = "9",
            //    NotaAlunos = "8.9",
            //    Periodo = "Matutino",
            //    Tipo = "Tipo B",
            //    Valor = 185.58M
            //});
            return View();
        }

        [OutputCache(Duration = 600)]
        public PartialViewResult IndexPartial()
        {
            IList<Dados> dados = new List<Dados>();
            dados.Add(new Dados
            {
                Comentarios = "c",
                Duracao = "1",
                Id = 1,
                Nome = "N",
                Nota = "10",
                NotaAlunos = "9.5",
                Periodo = "Integral",
                Tipo = "Tipo A",
                Valor = 250
            });
            dados.Add(new Dados
            {
                Comentarios = "b",
                Duracao = "2",
                Id = 2,
                Nome = "A",
                Nota = "9",
                NotaAlunos = "8.9",
                Periodo = "Matutino",
                Tipo = "Tipo B",
                Valor = 185.58M
            });
            return PartialView("_PartialPageExemplo", dados);
        }

        [HttpPost]
        public ActionResult Resgatar(IEnumerable<int> Ids)
        {
            if (Ids == null) throw new ArgumentNullException(nameof(Ids));
            return View();
        }
    }
}