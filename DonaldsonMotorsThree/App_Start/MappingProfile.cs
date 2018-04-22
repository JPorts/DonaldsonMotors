using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Web;
using System.Web.Profile;
using AutoMapper;
using DonaldsonMotorsThree.Dtos;
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.App_Start
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            // Maps CarPartDto to CarPart // 
            // AutoMapper finds properties and maps objects by convention // 
            Mapper.CreateMap<CarPart, CarPartDto>();

            Mapper.CreateMap<CarPartDto, CarPart>();

        }

    }
}