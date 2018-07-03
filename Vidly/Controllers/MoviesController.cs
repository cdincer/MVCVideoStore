using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public ViewResult Index()
          {
            var movies = _context.Movies.ToList();
  
              return View(movies);    
          }

        public ViewResult AddNewMovie()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Save(Movie EditedMovie)
        {

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                        .Where(y => y.Count > 0)
                        .ToList();

                var viewModel = new Movie();
              
                return View("CustomerForm", viewModel);
            }


            if (EditedMovie.Id == 0)
                _context.Movies.Add(EditedMovie);
            else
            {
                var customerInDb = _context.Movies.Single(c => c.Id == EditedMovie.Id);

                customerInDb.Name = EditedMovie.Name;
                customerInDb.ReleaseDate = EditedMovie.ReleaseDate;
                customerInDb.StockAmount = EditedMovie.StockAmount;
                

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        [HttpPost]
        public ActionResult AddNewMovie(Movie ReceivedMovie)
        {
            _context.Movies.Add(ReceivedMovie);

            _context.SaveChanges();

            return RedirectToAction("Index","Movies");
        }




        public ActionResult Details(Movie ReceivedMovie)
        {
            var foundmovie = _context.Movies.SingleOrDefault(c => c.Id == ReceivedMovie.Id);

            if(foundmovie == null)
                return HttpNotFound();

            return View("Details", foundmovie);
        }


    }


}