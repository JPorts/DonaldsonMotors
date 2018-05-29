﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.ViewModels
{
    public class BookingFormViewModel
    {
        [Display(Name = "Jobs")]
        public IEnumerable<Job> Jobs { get; set; }


        public Job Job { get; set; }

        public Customer Customer { get; set; }

        public Booking Booking { get; set; }

        public VehicleDetails Vehicle { get; set; }


        //Booking ViewModel//
        // Booking properties // 
        public int BookingId { get; set; }
        [Display(Name = "Booking Paid")]
        public bool PaidFor { get; set; }
        [Display(Name = "Duration")]
        public int? DurationInDays { get; set; }
        public double? Total { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? DateCompleted { get; set; }
        public int CustomerId { get; set; }
        public int JobId { get; set; }
        public int VehicleId { get; set; }
        public string BookingStatus { get; set; }


    }
}