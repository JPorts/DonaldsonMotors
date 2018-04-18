using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    public class VehicleDetails
    {
        [Key]
        public int VehicleId { get; set; }

        [DisplayName("Registration Number")]
        [Required]
        public string RegNumber { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [DisplayName("Engine Size")]
        [Required]
        public string EngineSize { get; set; }

        
        [Required]
        public int Milage { get; set; }






    }
}