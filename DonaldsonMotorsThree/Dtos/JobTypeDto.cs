using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.Dtos
{
    public class JobTypesDto
    {
       public int Id { get; set; }
       public string JobRequirements { get; set; }
       public double JobCost { get; set; }
    }
}