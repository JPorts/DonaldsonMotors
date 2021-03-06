﻿// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="ReviewsController.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.CodeDom;
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
    /// Api controller class is used to direct data services within the application for reviews and feedback functions.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class ReviewsController : ApiController
    {
        // This is the Reviews API controller // 
        // The controller is used to direct data services within the application for reviews and feedback functions //

        //Declare Context // 
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;

        // Initialise DbContext in constructor //
        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewsController"/> class.
        /// </summary>
        public ReviewsController()
        {
            _context = new ApplicationDbContext();
        }


        //GET /api/reviews
        /// <summary>
        /// Gets the reviews.
        /// </summary>
        /// <returns>IEnumerable&lt;ReviewDto&gt;.</returns>
        public IEnumerable<ReviewDto> GetReviews()
        {
            return _context.Reviews.ToList().Select(Mapper.Map<Review, ReviewDto>);

        }

        //GET /api/reviews/1
        /// <summary>
        /// Gets the review.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        public IHttpActionResult GetReview(int id)
        {
            var review = _context.Reviews.SingleOrDefault(r => r.ReviewId == id);
            // if review returned is null, return not found error // 
            if (review == null)
                NotFound();
            // else return OK with maper mapping review DTO to review //

            return Ok(Mapper.Map<Review, ReviewDto>(review));
        }

        //POST /api/reviews
        /// <summary>
        /// Creates the review.
        /// </summary>
        /// <param name="reviewDto">The review dto.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpPost]
        public IHttpActionResult CreateReview(ReviewDto reviewDto)
        {
            // if model state is not valid, return bad request // 
            if (!ModelState.IsValid)
                return BadRequest();
            //else
            var review = Mapper.Map<ReviewDto, Review>(reviewDto);

            //add review to database and save changes // 

            _context.Reviews.Add(review);
            _context.SaveChanges();

            // Check that review Dto Id and review id match // 
            reviewDto.ReviewId = review.ReviewId;

            // return created URI // 

            return Created(new Uri(Request.RequestUri + "/" + review.ReviewId), reviewDto);
        }

        /// <summary>
        /// Updates the review.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="reviewDto">The review dto.</param>
        /// <exception cref="HttpResponseException">
        /// </exception>
        [HttpPut]
        public void UpdateReview(int id, ReviewDto reviewDto)
        {
            // if model state is valid, throw new bad request // 
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            // review in db is assigned to review through id match //
            var reviewInDb = _context.Reviews.SingleOrDefault(r => r.ReviewId == id);

            // if review is null, throw http not found // 
            if(reviewInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // Map review DTO to reviewInDb // 
            Mapper.Map(reviewDto, reviewInDb);

            // save changes //
            _context.SaveChanges();
        }

        //DELETE /api/reviews/1
        /// <summary>
        /// Deletes the review.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="HttpResponseException"></exception>
        [HttpDelete]
        public void DeleteReview(int id)
        {
            // Create reviewInDb through id match // 
            var reviewInDb = _context.Reviews.SingleOrDefault(r => r.ReviewId == id);

            //if reviewInDb is null, throw not found http status code // 
            if(reviewInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //else remove reviewInDb and save changes // 
            _context.Reviews.Remove(reviewInDb);
            _context.SaveChanges();

        }


    }
}
