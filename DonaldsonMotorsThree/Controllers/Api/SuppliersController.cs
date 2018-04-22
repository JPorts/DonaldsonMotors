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
    public class SuppliersController : ApiController
    {
        private ApplicationDbContext _context;

        public SuppliersController()
        {
            _context = new ApplicationDbContext();
        }


        //GET /api/suppliers
        public IEnumerable<SupplierDto> GetSuppliers()
        {
            return _context.Suppliers.ToList().Select(Mapper.Map<Supplier, SupplierDto>);
        }


        //GET /api/suppliers/1
        public IHttpActionResult GetSupplier(int id)
        {
            var supplier = _context.Suppliers.SingleOrDefault(c => c.SupplierId == id);

            if (supplier == null)
                return NotFound();

            return Ok(Mapper.Map<Supplier, SupplierDto>(supplier));
        }


        //POST /api/suppliers
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
