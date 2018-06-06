using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.ViewModels
{
    public class CustomerViewModel
    { 
        public Customer Customer { get; set; }

        public IEnumerable<Customer> Customers { get; set; }

        public User User { get; set; }


        
    }
}