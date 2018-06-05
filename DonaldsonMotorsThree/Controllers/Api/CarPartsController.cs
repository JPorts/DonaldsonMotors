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
    ///  Api controller class used to handle data services for CarPart objects.
    /// </summary>
    public class CarPartsController : ApiController
    {
        private ApplicationDbContext _context;

        public CarPartsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/carparts
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
