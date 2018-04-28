using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        public int? CustomerId { get; set; }

        public int PartId { get; set; }

        [Display(Name = "Completed By:")]
        public string CompletedBy { get; set; }

        [Display(Name = "Date Completed")]
        [DataType(DataType.Date)]
        public DateTime? DateCompleted { get; set; }

        [Display(Name = "Job Requirements")]
        [Required]
        public string JobRequirements { get; set; }

        [Required]
        public decimal JobCost { get; set; }

        [Required]
        public int JobStatus { get; set; }
    }
}