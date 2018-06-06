// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="SuppliersController.cs" company="">
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
    /// Api Controller class used to handle data services for suppliers.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class SuppliersController : ApiController
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SuppliersController"/> class.
        /// </summary>
        public SuppliersController()
        {
            _context = new ApplicationDbContext();
        }


        //GET /api/suppliers
        /// <summary>
        /// Gets the suppliers.
        /// </summary>
        /// <returns>IEnumerable&lt;SupplierDto&gt;.</returns>
        public IEnumerable<SupplierDto> GetSuppliers()
        {
            return _context.Suppliers.ToList().Select(Mapper.Map<Supplier, SupplierDto>);
        }


        //GET /api/suppliers/1
        /// <summary>
        /// Gets the supplier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        public IHttpActionResult GetSupplier(int id)
        {
            var supplier = _context.Suppliers.SingleOrDefault(c => c.SupplierId == id);

            if (supplier == null)
                return NotFound();

            return Ok(Mapper.Map<Supplier, SupplierDto>(supplier));
        }


        //POST /api/suppliers
        /// <summary>
        /// Creates the supplier.
        /// </summary>
        /// <param name="supplierDto">The supplier dto.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpPost]
        public IHttpActionResult CreateSupplier(SupplierDto supplierDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var supplier = Mapper.Map<SupplierDto, Supplier>(supplierDto);

            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            // checl that JobDto Id and Job Id match//
            supplierDto.SupplierId = supplier.SupplierId;

            // Return created URI //
            return Created(new Uri(Request.RequestUri + "/" + supplier.SupplierId), supplierDto);
        }


        //PUT /api/suppliers/1
        /// <summary>
        /// Updates the supplier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="supplierDto">The supplier dto.</param>
        /// <exception cref="HttpResponseException">
        /// </exception>
        [HttpPut]
        public void UpdateSupplier(int id, SupplierDto supplierDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var supplierInDb = _context.Suppliers.SingleOrDefault(c => c.SupplierId == id);

            if(supplierInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(supplierDto, supplierInDb);

            _context.SaveChanges();
        }


        //DELETE /api/suppliers/1
        /// <summary>
        /// Deletes the supplier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="HttpResponseException"></exception>
        [HttpDelete]
        public void DeleteSupplier(int id)
        {
            var supplierInDb = _context.Suppliers.SingleOrDefault(c => c.SupplierId == id);

            if (supplierInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Suppliers.Remove(supplierInDb);
            _context.SaveChanges();
        }

    }
}
