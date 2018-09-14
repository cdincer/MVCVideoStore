using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;

namespace VideoStore.Controllers
{
    public class RentalsController : Controller
    {
        public ApplicationDbContext _context;

        // GET: Rentals
        public ActionResult New()
        {
            return View();
        }

        public ActionResult List()
        {
            _context = new ApplicationDbContext();
            var Rentals = _context.Rentals.ToList();

            return View(Rentals);
        }

    }
}