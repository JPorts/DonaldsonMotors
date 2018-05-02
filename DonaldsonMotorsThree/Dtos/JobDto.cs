using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.Dtos
{
    public class JobDto
    {

        [Key]
        public int JobId { get; set; }

        public int CustomerId { get; set; }

        public int VehicleId { get; set; }

        public int PartId { get; set; }

        public string CompletedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCompleted { get; set; }

        [Required]
        public string JobRequirements { get; set; }

        [Required]
        public decimal JobCost { get; set; }

        [Required]
        public int JobStatus { get; set; }

        public virtual CarPart CarPart { get; set; }

        public int? CarPartId { get; set; }
    }
}