using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.ViewModels
{
    public class ReportViewModel
    {
        public CarPart CarPart { get; set; }

        public Customer Customer { get; set; }

        public Job Job { get; set; }


        public IEnumerable<CarPart> CarParts { get; set; }
    }
}