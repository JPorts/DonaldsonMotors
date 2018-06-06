// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="JobsController.cs" company="">
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
using AutoMapper;
using DonaldsonMotorsThree.Dtos;
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.Controllers.Api
{
    /// <summary>
    /// Api Class handling data services for Jobs in the system.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    //Jobs API using Job Data Transfer Object to map to objects from Db// 
    public class JobsController : ApiController
    {
        // Declare DbContext //
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;

        // Initialise DbContext in constructor //
        /// <summary>
        /// Initializes a new instance of the <see cref="JobsController"/> class.
        /// </summary>
        public JobsController()
        {
           _context = new ApplicationDbContext();
        }


        // GET /api/jobs/        //
        /// <summary>
        /// Gets the job types.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>IEnumerable&lt;JobTypesDto&gt;.</returns>
        public IEnumerable<JobTypesDto> GetJobTypes(string query = null)
        {
            var jq = _context.JobTypes.Where(m => m.JobCost > 0);

            if (!String.IsNullOrWhiteSpace(query))
                jq = jq.Where(m => m.JobRequirements.Contains(query));

            return jq.ToList().Select(Mapper.Map<JobTypes, JobTypesDto>);
        }



        // Get /api/jobs/1           //
        /// <summary>
        /// Gets the job.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
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
        /// <summary>
        /// Creates the job.
        /// </summary>
        /// <param name="jobDto">The job dto.</param>
        /// <returns>IHttpActionResult.</returns>
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
        /// <summary>
        /// Updates the job.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="jobDto">The job dto.</param>
        /// <exception cref="HttpResponseException">
        /// </exception>
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
        /// <summary>
        /// Deletes the job.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="HttpResponseException"></exception>
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
