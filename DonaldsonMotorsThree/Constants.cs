using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree
{
    public static class Constants
    {

        public static class JobStatus
        {
                public const string Cancelled = "Cancelled";
                public const string Requested = "Requested";
                public const string Active = "Active";
                public const string Complete = "Complete";
        }
        public static class BookingStatus
        {
            public const string Cancelled = "Cancelled";
            public const string Requested = "Requested";
            public const string Active = "Active";
            public const string Complete = "Complete";
        }

        public static class Roles
        {
            public const string GarageManager = "Garage Manager";
            public const string Mechanic = "Mechanic";
            public const string StoreManager = "Store Manager";
            public const string Customer = "Customer";
            public const string CorporateCustomer = "Corporate Customer";
            public const string OfficeStaff = "Office Staff";
            public const string Administrator = "Administrator";
        }






    }


}