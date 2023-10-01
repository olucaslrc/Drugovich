using AutoMapper;
using Drugovich.Application.DTOs;
using Drugovich.Application.DTOs.App;
using Drugovich.Application.DTOs.Security;
using Drugovich.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drugovich.Application.AutoMapper
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Manager, ManagerDTO>().ReverseMap();
            CreateMap<CustomerGroup, CustomerGroupDTO>().ReverseMap();
            CreateMap<RegisterManagerDTO, Manager>().ReverseMap();
            CreateMap<AddCustomerDTO, Customer>().ReverseMap();
            CreateMap<AddCustomerGroupDTO, CustomerGroup>().ReverseMap();
        }
    }
}