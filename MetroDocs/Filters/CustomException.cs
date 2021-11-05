using MetroDocs.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MetroDocs.Filters
{
    public class CustomExceptionFilter : FilterAttribute,IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception is NullReferenceException)
            {
                MetroErrorLog.LogException(filterContext.Exception, HttpContext.Current.Request);
                filterContext.ExceptionHandled = true;
                filterContext.Result = new RedirectResult("~/Home/MetroApplicaionError");                
            }
        }
    }
}