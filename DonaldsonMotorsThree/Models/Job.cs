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
        [Display(Name = "Job Requirements")]
        [Required]
        public string JobRequirements { get; set; }

        public virtual List<CarPart> Parts { get; set; }

        [Display(Name = "Price")]
        [Required]
        public double JobCost { get; set; }

        [Display(Name = "Status")]
        [Required]
        public string JobStatus { get; set; }

        [Display(Name = "Customer Id")]
        public string CustomerId { get; set; }

        public int? JobTypeId { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

    
        [Display(Name = "Completed By:")]
        public string CompletedBy { get; set; }

        [Display(Name = "Date Completed")]
        [DataType(DataType.Date)]
        public DateTime? DateCompleted { get; set; }
        
        
    }
}