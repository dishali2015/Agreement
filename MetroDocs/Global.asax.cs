using MetroDocs.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MetroDocs
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_PreSendRequestHeaders()
        {
         //   Response.Headers.Remove("Server");           //Remove Server Header   
           // Response.Headers.Remove("X-AspNet-Version"); //Remove X-AspNet-Version Header
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            MvcHandler.DisableMvcResponseHeader = true;
        }
        protected void Application_Error()
        {
            // var a = HttpContext.Current.Request;
            var exception = Server.GetLastError();
            MetroErrorLog.LogException(exception, HttpContext.Current.Request);
            Server.ClearError();
            
            Response.Redirect("~/Home/MetroApplicaionError");
        }
    }
}
