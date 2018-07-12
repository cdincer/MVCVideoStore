using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }
        public ViewResult Index()
          {
            var movies = _context.Movies.ToList();
  
              return View(movies);    
          }

        public ViewResult AddNewMovie()
        {
            var GenreTypes = _context.Genres.ToList();


            var viewModel = new MovieFormViewModel()
            {
                Movie = new Movie(),
                Genres = GenreTypes


            };
           
            return View("MovieForm", viewModel);
        }




        [HttpPost]
        public ActionResult AddNewMovie(Movie ReceivedMovie)
        {
            
            try
            {
                _context.Movies.Add(ReceivedMovie);

                _context.SaveChanges();

                return RedirectToAction("Index", "Movies");
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }




        public ActionResult Details(Movie ReceivedMovie)
        {
            ModelState.Clear(); //To clear all of the warning messages.


            var foundmovie = _context.Movies.SingleOrDefault(c => c.Id == ReceivedMovie.Id);

            if (foundmovie == null)
                return HttpNotFound();

            return View(foundmovie);
        }




        [HttpPost]
        public ActionResult Save(Movie MovieEdited)
        {

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                        .Where(y => y.Count > 0)
                        .ToList();

             

                return View("Index","Movies");
            }


            if (MovieEdited.Id == 0)
                _context.Movies.Add(MovieEdited);
            else
            {
                var DBMovie = _context.Movies.Single(c => c.Id == MovieEdited.Id);

                DBMovie.Name = MovieEdited.Name;
                DBMovie.Genre = MovieEdited.Genre;
                DBMovie.StockAmount = MovieEdited.StockAmount;
                DBMovie.ReleaseDate = MovieEdited.ReleaseDate;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

    }


}