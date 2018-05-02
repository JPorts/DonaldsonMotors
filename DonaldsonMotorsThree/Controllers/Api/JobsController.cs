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
    //Jobs API using Job Data Transfer Object to map to objects from Db// 
    public class JobsController : ApiController
    {
        // Declare DbContext //
        private ApplicationDbContext _context;

        // Initialise DbContext in constructor //
        public JobsController()
        {
           _context = new ApplicationDbContext();
        }


        // GET /api/jobs/        //
        public IEnumerable<JobDto> GetJobs(string query = null)
        {
           // var jobQuery = _context.Jobs.Include(c=>c.)
            return _context.Jobs.ToList().Select(Mapper.Map<Job, JobDto>);

        }


        // Get /api/jobs/1           //
        public IHttpActionResult GetJob(int id)
        {
            // Search context in table jobs where c goes to c.JobId and checks id to return a match //
            var job = _context.Jobs.SingleOrDefault(c => c.JobId == id);

            // If job returned is null then return NotFound error //
            if (job == null)
                NotFound();
            // else return Ok with mapper mapping to JobDto from Job object pulled from database //
            return Ok(Mapper.Map<Job, JobDto>(job));
        }


        // POST /api/jobs
        [HttpPost]
        public IHttpActionResult CreateJob(JobDto jobDto)
        {
            // If model state is not valid then return bad request//
            if (!ModelState.IsValid)
                return BadRequest();
            // else
            var job = Mapper.Map<JobDto, Job>(jobDto);

            // Add job to database and save changes // 
            _context.Jobs.Add(job);
            _context.SaveChanges();

            // checl that JobDto Id and Job Id match//
            jobDto.JobId = job.JobId;

            // Return created URI //
            return Created(new Uri(Request.RequestUri + "/" + job.JobId), jobDto);
        }


        // PUT /api/jobs/1
        [HttpPut]
        public void UpdateJob(int id, JobDto jobDto)
        {
            // If Model state is not valid, throw bad request http status code 400 // 
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            // jobInDb is assigned to job object through id match in the lambda expression // 
            var jobInDb = _context.Jobs.SingleOrDefault(c => c.JobId == id);

            // if jobInDb is null, throw http not found status code 404 //
            if (jobInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // Use mapper to ma jobDto to the jobInDb // 
            Mapper.Map(jobDto, jobInDb);

            // Save changes in context // 
            _context.SaveChanges();
        }


        // DELETE /api/jobs/1
        [HttpDelete]
        public void DeleteJob(int id)
        {
            // Create jobInDb var which is assigned to job pulled using id in the lambda expression //
            var jobInDb = _context.Jobs.SingleOrDefault(c => c.JobId == id);

            // if jobInDb is null, throw notFound Http status code // 
            if (jobInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // else remove jobInDb from context and save changes // 
            _context.Jobs.Remove(jobInDb);
            _context.SaveChanges();
        }



    }
}
