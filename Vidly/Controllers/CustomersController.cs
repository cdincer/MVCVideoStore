﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
  {
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult New()
        {

            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes

            };
            return View("CustomerForm",viewModel);
         
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            //Buraya IDnin sifirlanmasi icin. yeni bir variable eklenecek onun sayesinde. 
            //ID hatasinin tamir edilmesi denenecek.
            //https://stackoverflow.com/questions/2142990/the-id-field-is-required-validation-message-on-create-id-not-set-to-required will be looked at looking into how id can be managed getting from new stuff. This method helps you edit stuff too.
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                        .Where(y => y.Count > 0)
                        .ToList();

                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }


            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDay = customer.BirthDay;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribeToNewsLetter = customer.IsSubscribeToNewsLetter;

            }
            _context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }
          public ViewResult Index()
          {
              var customers = _context.Customers.Include(c => c.MembershipType).ToList();
  
              return View(customers);
          }
  
          public ActionResult Details(int id)
          {
              var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
  
              if (customer == null)
                  return HttpNotFound();
  
              return View(customer);
          }

        public ActionResult Edit(int id)
        {

            var customer = _context.Customers.SingleOrDefault(c => c.Id ==id);

            if (customer == null)
                return HttpNotFound();


            var viewModel = new CustomerFormViewModel
            {

                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm",viewModel);

        }












      }
} 