using MetroDocs.DBModule;
using MetroDocs.Domain;
using MetroDocs.Domain.MetroContext;
using MetroDocs.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MetroDocs.Domain.ViewModel;
namespace MetroDocs.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        // GET: Role
        //[Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<RoleAndUserList> roleAndUserLists = new List<RoleAndUserList>();

            using (MetroDBContext db = new MetroDBContext())
            {
                roleAndUserLists = db.Database.SqlQuery<RoleAndUserList>("RoleAndUserList").ToList();
            }

            return View(roleAndUserLists);
        }
        [ChildActionOnly]
        public PartialViewResult CreateRole()
        {
            CreateRole role = new CreateRole();

            return PartialView("_CreateRole", role);
        }
        [HttpPost]
        public ActionResult SaveRole(CreateRole createrole)
        {

            if(!ModelState.IsValid)
            {
                return View("_CreateRole");
            }
            var role = createrole.RoleName;

            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            
            if (roleManager.RoleExists(role))
            {
                ModelState.AddModelError("", "Role already available");
                return View("_CreateRole");
            }
             if (!roleManager.RoleExists(role))
                { 
                    roleManager.Create(new IdentityRole(role));
                }

            return Redirect("Index");
        }
        public ActionResult DeleteRole(string RoleName)
        {
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var role = roleManager.FindByName(RoleName);
            var r = roleManager.DeleteAsync(role);
            return Redirect("Index");
        }

        
        public ActionResult UserAndRole()
        {          
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            UserManager<ApplicationUser> usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var users = usermanager.Users.OrderBy(o => o.FullName).ToList();
            var roles = roleManager.Roles.OrderBy(r => r.Name).ToList();

            var usersWithRoles = (from user in users
                                  select new UserItem
                                  {
                                      UserID = user.Id,
                                      UserName = user.UserName,
                                      FullName= user.FullName,
                                      UserRole = (from role in roles
                                                   join userrole in user.Roles on role.Id
                                                   equals userrole.RoleId into gj
                                                   from x in gj.DefaultIfEmpty()
                                                   select new RoleItem
                                                   {   Display = role.Name,
                                                       ID = role.Id,
                                                       IsChecked = ( x == null ) ? false:true
                                                   }).ToList()
                                  }).ToList();             
            
            return View("_UserAndRole", usersWithRoles.OrderBy(o=>o.FullName).ToList());
        }
        [Route("AddUserToRole/{UserID}/{RoleName}",Name = "AddUserToRole")]
        public ActionResult AddUserToRole(string UserID,string RoleName)
        {           
            try
            {
                 bool affectedrows = DBTransaction.AddUserToRole(UserID, RoleName);
              //  UserManager<ApplicationUser> usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
              //  usermanager.AddToRole(UserID, RoleName);                
            }
            catch(Exception ex)
            {
               Utilities.MetroErrorLog.LogException(ex, System.Web.HttpContext.Current.Request);
              //  Response.Redirect("~/Home/MetroApplicaionError");
            }
            
            return  RedirectToAction("UserAndRole");
        }

        [Route("RemoveUserFromRole/{UserID}/{RoleName}",Name = "RemoveUserFromRole")]
        public ActionResult RemoveUserFromRole(string UserID, string RoleName)
        {
            try
            {
                bool affectedrows = DBTransaction.RemoveUserFromRole(UserID, RoleName);
                //  UserManager<ApplicationUser> usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                //  usermanager.AddToRole(UserID, RoleName);                
            }
            catch (Exception ex)
            {
                Utilities.MetroErrorLog.LogException(ex, System.Web.HttpContext.Current.Request);
                //  Response.Redirect("~/Home/MetroApplicaionError");
            }

            return RedirectToAction("UserAndRole");
        }


        private List<RoleItem> getRoleList()
        {
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var roles = roleManager.Roles.ToList();
            List<RoleItem> roleitem = new List<RoleItem>();
            foreach (var r in roles)
            {
                roleitem.Add(new RoleItem { ID = r.Id, Display = r.Name, IsChecked = false });
            }
            return roleitem;
        }

    }
}
