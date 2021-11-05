using MetroDocs.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web;
using System.Web.Mvc;

// Admin1@@
namespace MetroDocs.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("AgreementList", "Agreement");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public PartialViewResult Dashboard()
        {
          string UserId =   User.Identity.GetUserId();
           
            return PartialView("_Dashboard");
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        [AllowAnonymous]       
        public ActionResult MetroApplicaionError()
        {
            AuthenticationManager.SignOut();
            return View();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            MetroErrorLog.LogException(filterContext.Exception, System.Web.HttpContext.Current.Request);
            filterContext.ExceptionHandled = true;
            Response.Redirect("~/Home/MetroApplicaionError");
        }

    }


}