﻿using System;
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
        public ActionResult AddNewMovie(Movie ReceivedMovie)
        {
            _context.Movies.Add(ReceivedMovie);

            _context.SaveChanges();

            return RedirectToAction("Index","Movies");
        }




        public ViewResult Details(Movie ReceivedMovie)
        {
            var foundmovie = _context.Movies.SingleOrDefault(c => c.Id == ReceivedMovie.Id);
            return View(foundmovie);
        }


    }


}