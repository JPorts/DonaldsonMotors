using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    public class Thumbnail
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public string JobRequirements { get; set; }
        public string Link { get; set; }

        public string ImageURL { get; set; }
    }
}