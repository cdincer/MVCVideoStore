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
                return BadRequest("Customer ID  is not valid");

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            if (newRental.MovieIds.Count == 0)
                return BadRequest("Movie ID is not valid");

            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or more MovieIds are not valid");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumberAvailable--; //Subtract rented amount from this movies record.

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
