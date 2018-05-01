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
    public class StaffDataController : ApiController
    {
        private ApplicationDbContext _context;

        // Initialise DbContext in Constructor // 
        public StaffDataController()
        {
           _context = new ApplicationDbContext();
        }

        public IEnumerable<StaffDto> getStaff()
        {
            return _context.Staff.ToList().Select(Mapper.Map<Staff, StaffDto>);
        }

        //GET /api/staffdata/1
        public IHttpActionResult GetStaff(int id)
        {
            // Search the context for staff using id 
            var staff = _context.Staff.SingleOrDefault(s => s.EmployeeId == id);

            // if staff is null then return not found error // 
            if (staff == null)
                return NotFound();
            return Ok(Mapper.Map<Staff,StaffDto>(staff));
        }


        //POST /api/staffdata
        [HttpPost]
        public IHttpActionResult CreateStaff(StaffDto staffDto)
        {
            // If model state is not valid then return bad request//
            if (!ModelState.IsValid)
                return BadRequest();
            //else
            var staff = Mapper.Map<StaffDto, Staff>(staffDto);

            // add job to database and save changes //
            _context.Staff.Add(staff);
            _context.SaveChanges();


            // check that JobDto Id and Job Id match//
           staffDto.EmployeeId = staff.EmployeeId;

            // Return created URI //
            return Created(new Uri(Request.RequestUri + "/" + staff.EmployeeId), staffDto);

        }

        [HttpPut]
        public void UpdateStaff(int id, StaffDto staffDto)
        {
            // If model state is valid, throw new bad request // 
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
        

            // staffInDb is assigned to staff object through id match // 
            var staffInDb = _context.Staff.SingleOrDefault(s => s.EmployeeId == id);

            // if staff is null throw new http not found status code //
            if (staffInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // use mapper to map staffDto to staffInDb // 4
            Mapper.Map(staffDto, staffInDb);

            //Save changes //
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteStaff(int id)
        {
            // Create staffInDb which is assigned to staff through id match //
            var staffInDb = _context.Staff.SingleOrDefault(s => s.EmployeeId == id);

            // if staffInDb is null throw not found //
            if(staffInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //else remove staffInDb from db and save changes // 
            _context.Staff.Remove(staffInDb);
            _context.SaveChanges();

        }




    }

}
