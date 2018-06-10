// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="CustomersController.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using DonaldsonMotorsThree.Dtos;
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.Controllers.Api
{
    /// <summary>
    /// Api Controller Class used to handle data services for customers.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class CustomersController : ApiController
    {
        // Declare d context// 
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;

        //Initialise DbContext in Constructor // 
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersController"/> class.
        /// </summary>
        public CustomersController()
        {
                _context = new ApplicationDbContext();
        }
        //GET /api/customers
        /// <summary>
        /// Gets the customers.
        /// </summary>
        /// <returns>IEnumerable&lt;CustomerDto&gt;.</returns>
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        //GET /api/customers/1
        /// <summary>
        /// Gets the customer.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        public IHttpActionResult GetCustomer(string id)
        {
            // Search the context for staff using passed id//
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            // if customer is null retuen not found//
            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }


        //POST /api/customers
        /// <summary>
        /// Creates the customer.
        /// </summary>
        /// <param name="customerDto">The customer dto.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            // If model state isnt valid// 

            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");

            //else
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            // Add Customer to Database// 
            _context.Customers.Add(customer);
            // Save changes// 
            _context.SaveChanges();

            //Check that CustomerDto ID and Customer Id Match// 
            customerDto.CustomerId = customer.Id;
            //Return Created URI// 
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //PUT /api/customers/1
        /// <summary>
        /// Updates the customer.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="customerDto">The customer dto.</param>
        /// <exception cref="HttpResponseException">
        /// </exception>
        [HttpPut]
        public void UpdateCustomer(string id, CustomerDto customerDto)
        {
            // If Model State is valid, throw new bad request//
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            // customerInDb is assigned to pbject through id match // 
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            //if customer is null throw new http not found status code// 
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // Use mapper to map customerDto to CustomerInDb // 
            Mapper.Map(customerDto, customerInDb);

            //Save Changes// 
            _context.SaveChanges();
        }

        //DELETE /api/customers/1
        /// <summary>
        /// Deletes the customer.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="HttpResponseException"></exception>
        [HttpDelete]
        public void DeleteCustomer(string id)
        {
            //Create customerInDb which is assigned to customer through id match//

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            //if customerInDb is null throw not found // 
            if(customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            //else remove customerInDb from db and save changes// 
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
           
        }

    }
}
