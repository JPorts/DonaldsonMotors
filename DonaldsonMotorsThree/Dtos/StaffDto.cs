using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.Dtos
{
    public class StaffDto
    {
        // Declare Staff Properties // 
        
        public int EmployeeId { get; set; }

        
        public DateTime Dob { get; set; }


        public List<string> Qualifications { get; set; }

        
        public string MobileNumber { get; set; }

        
        public string MedContactDetails { get; set; }

        
        public string EmergContactDetails { get; set; }

        
        public string NiNumber { get; set; }

       
        public string AreaOfExpertise { get; set; }


        public IEnumerable<Contract> Contracts { get; set; }

       
        public string Rolename { get; set; }
    }
}