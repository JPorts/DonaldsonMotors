using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DonaldsonMotorsThree.Models
{
    public class RoleDelegator
    {

        [Required(ErrorMessage = " Select proper UserRole Name")]
        public string UserRoleName
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Select User ID")]
        public string UserID
        {
            get;
            set;
        }
        public List<SelectListItem> Userlist
        {
            get;
            set;
        }
        public List<SelectListItem> UserRolesList
        {
            get;
            set;
        }
    }
}