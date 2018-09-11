using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;
using VideoStore.ViewModels;

namespace VideoStore.Controllers
{
    public class AccountManagementController : Controller
    {
        // GET: AccountManagement
        public ApplicationDbContext _context2;

        public ActionResult Index()
        {
            _context2 = new ApplicationDbContext();



          var UserRoles = _context2.Database.SqlQuery<AMLViewModel>("select utable.Email,utable.UserName,nroles.Name AS RoleName ,uroles.UserId from AspNetUserRoles uroles LEFT JOIN AspNetRoles nroles ON nroles.Id = uroles.RoleId LEFT JOIN AspNetUsers utable ON utable.Id = uroles.UserId");
           var Conversion = UserRoles.ToList();
     


            return View(Conversion);
        }
    }
}