using System.Web.Mvc;

namespace App.Web.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public string Index(string name)
        {
            return name;
        }
    }
}