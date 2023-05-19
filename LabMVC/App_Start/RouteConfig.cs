using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LabMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "clientes_novo",
               url: "clientes/novo",
               defaults: new { controller = "Clientes", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "usuario_cadastro",
                url: "{controler}/{action}/{id}",
                defaults: new { controller = "Usuarios", action = "Form", id = UrlParameter.Optional }
            );
        }
    }
}
