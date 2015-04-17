using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // 1 - (/) Produtos de todas as categorias
            routes.MapRoute(null,
                "",
                new {controller = "Vitrine",
                     action = "ListaProdutos", 
                     categoria = (string) null, pagina = 1});

            // 2 - (/Pagina2  Todas as categorias da pagina 2
            routes.MapRoute(null,
                "Pagina{pagina}",
                new {controller = "Vitrine", 
                action = "ListaProdutos", 
                categoria = (string) null},
                new {pagina = @"\d+"});


            // 3 - (/Futebol) Primeira pagina da categoria futebol
            routes.MapRoute(null,"{categoria}",new
            {
                controller = "Vitrine", 
                action = "ListaProdutos", 
                pagina = 1
            });


            // 4 - (/Futebol/Pagina2) Pagina 2 da categoria futebol
            routes.MapRoute(null,
                "{categoria}Pagina{pagina}",
                new 
                {
                    controller = "Vitrine", 
                    action = "ListaProdutos"
                }, 
                new {pagina = @"\d+"});


            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
