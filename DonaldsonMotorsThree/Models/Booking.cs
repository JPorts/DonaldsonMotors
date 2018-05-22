﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    public class Booking
    {
        // Booking properties // 
        [Key]
        public int BookingId { get; set; }

        [Display(Name="Booking Paid")]
        public bool PaidFor { get; set; }

        [Display(Name = "Duration")]
        public int? DurationInDays { get; set; }

        public decimal? Total { get; set; }

        // Dates concerned with booking // 
        public DateTime? startDate { get; set; }

        public DateTime? DateCompleted { get; set; }


        // IDs Linking other entitities // 
        public List<int> JobIds { get; set; }

        public int CustomerId { get; set; }

        public int JobId { get; set; }

        public virtual Customer Customer { get; set; }

        public  virtual Job Job { get; set; }


    }
}