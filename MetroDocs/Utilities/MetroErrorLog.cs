using MetroDocs.Mail;
using System;
using Microsoft.AspNet.Identity;
using System.Web;
using System.IO;

namespace MetroDocs.Utilities
{
    public class MetroErrorLog
    {
        public static void LogException(Exception exception, System.Web.HttpRequest request)
        {// customer.UserId = User.Identity.GetUserId();

            var userId = request.RequestContext.HttpContext.User.Identity.GetUserId();
            var username= request.RequestContext.HttpContext.User.Identity.Name;
            var URL = request.RequestContext.HttpContext.Request.Url.AbsoluteUri;
            System.Text.StringBuilder Mailbody = new System.Text.StringBuilder("");

            Mailbody.AppendLine("------------------------------------------------------------------<br>");
            Mailbody.AppendLine($"User Name : {username}<br>");
            Mailbody.AppendLine($"User Id : {userId}<br>");
            Mailbody.AppendLine($"URL  : {URL}<br>");
            Mailbody.AppendLine($"Date : {DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss")}<br>");
            Mailbody.AppendLine($"Mobile Browser   : { request.Browser.IsMobileDevice   }");
            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(exception, true);
          //  Console.WriteLine("Line: " + trace.GetFrame(0).GetFileLineNumber());
            if (exception != null)
            {
                Mailbody.AppendLine($"<br>Exception : {exception.Message}");
                Mailbody.AppendLine($"<br>Source : {exception.Source}");
                Mailbody.AppendLine($"<br>Target Site : {exception.TargetSite}");
                Mailbody.AppendLine($"<br>Type : {exception.GetType().Name}");
               // Mailbody.AppendLine($"<br>Stack : {exception.StackTrace}");
                Mailbody.AppendLine($"<br>Line Number : {trace.GetFrame(0).GetFileLineNumber()}");
            }
            if (exception.InnerException != null)
            {
                Mailbody.AppendLine($"<br>Inner Exception : {exception.InnerException}<br>");
            }
            Mailbody.AppendLine("------------------------------------------------------------------<br>");


            try
            {
                bool a = EMail.sendMail("mailtobabum@gmail.com", "", "Error", Mailbody);
            }
            catch (Exception ex)
            {

            }
            string LogFilName = "ErrorLog" + System.DateTime.Now.ToString("dd-MM-yyyy")+".txt";
            string path = System.Web.Hosting.HostingEnvironment.MapPath($"~/MetroLogFile/{LogFilName}");

            try
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(Mailbody.ToString().Replace("<br>",string.Empty));
                    writer.Close();
                }
            }
            catch(Exception ex)
            {

            }

           


        }
         
    }
}