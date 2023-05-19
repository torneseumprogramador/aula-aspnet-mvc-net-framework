using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_GerenciadorDeConteudo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "sobre_cairo_parametro",
                url: "sobre/{id}/cairo",
                new { controller = "Home", action = "About", id = 0 }
                );

            routes.MapRoute(
                name: "sobre1",
                url: "sobre2",
                new { controller = "Home", action = "About" }
                );

            routes.MapRoute(
                name: "paginas",
                url: "paginas",
                new { controller = "Paginas", action = "Index" }
                );

            routes.MapRoute(
                name: "paginas_novo",
                url: "paginas/novo",
                new { controller = "Paginas", action = "Novo" }
                );

            routes.MapRoute(
                name: "paginas_criar",
                url: "paginas/criar",
                new { controller = "Paginas", action = "Criar" }
                );

            routes.MapRoute(
                name: "paginas_editar",
                url: "paginas/{id}/editar",
                new { controller = "Paginas", action = "Editar", id = 0 }
                );

            routes.MapRoute(
                name: "paginas_alterar",
                url: "paginas/{id}/alterar",
                new { controller = "Paginas", action = "Alterar", id = 0 }
                );

            routes.MapRoute(
                name: "paginas_excluir",
                url: "paginas/{id}/excluir",
                new { controller = "Paginas", action = "Excluir", id = 0 }
                );

            routes.MapRoute(
                name: "paginas_preview",
                url: "paginas/{id}/preview",
                new { controller = "Paginas", action = "Preview", id = 0 }
                );
            routes.MapRoute(
                name: "cep_consulta",
                url: "cep/consulta",
                new { controller = "Cep", action = "Index" }
                );

            routes.MapRoute(
                name: "contato1",
                url: "contato2",
                new { controller = "Home", action = "Contact" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
