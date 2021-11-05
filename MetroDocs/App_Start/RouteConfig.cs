using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MetroDocs
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "EditCRF",
                url: "{controller}/{action}/{CustomerId}",
                defaults: new { controller = "Customer", action = "EditCRF" }
            );

            //    routes.MapRoute(
            //    name: "EditClosure",
            //    url: "{controller}/{action}/{ClosureId}",
            //    defaults: new { controller = "CenterClosures", action = "AuditClosure" }
            //);


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );

           
        }
    }
}
