using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;

namespace VideoStore.Controllers
{
    public class AccountManagementController : Controller
    {
        // GET: AccountManagement
        public ApplicationDbContext _context2;

        public ActionResult Index()
        {
            _context2 = new ApplicationDbContext();

          var UserRoles = _context2.Database.SqlQuery<UserRole>("select uroles.UserId,nroles.Name from AspNetUserRoles uroles LEFT JOIN AspNetRoles nroles ON nroles.Id = uroles.RoleId ");
            var Conversion = UserRoles.ToList();
            var Roles = _context2.Roles.ToList();
            var Users = _context2.Users.ToList();


            return View(Users);
        }
    }
}