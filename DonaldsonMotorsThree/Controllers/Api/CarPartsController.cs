using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using DonaldsonMotorsThree.Dtos;
using DonaldsonMotorsThree.Models;
using Microsoft.Ajax.Utilities;

namespace DonaldsonMotorsThree.Controllers.Api
{
    public class CarPartsController : ApiController
    {
        private ApplicationDbContext _context;

        public CarPartsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/carparts
        public IEnumerable<CarPartDto> GetCarParts()
        {
            return _context.CarParts.ToList().Select(Mapper.Map<CarPart, CarPartDto>);
        }


        //GET /api/carparts/1
        public CarPartDto GetCarPart(int id)
        {
            var carPart = _context.CarParts.SingleOrDefault(c => c.PartId == id);
          

            if (carPart == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<CarPart,CarPartDto>(carPart);
        }


        //POST /api/carparts
        [HttpPost]
        public CarPartDto CreateCarPart(CarPartDto carPartDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var carPart = Mapper.Map<CarPartDto, CarPart>(carPartDto);
            _context.CarParts.Add(carPart);
            _context.SaveChanges();
            carPartDto.PartId = carPart.PartId;
            return carPartDto;
        }


        //PUT /api/carparts/1
        [HttpPut]
        public void updateCarPart(int id, CarPartDto carPartDto)
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
        [HttpDelete]
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
