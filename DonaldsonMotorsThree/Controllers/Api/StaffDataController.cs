// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="StaffDataController.cs" company="">
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
using System.Web.Http.ModelBinding;
using AutoMapper;
using DonaldsonMotorsThree.Dtos;
using DonaldsonMotorsThree.Models;
using Microsoft.AspNet.Identity;

namespace DonaldsonMotorsThree.Controllers.Api
{
    /// <summary>
    /// Api Controller Class used to handle data services for staff members.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class StaffDataController : ApiController
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;

        // Initialise DbContext in Constructor // 
        /// <summary>
        /// Initializes a new instance of the <see cref="StaffDataController"/> class.
        /// </summary>
        public StaffDataController()
        {
           _context = new ApplicationDbContext();
        }

        /// <summary>
        /// Gets the staff.
        /// </summary>
        /// <returns>IEnumerable&lt;StaffDto&gt;.</returns>
        public IEnumerable<StaffDto> getStaff()
        {
            return _context.Staff.ToList().Select(Mapper.Map<Staff, StaffDto>);
        }

        //GET /api/staffdata/1
        /// <summary>
        /// Gets the staff.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        public IHttpActionResult GetStaff(string id)
        {
            // Search the context for staff using id 
            var staff = _context.Staff.SingleOrDefault(s => s.Id == id);

            // if staff is null then return not found error // 
            if (staff == null)
                return NotFound();
            return Ok(Mapper.Map<Staff,StaffDto>(staff));
        }



        /// <summary>
        /// Updates the staff.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="staffDto">The staff dto.</param>
        /// <exception cref="HttpResponseException">
        /// </exception>
        [HttpPut]
        public void UpdateStaff(string id, StaffDto staffDto)
        {
            // If model state is valid, throw new bad request // 
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
        

            // staffInDb is assigned to staff object through id match // 
            var staffInDb = _context.Staff.SingleOrDefault(s => s.Id == id);

            // if staff is null throw new http not found status code //
            if (staffInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // use mapper to map staffDto to staffInDb // 
            Mapper.Map(staffDto, staffInDb);

            //Save changes //
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes the staff.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="HttpResponseException"></exception>
        [HttpDelete]
        public void DeleteStaff(string id)
        {
            // Create staffInDb which is assigned to staff through id match //
            var staffInDb = _context.Staff.SingleOrDefault(s => s.Id == id);

            // if staffInDb is null throw not found //
            if(staffInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //else remove staffInDb from db and save changes // 
            _context.Staff.Remove(staffInDb);
            _context.SaveChanges();

        }




    }

}
