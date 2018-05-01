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
        [Key]
        public int BookingId { get; set; }

        [Display(Name = "Booking Paid")]
        public bool PaidFor { get; set; }

        [Display(Name = "Duration")]
        public int? DurationInDays { get; set; }

        public List<int> JobIds { get; set; }

        public decimal? Total { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Job Job { get; set; }
    }
}