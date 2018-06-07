using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DonaldsonMotorsThree.Dtos;
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.ViewModels
{
    public class JobViewModel
    {
        public Job Job { get; set; }

        public JobDto JobDto { get; set; }

        public JobTypes JobType { get; set; }
    }
}