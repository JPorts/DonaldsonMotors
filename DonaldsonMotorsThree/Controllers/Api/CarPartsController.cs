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
        public IEnumerable<CarPartDto> GetCarParts(string query = null)
        {

            var partsQuery = _context.CarParts.Where(m => m.CurrentQuantity > 0);

            if (!String.IsNullOrWhiteSpace(query))
                partsQuery = partsQuery.Where(m => m.Name.Contains(query));

            return partsQuery.ToList().Select(Mapper.Map<CarPart, CarPartDto>);
           
        }


        //GET /api/carparts/1
        public IHttpActionResult GetCarPart(int id)
        {
            var carPart = _context.CarParts.SingleOrDefault(c => c.PartId == id);


            if (carPart == null)
                return NotFound();

            return Ok(Mapper.Map<CarPart,CarPartDto>(carPart));
        }


        //POST /api/carparts
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateCarPart(CarPartDto carPartDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

          var carPart = Mapper.Map<CarPartDto, CarPart>(carPartDto);
            _context.CarParts.Add(carPart);
            _context.SaveChanges();
            carPartDto.PartId = carPart.PartId;
            return Created(new Uri(Request.RequestUri + "/" +  carPart.PartId), carPartDto);
        }


        //PUT /api/carparts/1
        [System.Web.Http.HttpPut]
        public void UpdateCarPart(CarPartDto carPartDto, int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var carPartInDb = _context.CarParts.SingleOrDefault(c => c.PartId == id);

            if(carPartInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(carPartDto, carPartInDb);

            _context.SaveChanges();

        }

        //DELETE /api/carparts/1
        [System.Web.Http.HttpDelete]
        public void DeleteCarPart(int id)
        {
            var carPartInDb = _context.CarParts.SingleOrDefault(c => c.PartId == id);

            if (carPartInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.CarParts.Remove(carPartInDb);
            _context.SaveChanges();
        }




    }
}
