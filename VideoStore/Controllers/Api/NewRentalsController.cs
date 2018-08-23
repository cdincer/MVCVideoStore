using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VideoStore.Dtos;
using VideoStore.Models;

namespace VideoStore.Controllers.Api
{
    public class NewRentalsController : ApiController
    {

        private ApplicationDbContext _context;


        public NewRentalsController()
        {
            _context = new ApplicationDbContext();

        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental) { 


            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);

            if (customer == null)
                return BadRequest("Customer ID sent is null");

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id));

            if (movies == null)
                return BadRequest("Movie ID sent is null");

            foreach (var movie in movies)
            {
                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }


    }
}
