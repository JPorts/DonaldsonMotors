using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    public class Staff : User
    {
        // Declare Staff Properties // 
        [Display(Name="Employee Id")]
        public int EmployeeId { get; set; }


        [Display(Name = "Date of Birth")]
        public DateTime Dob { get; set; }

        public List<string> Qualifications { get; set; }

        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Display(Name = "Medical Contact Details")]
        public string MedContactDetails { get; set; }

        [Display(Name = "Emergency Contact Details")]
        public string EmergContactDetails { get; set; }

        [Display(Name ="National Insurance Number")]
        public string NiNumber { get; set; }

        [Display(Name = "Area of Expertise")]
        public string AreaOfExpertise { get; set; }

        [Display(Name="Contract Type")]
        public IEnumerable<Contract> Contracts { get; set; }

        [Display(Name = "Role")]
        public string Rolename { get; set; }




    }
}