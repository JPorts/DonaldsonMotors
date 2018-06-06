// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="CarPartsController.cs" company="">
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
using System.Web.Mvc;
using AutoMapper;
using DonaldsonMotorsThree.Dtos;
using DonaldsonMotorsThree.Models;
using Microsoft.Ajax.Utilities;

namespace DonaldsonMotorsThree.Controllers.Api
{
    /// <summary>
    /// Api controller class used to handle data services for CarPart objects.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class CarPartsController : ApiController
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarPartsController"/> class.
        /// </summary>
        public CarPartsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/carparts
        /// <summary>
        /// Gets the car parts.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>IEnumerable&lt;CarPartDto&gt;.</returns>
        [System.Web.Http.HttpGet]
        public IEnumerable<CarPartDto> GetCarParts(string query = null)
        {

            // Pull carparts with a quantity greater than 0.
            var partsQuery = _context.CarParts.Where(m => m.CurrentQuantity > 0);

            // Checks if query is not null
            if (!String.IsNullOrWhiteSpace(query))
                partsQuery = partsQuery.Where(m => m.Name.Contains(query));
            // Return car parts request
            return partsQuery.ToList().Select(Mapper.Map<CarPart, CarPartDto>);
           
        }


        //GET /api/carparts/1
        /// <summary>
        /// Gets the car part.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetCarPart(int id)
        {
            // Get car part from id match//
            var carPart = _context.CarParts.SingleOrDefault(c => c.PartId == id);

            // return not found if carpart comes back null. 
            if (carPart == null)
                return NotFound();

            // Return carpart and OK response. 
            return Ok(Mapper.Map<CarPart,CarPartDto>(carPart));
        }


        //POST /api/carparts
        /// <summary>
        /// Creates the car part.
        /// </summary>
        /// <param name="carPartDto">The car part dto.</param>
        /// <returns>IHttpActionResult.</returns>
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateCarPart(CarPartDto carPartDto)
        {
            // Check if the model state is not valid. Return bad request if this condition is met.
            if (!ModelState.IsValid)
                return BadRequest();
                    // map carpart object from passed dto// 
          var carPart = Mapper.Map<CarPartDto, CarPart>(carPartDto);
            // Use context to add and save carpart// 
            _context.CarParts.Add(carPart);
            _context.SaveChanges();
            // check both object ids match//
            carPartDto.PartId = carPart.PartId;
            // return created response. 
            return Created(new Uri(Request.RequestUri + "/" +  carPart.PartId), carPartDto);
        }


        //PUT /api/carparts/1
        /// <summary>
        /// Updates the car part.
        /// </summary>
        /// <param name="carPartDto">The car part dto.</param>
        /// <param name="id">The identifier.</param>
        /// <exception cref="HttpResponseException">
        /// </exception>
        [System.Web.Http.HttpPut]
        public void UpdateCarPart(CarPartDto carPartDto, int id)
        {
            // if model state is not valid, throw exeception.
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            // Pull carpart from db using id match. 
            var carPartInDb = _context.CarParts.SingleOrDefault(c => c.PartId == id);

            // If carpart is null, throw exeption //
            if(carPartInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // Mapp dto object to carpartIndb object. 
            Mapper.Map(carPartDto, carPartInDb);

            _context.SaveChanges();

        }

        //DELETE /api/carparts/1
        /// <summary>
        /// Deletes the car part.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="HttpResponseException"></exception>
        [System.Web.Http.HttpDelete]
        public void DeleteCarPart(int id)
        {
            // pull carpart form context using id match. 
            var carPartInDb = _context.CarParts.SingleOrDefault(c => c.PartId == id);

            // if carpart is null, throw exception. 
            if (carPartInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            // if not null, remove from db and save changes. 
            _context.CarParts.Remove(carPartInDb);
            _context.SaveChanges();
        }




    }
}
