using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    public class RoleName
    {
        // Each constant is used to delegate roles when coding business logic //
        // Below gives a description of the access each role gives //


        //// Has recurring job in place and Invoice sent monthly//
        //public const string CorporateCustomerRole = "CorporateCustomer";

        //// Able to book a job, pay for the job, edit details, leave feedback, amend job requirements and date, . . . //
        //public const string CustomerRole = "Customer";

        // Able to ask for stock requisition for jobs, able to update job status //
        public const string MechanicRole = "Mechanic";

        // Full Access to all features // 
        public const string GarageManagerRole = "GarageManager";

        // Able to add Jobs, Edit Jobs and View All Jobs // 
        public const string OfficeStaffRole = "OfficeStaff";

        // Able to add suppliers, confirm resupply for stock, edit supplier details, delete suppliers//
        //Able to add, edit and delete Parts
        public const string StoreManagerRole = "StoreManager";

        // Can produce Invoice, view working timetable, check stock levels, view all jobs//
        public const string StaffRole = "Staff";

        // For Admins //
        public const string Admin = "Administrator";

    }
}