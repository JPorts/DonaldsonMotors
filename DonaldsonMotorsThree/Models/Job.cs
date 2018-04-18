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

        public int CustomerId { get; set; }

        public int VehicleId { get; set; }

        public int PartId { get; set; }

        public string CompletedBy { get; set; }

        public DateTime DateCompleted { get; set; }

        [Required]
        public string JobRequirements { get; set; }

        [Required]
        public decimal JobCost { get; set; }

        [Required]
        public int JobStatus { get; set; }
    }
}