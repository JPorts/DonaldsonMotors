using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    public class Staff
    {
        // Declare Staff Properties // 
        public string EmployeeId { get; set; }

        public DateTime Dob { get; set; }

        public List<string> Qualifications { get; set; }

        public string MobileNumber { get; set; }

        public string MedContactDetails { get; set; }

        public string EmergContactDetails { get; set; }

        public string NiNumber { get; set; }

        public string AreaOfExpertise { get; set; }

        public IEnumerable<Contract> Contracts { get; set; }




    }
}