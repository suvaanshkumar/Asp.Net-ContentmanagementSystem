using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ContenManagementSystem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MainPage", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Page",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Page", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PageManager",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Page", action = "PageManager"}
            );
            routes.MapRoute(
                name: "CompanyDesc",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "CompanyDesc", action = "Index" }
            );
            routes.MapRoute(
                name: "LeftFooter",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "LeftFooter", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
