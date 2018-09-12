﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;
using VideoStore.ViewModels;
using VideoStore.Query;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

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
        public ActionResult New(MovieFormViewModel ReceivedMovie)
        {
            _context2 = new ApplicationDbContext();
            var store = new UserStore<ApplicationUser>(_context2);
            var manager = new UserManager<ApplicationUser>(store);
            var user = new ApplicationUser { UserName = "admin@videostore.com", Email = "admin@videostore.com", IDNumber = "1111" };

            manager.Create(user, "Initialpass1!");
            manager.AddToRole(user.Id, "Admin");
            return View();
        }




    }

}
    