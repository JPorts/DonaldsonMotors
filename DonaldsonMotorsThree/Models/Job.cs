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
        [Display(Name = "Job Id")]
        public int JobId { get; set; }

        [Display(Name = "Customer Id")]
        public int? CustomerId { get; set; }

        [Display(Name = "Part Id")]
        public int PartId { get; set; }

        [Display(Name = "Completed By:")]
        public string CompletedBy { get; set; }

        [Display(Name = "Date Completed")]
        [DataType(DataType.Date)]
        public DateTime? DateCompleted { get; set; }

        [Display(Name = "Job Requirements")]
        [Required]
        public string JobRequirements { get; set; }

        [Display(Name = "Price")]
        [Required]
        public decimal JobCost { get; set; }

        [Display(Name = "Status")]
        [Required]
        public int JobStatus { get; set; }

        public virtual CarPart CarPart { get; set; }

        public int? CarPartId { get; set; }
    }
}