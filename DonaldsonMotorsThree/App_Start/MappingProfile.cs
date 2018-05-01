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

            // AutoMapper finds properties and maps objects by convention - Currently using version 4.1.1 // 

            // Maps CarPartDto to CarPart // 
            Mapper.CreateMap<CarPart, CarPartDto>();

            Mapper.CreateMap<CarPartDto, CarPart>();


            // Maps JobDto to Job //
            Mapper.CreateMap<Job, JobDto>();

            Mapper.CreateMap<JobDto, Job>();


            // Maps SupplierDto to Supplier // 
            Mapper.CreateMap<Supplier, SupplierDto>();

            Mapper.CreateMap<SupplierDto, Supplier>();


            //Maps Staff to StaffDto //
            Mapper.CreateMap<Staff, StaffDto>();

            Mapper.CreateMap<StaffDto, Staff>();


            // Maps Customer to CustomerDto// 
            Mapper.CreateMap<Customer, CustomerDto>();

            Mapper.CreateMap<CustomerDto, Customer>();


            //Maps Reviews To ReviewDto // 
            Mapper.CreateMap<Review, ReviewDto>();

            Mapper.CreateMap<ReviewDto, Review>();


        }

    }
}