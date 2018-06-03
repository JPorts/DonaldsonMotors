using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    public class JobTypes
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        
        [Display(Name = "Job Requirements")]
        [Required]
        public string JobRequirements { get; set; }

        [Display(Name = "Price")]
        [Required]
        public double JobCost { get; set; }


        [Display(Name = "Parts")]
        public List<CarPart> Parts{ get; set; }
    }
}