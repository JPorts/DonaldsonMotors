using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    /// <summary>
    /// Class describing the properties for an individual button in a view.
    /// </summary>
    public class SingleButtonPartial
    {
        public string ButtonType { get; set; }
        public string Action { get; set; }
        public string Glyph { get; set; }
        public string Text { get; set; }

        public int? BookingId { get; set; }
        public int? CustomerId { get; set; }
        public int? CarPartId { get; set; }
        public int? JobId { get; set; }
        public int? BasketId { get; set; }
        public int? ReviewId { get; set; }
        public int? SupplierId { get; set; }
        public string StaffId { get; set; }
        public string RoleId { get; set; }

        public string ActionParameter
        {
            get
            {
                var param = new StringBuilder(@"/");

                if (BookingId != null && BookingId > 0)
                {
                    param.Append(String.Format("{0}", BookingId));
                }
                if (CustomerId != null && CustomerId> 0)
                {
                    param.Append(String.Format("{0}", CustomerId));
                }
                if (CarPartId != null && CarPartId > 0)
                {
                    param.Append(String.Format("{0}", CarPartId));
                }
                if (JobId != null && JobId > 0)
                {
                    param.Append(String.Format("{0}", JobId));
                }
                if (BasketId != null && BasketId > 0)
                {
                    param.Append(String.Format("{0}", BasketId));
                }
                if (ReviewId != null && ReviewId > 0)
                {
                    param.Append(String.Format("{0}", ReviewId));
                }
                if (StaffId != null && StaffId != "")
                {
                    param.Append(String.Format("{0}", StaffId));
                }
                if (RoleId != null && RoleId != "")
                {
                    param.Append(String.Format("{0}", RoleId));
                }
                if (SupplierId != null && SupplierId > 0)
                {
                    param.Append(String.Format("{0}", SupplierId));
                }


                return param.ToString();

            }
        }


    }
}