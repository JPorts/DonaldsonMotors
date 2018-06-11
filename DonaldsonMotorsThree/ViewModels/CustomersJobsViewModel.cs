using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.ViewModels
{

    /// <summary>
    /// Class CustomersJobsViewModel.
    /// </summary>
    public class CustomersJobsViewModel
    {

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>The customer.</value>
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the job.
        /// </summary>
        /// <value>The job.</value>
        public Job Job { get; set; }

    }
}