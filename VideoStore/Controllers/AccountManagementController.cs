using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;
using VideoStore.ViewModels;
using VideoStore.Query;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Data.Entity;


namespace VideoStore.Controllers
{
    public class AccountManagementController : Controller
    {
        // GET: AccountManagement
        public ApplicationDbContext _context2;

        public ActionResult Index()
        {
            _context2 = new ApplicationDbContext();
            var UserRoles = _context2.Database.SqlQuery<AMLViewModel>(AccountManagement.GetUserList());
            var Conversion = UserRoles.ToList();  
            return View(Conversion);
        }

        public ActionResult New()
         {
            return View();
        }


        [HttpPost]
        public ActionResult New(AMRegViewModel ReceivedUser)
        {
            
               _context2 = new ApplicationDbContext();
            var store = new UserStore<ApplicationUser>(_context2);
            var manager = new UserManager<ApplicationUser>(store);
            var user = new ApplicationUser { UserName = ReceivedUser.Email, Email = ReceivedUser.Email, IDNumber = ReceivedUser.IDNumber};

            manager.Create(user, "Initialpass1!");
            manager.AddToRole(user.Id, ReceivedUser.RoleList.ToString());

            return RedirectToAction("Index", "AccountManagement");
        }

        public ActionResult Details(ApplicationUser Incoming)
        {
            ModelState.Clear(); //To clear all of the warning messages.

            _context2 = new ApplicationDbContext();

            //var UserDetails = _context2.Users.SingleOrDefault(m => m.Id == Incoming.Id);

            var UserDetails = _context2.Database.SqlQuery<AMLViewModel>(AccountManagement.GetSingleUser(Incoming.Id));
            var Test = UserDetails.ToList();
            if (UserDetails == null)
                return HttpNotFound();

            return View(UserDetails);
        }


    }

}
    