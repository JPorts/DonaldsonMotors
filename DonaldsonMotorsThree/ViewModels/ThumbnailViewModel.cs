using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.ViewModels
{
    public class ThumbnailViewModel
    {
        public IEnumerable<Thumbnail> Thumbnails { get; set; }
    }
}