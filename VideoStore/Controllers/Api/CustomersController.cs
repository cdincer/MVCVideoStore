using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoStore.Dtos;
using VideoStore.Models;
using System.Data.Entity;
using VideoStore.Filters;

namespace VideoStore.Controllers.Api
{
    [IdentityBasicAuthentication] // Enable authentication via an ASP.NET Identity user name and password
    public class CustomersController : ApiController
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();

        }

        //GET /api/customers

     
        // Require some form of authentication
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers.Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }

            var customerDtos = customersQuery;
            
            return Ok(customerDtos);
        }


        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c=>c.Id==id);
            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }


        //POST /api/customers
        [HttpPost]
        public IHttpActionResult PostCustomer(CustomerDto customeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customeDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customeDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customeDto);
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c=>c.Id==id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var customer =
            Mapper.Map(customerDto, customerInDb);
          

            _context.SaveChanges();
        }

        //DELETE /api/customers/1
        [Authorize(Roles = AuthorizationDetails.AdminLevel)]
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c=>c.Id==id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

        }



    }
}
