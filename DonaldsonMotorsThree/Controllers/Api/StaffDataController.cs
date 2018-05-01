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

        public IHttpActionResult GetStaff(int id)
        {
            // Search the context for staff using id 
            var staff = _context.Staff.SingleOrDefault(s => s.EmployeeId == id);

            // if staff is null then return not found error // 
            if (staff == null)
                return NotFound();
            return Ok(Mapper.Map<Staff,StaffDto>(staff));
        }




    }

}
