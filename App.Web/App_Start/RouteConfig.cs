using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace App.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //routes.MapRoute(
            //    name: "Produto",
            //    url: "Produto/{name}/{action}",
            //    defaults: new { controller = "Produto", action = "Index" },
            //    constraints: new { name = @"^[a-z\.]{3,20}$" }
            //);

            routes.MapRoute(
                 name: "ProdutoIndex",
                 url: "Produto/{name}",
                 defaults: new { controller = "Produto", action = "Index" },
                 constraints: new { name = @"^[a-z\.-]{3,20}$" }
             );



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
