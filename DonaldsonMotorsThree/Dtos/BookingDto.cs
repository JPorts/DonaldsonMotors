using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.Dtos
{
    public class BookingDto
    {
        // Booking properties // 
        [Key]
        public int BookingId { get; set; }

        [Display(Name = "Booking Paid")]
        public bool PaidFor { get; set; }

        [Display(Name = "Duration")]
        public int? DurationInDays { get; set; }

        public double? Total { get; set; }

        // Dates concerned with booking // 
        public DateTime? StartDate { get; set; }

        public DateTime? DateCompleted { get; set; }


        // IDs Linking other entitities // 
        public List<int> JobIds { get; set; }

        public List<int> PartIds { get; set; }
        public int CustomerId { get; set; }

        public string UserId { get; set; }

        public int JobId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual CarPart Part { get; set; }

        public virtual Job Job { get; set; }

        public Booking.BookingStatusEnum BookingStatus { get; set; }
        public enum BookingStatusEnum
        {
            Requested,
            Cancelled,
            Active,
            Complete
        }

    }
}