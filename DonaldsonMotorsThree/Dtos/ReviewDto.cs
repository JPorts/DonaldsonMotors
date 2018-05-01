using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.Dtos
{
        public class ReviewDto
        {
        
            public int ReviewId { get; set; }
            public string Header { get; set; }

            public string Body { get; set; }

            public virtual User User { get; set; }

            public virtual string Id { get; set; }
    
        }

}