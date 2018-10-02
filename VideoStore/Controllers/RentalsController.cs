using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;
using System.Linq;
using System.Data.Entity;



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
            var Rentals = _context.Rentals.Include(m => m.Movie)
                                          .Include(c=>c.Customer)
                .ToList();

            return View(Rentals);
        }

        [HttpPost]
        public ActionResult Save(Rental customer)
        {

            _context = new ApplicationDbContext();



            var customerInDb = _context.Rentals.Include(m=>m.Customer)
                    .Include(m=>m.Movie)
                    .Single(c => c.Id == customer.Id);

                //customerInDb.Customer.Id = customer.Customer.Id;
                //customerInDb.Movie.Id = customer.Movie.Id;
                //customerInDb.DateRented = customer.DateRented;
                customerInDb.DateReturned = DateTime.Now;

            var rentedmovie = _context.Movies.Single(c => c.Id == customerInDb.Movie.Id);

            int ChangedAvaliableNumber = rentedmovie.NumberAvailable;

            rentedmovie.NumberAvailable = ChangedAvaliableNumber++;




            _context.SaveChanges();

            return RedirectToAction("List", "Rentals");
        }

    }
}