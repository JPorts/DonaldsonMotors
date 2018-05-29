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
        public IHttpActionResult GetStaff(string id)
        {
            // Search the context for staff using id 
            var staff = _context.Staff.SingleOrDefault(s => s.Id == id);

            // if staff is null then return not found error // 
            if (staff == null)
                return NotFound();
            return Ok(Mapper.Map<Staff,StaffDto>(staff));
        }


        ////POST /api/staffdata
        //[HttpPost]
        //public IHttpActionResult CreateStaff(StaffDto staffDto)
        //{
        //    // If model state is not valid then return bad request//
        //    if (!ModelState.IsValid)
        //        return BadRequest("Invalid Data");

        //    //else
        //    var staff = Mapper.Map<StaffDto, Staff>(staffDto);

        //    // add job to database and save changes //
        //    _context.Staff.Add(staff);
        //    _context.SaveChanges();


        //    // check that JobDto Id and Job Id match//
        //   staffDto.EmployeeId = staff.EmployeeId;

        //    // Return created URI //
        //    return Created(new Uri(Request.RequestUri + "/" + staff.EmployeeId), staffDto);

        //}
        //POST /api/staffdata
        //[HttpPost]
        //public IHttpActionResult CreateStaff(StaffDto staffDto)
        //if (ModelState.IsValid)
        //{

        //    // Hash password using password hasher // 
        //    var passwordHasher = new PasswordHasher();
        //    var password = passwordHasher.HashPassword(staff.Password);

        //    // Create new Customer Object // 
        //    var user = new Staff
        //    {
        //        Id = new Guid().ToString(),
        //        UserName = StaffDto.Email,
        //        Email = staff.Email,
        //        FirstName = staff.FirstName,
        //        LastName = staff.LastName,
        //        AddressLine1 = staff.AddressLine1,
        //        AddressLine2 = staff.AddressLine2,
        //        Town = staff.Town,
        //        Postcode = staff.Postcode,
        //        Dob = staff.Dob,
        //        TelephoneNumber = staff.TelephoneNumber,
        //        MobileNumber = staff.MobileNumber,
        //        AreaOfExpertise = staff.AreaOfExpertise,
        //        EmergContactDetails = staff.EmergContactDetails,
        //        MedContactDetails = staff.MedContactDetails,
        //        NiNumber = staff.NiNumber,
        //        PasswordHash = password,
        //        Rolename = staff.Rolename
        //    };

        //    var Account = new AccountController();
        //    Account.UserManager.AddToRole(staff.Id, staff.Rolename);
        //    _context.Users.Add(user);
        //}

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
