using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudioCraft.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Add("Contact", new SeoFriendlyRoute("contact-us",
            new RouteValueDictionary(new { controller = "Contact", action = "Index" }),
            new MvcRouteHandler()));

            routes.Add("About", new SeoFriendlyRoute("about-us",
            new RouteValueDictionary(new { controller = "Contact", action = "Index" }),
            new MvcRouteHandler()));


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
