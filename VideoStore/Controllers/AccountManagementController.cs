using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;
using VideoStore.ViewModels;
using VideoStore.Query;

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
    }
}