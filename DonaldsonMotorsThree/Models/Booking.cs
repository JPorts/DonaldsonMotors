using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    public class Booking
    {
        public Booking()
        {
            Jobs = new List<Job>();
            JobIds = new List<int>();
            PartIds = new List<int>();
        }

        // Booking properties // 
        [Key]
        public int BookingId { get; set; }
        [Display(Name="Booking Paid")]
        public bool PaidFor { get; set; }
        [Display(Name = "Duration")]
        public int? DurationInDays { get; set; }
        public double? Total { get; set; }
        // Dates concerned with booking // 
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Date Completed")]
        public DateTime? DateCompleted { get; set; }
        // IDs Linking other entitities // 
        public List<int> JobIds { get; set; }
        public List<int> PartIds { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }
        public int JobId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual CarPart Part { get; set; }
        public List<Job> Jobs { get; set; }
        public string BookingStatus { get; set; }
    }
}