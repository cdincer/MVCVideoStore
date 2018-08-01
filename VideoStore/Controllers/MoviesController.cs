using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;
using VideoStore.ViewModels;
using System.Data.Entity;
namespace VideoStore.Controllers
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
  
              return View();    
          }

        public ViewResult AddNewMovie()
        {
            var GenreTypes = _context.Genres.ToList();


            var viewModel = new MovieFormViewModel()
            {
                ReleaseDate = new DateTime(2001,01,01),
                Genres = GenreTypes

            };
           
            return View("MovieForm", viewModel);
        }




        [HttpPost]
        public ActionResult AddNewMovie(MovieFormViewModel ReceivedMovie)
        {
            
            try
            {
                Movie ToBeAdded = new Movie();
                ToBeAdded.Id = ReceivedMovie.Id;
                ToBeAdded.Name = ReceivedMovie.Name;
                ToBeAdded.ReleaseDate = ReceivedMovie.ReleaseDate;
                ToBeAdded.StockAmount = ReceivedMovie.StockAmount;
                ToBeAdded.GenreId = ReceivedMovie.GenreId;
                _context.Movies.Add(ToBeAdded);

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


            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == ReceivedMovie.Id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
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