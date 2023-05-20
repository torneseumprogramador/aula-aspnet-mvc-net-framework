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
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "SignOut",
              url: "{controller}/{action}",
              defaults: new { controller = "Login", action = "Signout" }
          );

            routes.MapRoute(
                name: "ListaClientes",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "usuario_cadastro",
                url: "{controler}/{action}",
                defaults: new { controller = "Usuarios", action = "Cadastrar" }
            );

            routes.MapRoute(
                name: "clientes_atualizar",
                url: "{controler}/{action}/{id}",
                defaults: new { controller = "Clientes", action = "Atualizar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "usuario_exclusao",
                url: "{controler}/{action}/{id}",
                defaults: new { controller = "Clientes", action = "Excluir", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "form_view",
               url: "{controler}/Form",
               defaults: new { controller = "Clientes", action = "Form" }
           );

        }
    }
}
