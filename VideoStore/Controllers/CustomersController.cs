using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VideoStore.Models;
using System.Data.Entity;
using VideoStore.ViewModels;
using System;
using System.Runtime;
using System.Runtime.Caching;

namespace VideoStore.Controllers
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

                //22-Validation summary.
                Customer = new Customer(), 
                MembershipTypes = membershipTypes

            };
            return View("CustomerForm",viewModel);
         
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
         
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
                customerInDb.BirthDate = customer.BirthDate;
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
            const string CacheItem1 = "MembershipTypes";

            if (MemoryCache.Default[CacheItem1] == null)
            {
                MemoryCache.Default[CacheItem1] = _context.MembershipTypes.ToList();
            }

            var Membershiptypes = MemoryCache.Default[CacheItem1] as IEnumerable<MembershipType>;
  
              return View();
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